using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camera
{
    public partial class CaptureControl : UserControl
    {
        public event EventHandler SnapshotReceived;
        public Image SnapshotSource;

        private Capture capture;

        public CaptureControl()
        {
            InitializeComponent();
        }

        ~CaptureControl()
        {
            if (capture != null)
            {
                capture.Dispose();
            }
        }

        public void SetCamera(string CameraName, int VideoWidth, int VideoHeight)
        {
            try
            {
                capture = new Capture(CameraName, VideoWidth, VideoHeight, this);
                capture.SnapshotReceived += Capture_SnapshotReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        
        public void CloseCamera()
        {
            if (capture != null)
            {
                capture.Dispose();
            }
        }
        
        public void SetCallback(Action<Image> cb)
        {
            capture.SetCallback(cb);
        }

        public void Snapshot()
        {
            capture.Snapshot();
        }

        private void Capture_SnapshotReceived(object sender, EventArgs e)
        {
            // Call event handlers (External)
            SnapshotReceived?.Invoke(sender, e);
        }
    }
}
