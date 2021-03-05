using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Camera
{
    public class Capture : ISampleGrabberCB, IDisposable
    {
        #region Member variables

        /// <summary> graph builder interface. </summary>
        private IFilterGraph2 m_FilterGraph = null;

        // Used to snap picture on Still pin
        private IAMVideoControl m_VidControl = null;
        private IAMVideoProcAmp m_VideoControl = null;
        private IPin m_pinStill = null;
        private IPin m_pinCapture = null;

        /// <summary> buffer for bitmap data.  Always release by caller</summary>
        private IntPtr m_ipBuffer = IntPtr.Zero;

        /// <summary> so we can wait for the async job to finish </summary>
        private ManualResetEvent m_PictureReady = null;

        private Action<Image> snapshotCb;

        /// <summary> Dimensions of the image, calculated once in constructor for perf. </summary>
        private int m_videoWidth;
        private int m_videoHeight;
        private int m_stride;

        public int Width
        {
            get
            {
                return m_videoWidth;
            }
        }
        public int Height
        {
            get
            {
                return m_videoHeight;
            }
        }
        public int Stride
        {
            get
            {
                return m_stride;
            }
        }

        public event EventHandler SnapshotReceived;

#if DEBUG
        // Allow you to "Connect to remote graph" from GraphEdit
        DsROTEntry m_rot = null;
#endif

        #endregion

        #region APIs
        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
        private static extern void CopyMemory(IntPtr Destination, IntPtr Source, [MarshalAs(UnmanagedType.U4)] int Length);
        #endregion

        // Zero based device index and device params and output window
        public Capture(string iDeviceName, int iWidth, int iHeight, Control previewControl, Action<Image> snapshotCallback) : this(iDeviceName, iWidth, iHeight, previewControl)
        {
            snapshotCb = snapshotCallback;
        }
        
        // Zero based device index and device params and output window
        public Capture(string iDeviceName, int iWidth, int iHeight, Control previewControl)
        {
            DsDevice[] capDevices;
            int iDeviceNum = -1;

            // Get the collection of video devices
            capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            for (int i = 0; i < capDevices.Length; i++)
            {
                if (capDevices[i].Name == iDeviceName)
                {
                    iDeviceNum = i;
                }
            }

            if (iDeviceNum < 0)
            {
                throw new Exception("No video capture devices found!");
            }

            try
            {
                // Set up the capture graph
                SetupGraph(capDevices[iDeviceNum], iWidth, iHeight, previewControl);

                // tell the callback to ignore new images
                m_PictureReady = new ManualResetEvent(false);
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        /// <summary> release everything. </summary>
        public void Dispose()
        {
#if DEBUG
            if (m_rot != null)
            {
                m_rot.Dispose();
            }
#endif

            CloseInterfaces();

            if (m_PictureReady != null)
            {
                m_PictureReady.Close();
            }
        }

        // Destructor
        ~Capture()
        {
            Dispose();
        }

        /// <summary> build the capture graph for grabber. </summary>
        private void SetupGraph(DsDevice dev, int iWidth, int iHeight, Control hControl)
        {
            int hr;

            ISampleGrabber sampleGrabber = null;
            IBaseFilter capFilter = null;
            IPin pSampleIn = null;
            IPin pRenderIn = null;
            IPin pSmartTeeIn = null;
            IPin pSmartTeeOut = null;
            IPin pMJPEGIn = null;
            IPin pMJPEGOut = null;
            IPin pAVIIn = null;
            IPin pAVIOut = null;
            IPin pAVISGIn = null;
            IPin pAVISGOut = null;
            IPin pColourIn = null;
            IPin pColourOut = null;

            // Get the graphbuilder object
            m_FilterGraph = new FilterGraph() as IFilterGraph2;

            try
            {
#if DEBUG
                m_rot = new DsROTEntry(m_FilterGraph);
#endif
                // add the video input device
                hr = m_FilterGraph.AddSourceFilterForMoniker(dev.Mon, null, dev.Name, out capFilter);
                DsError.ThrowExceptionForHR(hr);

                // Get a control pointer
                m_VidControl = capFilter as IAMVideoControl;

                // Find the capture pin
                m_pinCapture = DsFindPin.ByCategory(capFilter, PinCategory.Capture, 0);

                // Find the still pin
                m_pinStill = DsFindPin.ByCategory(capFilter, PinCategory.Still, 0);

                // Config capture pin media type
                ConfigureMediaType(m_pinCapture, iWidth, iHeight, 20);

                // Config still pin media type
                ConfigureMediaType(m_pinStill, iWidth, iHeight, 1);

                // Get the SampleGrabber interface
                sampleGrabber = new SampleGrabber() as ISampleGrabber;

                // Get the default video renderer
                IBaseFilter pSmartTee = new SmartTee() as IBaseFilter;
                hr = m_FilterGraph.AddFilter(pSmartTee, "SmartTee");
                DsError.ThrowExceptionForHR(hr);
                pSmartTeeIn = DsFindPin.ByDirection(pSmartTee, PinDirection.Input, 0);
                pSmartTeeOut = DsFindPin.ByName(pSmartTee, "Preview");
                
                // Get the MJPEG Decoder
                IBaseFilter pMJPEG = new MjpegDec() as IBaseFilter;
                hr = m_FilterGraph.AddFilter(pMJPEG, "MJPEG Decoder");
                DsError.ThrowExceptionForHR(hr);
                pMJPEGIn = DsFindPin.ByDirection(pMJPEG, PinDirection.Input, 0);
                pMJPEGOut = DsFindPin.ByDirection(pMJPEG, PinDirection.Output, 0);
                
                // Get the AVI Decoder
                IBaseFilter pAVI = new AVIDec() as IBaseFilter;
                hr = m_FilterGraph.AddFilter(pAVI, "AVI Decompressor");
                DsError.ThrowExceptionForHR(hr);
                pAVIIn = DsFindPin.ByDirection(pAVI, PinDirection.Input, 0);
                pAVIOut = DsFindPin.ByDirection(pAVI, PinDirection.Output, 0);

                // Get the AVI Decoder for Sample Grabber
                IBaseFilter pAVISG = new AVIDec() as IBaseFilter;
                hr = m_FilterGraph.AddFilter(pAVISG, "AVI Decompressor Sample Grabber");
                DsError.ThrowExceptionForHR(hr);
                pAVISGIn = DsFindPin.ByDirection(pAVISG, PinDirection.Input, 0);
                pAVISGOut = DsFindPin.ByDirection(pAVISG, PinDirection.Output, 0);

                // Get the Colour Space Converter
                IBaseFilter pColour = new Colour() as IBaseFilter;
                hr = m_FilterGraph.AddFilter(pColour, "Colour Space Converter");
                DsError.ThrowExceptionForHR(hr);
                pColourIn = DsFindPin.ByDirection(pColour, PinDirection.Input, 0);
                pColourOut = DsFindPin.ByDirection(pColour, PinDirection.Output, 0);
                
                // Get the default video renderer
                IBaseFilter pRenderer = new VideoMixingRenderer9() as IBaseFilter;
                hr = m_FilterGraph.AddFilter(pRenderer, "Renderer");
                DsError.ThrowExceptionForHR(hr);
                pRenderIn = DsFindPin.ByDirection(pRenderer, PinDirection.Input, 0);

                // Connect the capture pin to the renderer
                hr = m_FilterGraph.Connect(m_pinCapture, pSmartTeeIn);
                DsError.ThrowExceptionForHR(hr);

                hr = m_FilterGraph.Connect(pSmartTeeOut, pRenderIn);
                DsError.ThrowExceptionForHR(hr);

                // Configure the sample grabber
                IBaseFilter baseGrabFlt = sampleGrabber as IBaseFilter;
                ConfigureSampleGrabber(sampleGrabber);
                pSampleIn = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Input, 0);

                // Add the sample grabber to the graph
                hr = m_FilterGraph.AddFilter(baseGrabFlt, "Sample Grabber");
                DsError.ThrowExceptionForHR(hr);

                // Connect the Still pin to the sample grabber
                hr = m_FilterGraph.Connect(m_pinStill, pSampleIn);
                DsError.ThrowExceptionForHR(hr);

                // Learn the video properties
                SaveSizeInfo(sampleGrabber);

                // Config preview window
                ConfigVideoWindow(hControl);

                // Start the graph
                IMediaControl mediaCtrl = m_FilterGraph as IMediaControl;
                hr = mediaCtrl.Run();
                DsError.ThrowExceptionForHR(hr);
            }
            finally
            {
                if (sampleGrabber != null)
                {
                    Marshal.ReleaseComObject(sampleGrabber);
                    sampleGrabber = null;
                }
                if (m_pinCapture != null)
                {
                    Marshal.ReleaseComObject(m_pinCapture);
                    m_pinCapture = null;
                }
                if (pRenderIn != null)
                {
                    Marshal.ReleaseComObject(pRenderIn);
                    pRenderIn = null;
                }
                if (pSampleIn != null)
                {
                    Marshal.ReleaseComObject(pSampleIn);
                    pSampleIn = null;
                }
            }
        }

        // Set the Framerate, and video size
        private void ConfigureMediaType(IPin pStill, int iWidth, int iHeight, int iFPS)
        {
            int hr;
            AMMediaType media;
            IAMStreamConfig videoStreamConfig = pStill as IAMStreamConfig;

            media = GetMediaType(pStill, iWidth, iHeight, iFPS);
            hr = videoStreamConfig.SetFormat(media);
            DsError.ThrowExceptionForHR(hr);
        }

        private void ConfigureSampleGrabber(ISampleGrabber sampleGrabber)
        {
            int hr;
            AMMediaType media = new AMMediaType();

            // Set the media type to Video/RBG24
            media.majorType = MediaType.Video;
            media.subType = MediaSubType.RGB24;
            media.formatType = FormatType.VideoInfo;
            hr = sampleGrabber.SetMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            DsUtils.FreeAMMediaType(media);
            media = null;

            // Configure the samplegrabber
            hr = sampleGrabber.SetCallback(this, 1);
            DsError.ThrowExceptionForHR(hr);
        }

        private void SaveSizeInfo(ISampleGrabber sampleGrabber)
        {
            int hr;

            // Get the media type from the SampleGrabber
            AMMediaType media = new AMMediaType();

            hr = sampleGrabber.GetConnectedMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            if ((media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero))
            {
                throw new NotSupportedException("Unknown Grabber Media Format");
            }

            // Grab the size info
            VideoInfoHeader videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(media.formatPtr, typeof(VideoInfoHeader));
            m_videoWidth = videoInfoHeader.BmiHeader.Width;
            m_videoHeight = videoInfoHeader.BmiHeader.Height;
            m_stride = m_videoWidth * (videoInfoHeader.BmiHeader.BitCount / 8);

            DsUtils.FreeAMMediaType(media);
        }

        // Set the video window within the control specified by hControl
        private void ConfigVideoWindow(Control hControl)
        {
            int hr;
            IVideoWindow ivw = m_FilterGraph as IVideoWindow;

            // Set the parent
            hr = ivw.put_Owner(hControl.Handle);
            DsError.ThrowExceptionForHR(hr);

            // Turn off captions, etc
            hr = ivw.put_WindowStyle(WindowStyle.Overlapped);
            DsError.ThrowExceptionForHR(hr);

            // Yes, make it visible
            hr = ivw.put_Visible(OABool.True);
            DsError.ThrowExceptionForHR(hr);

            hr = ivw.put_MessageDrain(hControl.Handle);
            DsError.ThrowExceptionForHR(hr);

            // Move to upper left corner
            Rectangle rc = hControl.ClientRectangle;

            if (((float)rc.Width) / ((float)rc.Height) > ((float)m_videoWidth) / ((float)m_videoHeight))
            {
                hr = ivw.SetWindowPosition(0, 0, rc.Right, rc.Bottom);
                DsError.ThrowExceptionForHR(hr);
            }
            else
            {
                int y = (rc.Height - rc.Width * m_videoHeight / m_videoWidth) / 2;
                hr = ivw.SetWindowPosition(0, y, rc.Right, rc.Bottom - 2 * y);
                DsError.ThrowExceptionForHR(hr);
            }
        }

        /// <summary> Shut down capture </summary>
        private void CloseInterfaces()
        {
            int hr;

            try
            {
                if (m_FilterGraph != null)
                {
                    IMediaControl mediaCtrl = m_FilterGraph as IMediaControl;

                    // Stop the graph
                    hr = mediaCtrl.Stop();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (m_FilterGraph != null)
            {
                Marshal.ReleaseComObject(m_FilterGraph);
                m_FilterGraph = null;
            }

            if (m_VidControl != null)
            {
                Marshal.ReleaseComObject(m_VidControl);
                m_VidControl = null;
            }
            
            if (m_VideoControl != null)
            {
                Marshal.ReleaseComObject(m_VideoControl);
                m_VideoControl = null;
            }

            if (m_pinStill != null)
            {
                Marshal.ReleaseComObject(m_pinStill);
                m_pinStill = null;
            }
        }

        /// <summary> sample callback, NOT USED. </summary>
        int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample)
        {
            Marshal.ReleaseComObject(pSample);
            return 0;
        }

        /// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>
        int ISampleGrabberCB.BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
        {
            m_ipBuffer = Marshal.AllocCoTaskMem(Math.Abs(m_stride) * m_videoHeight);

            // Note that we depend on only being called once per call to Click.  Otherwise
            // a second call can overwrite the previous image.
            if (BufferLen != Math.Abs(m_stride) * m_videoHeight)
            {
                Console.WriteLine("Incorrect buffer length");
                return 0;
            }

            if (m_ipBuffer != IntPtr.Zero)
            {
                // Save the buffer
                CopyMemory(m_ipBuffer, pBuffer, BufferLen);

                // Picture is ready.
                m_PictureReady.Set();

                Bitmap b = new Bitmap(Width, Height, Stride, PixelFormat.Format24bppRgb, m_ipBuffer);
                b.RotateFlip(RotateFlipType.RotateNoneFlipY);

                if (snapshotCb != null)
                {
                    snapshotCb(b);
                }

                SnapshotReceived?.Invoke(b, null);
            }
            else
            {
                Console.WriteLine("Unitialized buffer");
            }

            return 0;
        }

        /// <summary>
        /// Get the image from the Still pin.  The returned image can turned into a bitmap with
        /// Bitmap b = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, m_ip);
        /// If the image is upside down, you can fix it with
        /// b.RotateFlip(RotateFlipType.RotateNoneFlipY);
        /// </summary>
        public void Snapshot()
        {
            int hr;

            // get ready to wait for new image
            m_PictureReady.Reset();

            try
            {
                // If we are using a still pin, ask for a picture
                if (m_VidControl != null)
                {
                    // Tell the camera to send an image
                    hr = m_VidControl.SetMode(m_pinStill, VideoControlFlags.Trigger);
                    DsError.ThrowExceptionForHR(hr);
                }

                // Start waiting
                if (!m_PictureReady.WaitOne(5000, false))
                {
                    throw new Exception("Timeout waiting to get picture");
                }
            }
            catch
            {
                throw;
            }

            return;
        }

        public void SetCallback(Action<Image> cb)
        {
            snapshotCb = cb;
        }

        private static AMMediaType GetMediaType(IPin pinOutput, int width, int height, int fps)
        {
            int hr = 0;
            AMMediaType mediaType = null;
            IntPtr pSCC = IntPtr.Zero;

            try
            {
                IAMStreamConfig videoStreamConfig = pinOutput as IAMStreamConfig;
                hr = videoStreamConfig.SetFormat(null);
                DsError.ThrowExceptionForHR(hr);

                int piCount = 0;
                int piSize = 0;

                hr = videoStreamConfig.GetNumberOfCapabilities(out piCount, out piSize);
                DsError.ThrowExceptionForHR(hr);

                for (int i = 0; i < piCount; i++)
                {
                    pSCC = Marshal.AllocCoTaskMem(piSize);
                    videoStreamConfig.GetStreamCaps(i, out mediaType, pSCC);
                    Resolution resolution = GetResolutionForMediaType(mediaType, fps);

                    if (resolution.Width == width && resolution.Height == height)
                    {
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                // clean up
                Marshal.FreeCoTaskMem(pSCC);
            }

            return mediaType;
        }
        
        public static int GetDeviceIndexByName(string deviceName)
        {
            // Get the collection of video devices
            DsDevice[] capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            for (int i = 0; i < capDevices.Length; i++)
            {
                if (capDevices[i].Name == deviceName)
                {
                    return i;
                }
            }

            return -1;
        }

        public static List<Resolution> GetResolutionsByDeviceIndex(int DeviceIndex)
        {
            DsDevice[] capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            IPin pinOutput;
            IBaseFilter capFilter = null;
            IFilterGraph2 filterGraph = new FilterGraph() as IFilterGraph2;
            int hr = 0;

            // add the video input device
            hr = filterGraph.AddSourceFilterForMoniker(capDevices[DeviceIndex].Mon, null, capDevices[DeviceIndex].Name, out capFilter);
            DsError.ThrowExceptionForHR(hr);

            // Find the capture pin
            pinOutput = DsFindPin.ByCategory(capFilter, PinCategory.Capture, 0);

            return GetResolutions(pinOutput);
        }
        
        public static List<Resolution> GetResolutions(IPin pinOutput)
        {
            int hr = 0;
            List<Resolution> resolutions = new List<Resolution>();
            AMMediaType mediaType = null;
            IntPtr pSCC = IntPtr.Zero;

            try
            {
                IAMStreamConfig videoStreamConfig = pinOutput as IAMStreamConfig;
                hr = videoStreamConfig.SetFormat(null);
                DsError.ThrowExceptionForHR(hr);

                int piCount = 0;
                int piSize = 0;

                hr = videoStreamConfig.GetNumberOfCapabilities(out piCount, out piSize);
                DsError.ThrowExceptionForHR(hr);

                for (int i = 0; i < piCount; i++)
                {
                    pSCC = Marshal.AllocCoTaskMem(piSize);
                    videoStreamConfig.GetStreamCaps(i, out mediaType, pSCC);
                    Resolution resolution = GetResolutionForMediaType(mediaType, 1);

                    if (resolution.Width > 0 && resolution.Height > 0)
                    {
                        resolutions.Add(resolution);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                // clean up
                Marshal.FreeCoTaskMem(pSCC);
                DsUtils.FreeAMMediaType(mediaType);
            }

            return resolutions;
        }

        private static Resolution GetResolutionForMediaType(AMMediaType mediaType, int fps)
        {
            Resolution resolution = new Resolution(0, 0);

            if (mediaType.formatType == FormatType.VideoInfo)
            {
                VideoInfoHeader videoInfoHeader = new VideoInfoHeader();
                Marshal.PtrToStructure(mediaType.formatPtr, videoInfoHeader);

                if (mediaType.subType == MediaSubType.MJPG && videoInfoHeader.AvgTimePerFrame * fps <= 10000000)
                {
                    resolution = new Resolution(videoInfoHeader.BmiHeader.Width, videoInfoHeader.BmiHeader.Height);
                }
            }

            if (mediaType.formatType == FormatType.VideoInfo2)
            {
                VideoInfoHeader2 videoInfoHeader = new VideoInfoHeader2();
                Marshal.PtrToStructure(mediaType.formatPtr, videoInfoHeader);

                if (mediaType.subType == MediaSubType.MJPG && videoInfoHeader.AvgTimePerFrame * fps <= 10000000)
                {
                    resolution = new Resolution(videoInfoHeader.BmiHeader.Width, videoInfoHeader.BmiHeader.Height);
                }
            }

            return resolution;
        }
    }
}
