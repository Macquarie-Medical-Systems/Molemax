using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using HiQPdf;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Molemax.App.Core
{
    public class PDFHandler
    {
        #region Leadtools
        //public static void GeneratePDF(string source, string destination)
        //{
        //    DocumentConverter converter = new DocumentConverter();
        //    int firstPage = 1;
        //    int lastPage = -1;

        //    DocumentConverterJobData jobData = new DocumentConverterJobData
        //    {
        //        InputDocumentFileName = source,
        //        Document = null,
        //        InputDocumentFirstPageNumber = firstPage,
        //        InputDocumentLastPageNumber = lastPage,
        //        DocumentFormat = DocumentFormat.Pdf,
        //        RasterImageFormat = RasterImageFormat.Unknown,
        //        RasterImageBitsPerPixel = 24,
        //        OutputDocumentFileName = destination,
        //        AnnotationsMode = DocumentConverterAnnotationsMode.None,
        //        OutputAnnotationsFileName = null,
        //        JobName = "MMSJob",
        //        UserData = null,
        //        InputAnnotationsFileName = null,
        //    };

        //    var job = converter.Jobs.CreateJob(jobData);

        //    converter.Jobs.RunJob(job);

        //    if (job.Errors.Count > 0)
        //    {
        //        throw new Exception(string.Format("Operation: {0} - Error: {1}", job.Errors[0].Operation, job.Errors[0].Error));
        //    }

        //    HandleOutputFiles(job);

        //    if (converter != null)
        //        converter.Dispose();
        //}

        //private static void HandleOutputFiles(DocumentConverterJob job)
        //{
        //    string[] OutputFiles;
        //    string[] OutputDocumentFiles;

        //    if (job.Status != DocumentConverterJobStatus.Aborted)
        //    {
        //        // Copy the output files to job.OutputFiles so the user can get them
        //        OutputFiles = new string[job.OutputFiles.Count];
        //        job.OutputFiles.CopyTo(OutputFiles, 0);

        //        // Copy these subsets also
        //        if (job.OutputDocumentFiles != null)
        //        {
        //            OutputDocumentFiles = new string[job.OutputDocumentFiles.Count];
        //            job.OutputDocumentFiles.CopyTo(OutputDocumentFiles, 0);
        //        }
        //    }
        //}

        //public static void MergePDF(string[] sources, string destination)
        //{

        //    if (File.Exists(destination))
        //    {
        //        File.Delete(destination);
        //    }


        //    try
        //    {
        //        InterlaceFiles(sources, destination);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //private static void MergeFiles(IReadOnlyList<string> sourceFileNames, string destinationFileName)
        //{
        //    var pdfFile = new PDFFile(sourceFileNames?.First());
        //    pdfFile.MergeWith(sourceFileNames?.Skip(1).ToArray(), destinationFileName);
        //}

        //private static void CleanUp(IEnumerable<string> fileNames)
        //{
        //    foreach (var fileName in fileNames)
        //    {
        //        if (File.Exists(fileName))
        //            File.Delete(fileName);
        //    }
        //}

        //public static void InterlaceFiles(string[] sources, string destination)
        //{
        //    try
        //    {
        //        MergeFiles(sources, destination);
        //    }
        //    finally
        //    {
        //        CleanUp(sources);
        //    }
        //}
        #endregion

        public static void GeneratePDF(string source, string destination)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set browser width
            htmlToPdfConverter.BrowserWidth = 1200;

            // set browser height if specified, otherwise use the default

            //htmlToPdfConverter.BrowserHeight = int.Parse(textBoxBrowserHeight.Text);

            // set HTML Load timeout
            htmlToPdfConverter.HtmlLoadedTimeout = 120;

            // set PDF page size and orientation
            htmlToPdfConverter.Document.PageSize = PdfPageSize.A4; //GetSelectedPageSize();
            htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Portrait;// GetSelectedPageOrientation();

            // set the PDF standard used by the document
            htmlToPdfConverter.Document.PdfStandard = PdfStandard.Pdf;

            // set PDF page margins
            htmlToPdfConverter.Document.Margins = new PdfMargins(5);

            // set whether to embed the true type font in PDF
            htmlToPdfConverter.Document.FontEmbedding = true;

            // set triggering mode; for WaitTime mode set the wait time before convert
            htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Auto;
            //switch (comboBoxTriggeringMode.SelectedItem.ToString())
            //{
            //    case "Auto":
            //        htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Auto;
            //        break;
            //    case "WaitTime":
            //        htmlToPdfConverter.TriggerMode = ConversionTriggerMode.WaitTime;
            //        htmlToPdfConverter.WaitBeforeConvert = int.Parse(textBoxWaitTime.Text);
            //        break;
            //    case "Manual":
            //        htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Manual;
            //        break;
            //    default:
            //        htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Auto;
            //        break;
            //}

            // set header and footer
            //SetHeader(htmlToPdfConverter.Document);
            //SetFooter(htmlToPdfConverter.Document);

            // set the document security
            //htmlToPdfConverter.Document.Security.OpenPassword = textBoxOpenPassword.Text;
            htmlToPdfConverter.Document.Security.AllowPrinting = true;

            // set the permissions password too if an open password was set
            //if (htmlToPdfConverter.Document.Security.OpenPassword != null && htmlToPdfConverter.Document.Security.OpenPassword != String.Empty)
            //    htmlToPdfConverter.Document.Security.PermissionsPassword = htmlToPdfConverter.Document.Security.OpenPassword + "_admin";

            //Cursor = Cursors.WaitCursor;

            // convert HTML to PDF
            string pdfFile = null;
            try
            {
                //string url = textBoxUrl.Text;
                //pdfFile = Application.StartupPath + @"\DemoOut\ConvertUrl.pdf";
                htmlToPdfConverter.ConvertUrlToFile(source, destination);

                //if (radioButtonConvertUrl.Checked)
                //{
                //    // convert URL
                //    string url = textBoxUrl.Text;
                //    pdfFile = Application.StartupPath + @"\DemoOut\ConvertUrl.pdf";

                //    // ConvertUrlToFile() is called to convert the html document and save the resulted PDF into a file on disk
                //    // Alternatively, ConvertUrlToMemory() can be called to save the resulted PDF in a buffer in memory
                //    htmlToPdfConverter.ConvertUrlToFile(url, pdfFile);
                //}
                //else
                //{
                //    // convert HTML code
                //    string htmlCode = textBoxHtmlCode.Text;
                //    string baseUrl = textBoxBaseUrl.Text;
                //    pdfFile = Application.StartupPath + @"\DemoOut\ConvertHtml.pdf";

                //    htmlToPdfConverter.ConvertHtmlToFile(htmlCode, baseUrl, pdfFile);
                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(String.Format("Conversion failed. {0}", ex.Message));
                return;
            }
            finally
            {
                //Cursor = Cursors.Arrow;
            }

            // open the PDF document
            try
            {
                System.Diagnostics.Process.Start(pdfFile);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(String.Format("Conversion succeeded but cannot open '{0}'. {1}", pdfFile, ex.Message));
            }
        }

        public static void MergeHtmlsToPDF(string[] sources, string destination)
        {
            // create an empty PDF document
            PdfDocument document = new PdfDocument();

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // add a page to document
            //PdfPage page1 = document.AddPage(PdfPageSize.A4, new PdfDocumentMargins(5), PdfPageOrientation.Portrait);

            PdfPage page;
            PdfHtml html;
            PdfLayoutInfo html1LayoutInfo;
            PointF location = PointF.Empty;

            foreach (string source in sources)
            {
                page = document.AddPage(PdfPageSize.A4, new PdfDocumentMargins(5), PdfPageOrientation.Portrait);
                html = new PdfHtml(source);
                html.WaitBeforeConvert = 2;
                html1LayoutInfo = page.Layout(html);
            }
            document.WriteToFile(destination);

            document.Close();

        }


        //private void SetHeader(PdfDocumentControl htmlToPdfDocument)
        //{
        //    // enable header display
        //    htmlToPdfDocument.Header.Enabled = checkBoxAddHeader.Checked;

        //    if (!htmlToPdfDocument.Header.Enabled)
        //        return;

        //    // set header height
        //    htmlToPdfDocument.Header.Height = 50;

        //    float pdfPageWidth = htmlToPdfDocument.PageOrientation == PdfPageOrientation.Portrait ?
        //                                htmlToPdfDocument.PageSize.Width : htmlToPdfDocument.PageSize.Height;

        //    float headerWidth = pdfPageWidth - htmlToPdfDocument.Margins.Left - htmlToPdfDocument.Margins.Right;
        //    float headerHeight = htmlToPdfDocument.Header.Height;

        //    // set header background color
        //    htmlToPdfDocument.Header.BackgroundColor = Color.WhiteSmoke;

        //    string headerImageFile = Application.StartupPath + @"\DemoFiles\Images\HiQPdfLogo.png";
        //    PdfImage logoHeaderImage = new PdfImage(5, 5, 40, Image.FromFile(headerImageFile));
        //    htmlToPdfDocument.Header.Layout(logoHeaderImage);

        //    // layout HTML in header
        //    PdfHtml headerHtml = new PdfHtml(50, 5, @"<span style=""color:Navy; font-family:Times New Roman; font-style:italic"">
        //                    Quickly Create High Quality PDFs with </span><a href=""http://www.hiqpdf.com"">HiQPdf</a>", null);
        //    headerHtml.FitDestHeight = true;
        //    headerHtml.FontEmbedding = checkBoxFontEmbedding.Checked;
        //    htmlToPdfDocument.Header.Layout(headerHtml);

        //    // create a border for header

        //    PdfRectangle borderRectangle = new PdfRectangle(1, 1, headerWidth - 2, headerHeight - 2);
        //    borderRectangle.LineStyle.LineWidth = 0.5f;
        //    borderRectangle.ForeColor = Color.Navy;
        //    htmlToPdfDocument.Header.Layout(borderRectangle);
        //}

        //private void SetFooter(PdfDocumentControl htmlToPdfDocument)
        //{
        //    // enable footer display
        //    htmlToPdfDocument.Footer.Enabled = checkBoxAddFooter.Checked;

        //    if (!htmlToPdfDocument.Footer.Enabled)
        //        return;

        //    // set footer height
        //    htmlToPdfDocument.Footer.Height = 50;

        //    // set footer background color
        //    htmlToPdfDocument.Footer.BackgroundColor = Color.WhiteSmoke;

        //    float pdfPageWidth = htmlToPdfDocument.PageOrientation == PdfPageOrientation.Portrait ?
        //                                htmlToPdfDocument.PageSize.Width : htmlToPdfDocument.PageSize.Height;

        //    float footerWidth = pdfPageWidth - htmlToPdfDocument.Margins.Left - htmlToPdfDocument.Margins.Right;
        //    float footerHeight = htmlToPdfDocument.Footer.Height;

        //    // layout HTML in footer
        //    PdfHtml footerHtml = new PdfHtml(5, 5, @"<span style=""color:Navy; font-family:Times New Roman; font-style:italic"">
        //                    Quickly Create High Quality PDFs with </span><a href=""http://www.hiqpdf.com"">HiQPdf</a>", null);
        //    footerHtml.FitDestHeight = true;
        //    footerHtml.FontEmbedding = checkBoxFontEmbedding.Checked;
        //    htmlToPdfDocument.Footer.Layout(footerHtml);

        //    // add page numbering
        //    Font pageNumberingFont = new Font(new FontFamily("Times New Roman"), 8, GraphicsUnit.Point);
        //    //pageNumberingFont.Mea
        //    PdfText pageNumberingText = new PdfText(5, footerHeight - 12, "Page {CrtPage} of {PageCount}", pageNumberingFont);
        //    pageNumberingText.HorizontalAlign = PdfTextHAlign.Center;
        //    pageNumberingText.EmbedSystemFont = true;
        //    pageNumberingText.ForeColor = Color.DarkGreen;
        //    htmlToPdfDocument.Footer.Layout(pageNumberingText);

        //    string footerImageFile = Application.StartupPath + @"\DemoFiles\Images\HiQPdfLogo.png";
        //    PdfImage logoFooterImage = new PdfImage(footerWidth - 40 - 5, 5, 40, Image.FromFile(footerImageFile));
        //    htmlToPdfDocument.Footer.Layout(logoFooterImage);

        //    // create a border for footer
        //    PdfRectangle borderRectangle = new PdfRectangle(1, 1, footerWidth - 2, footerHeight - 2);
        //    borderRectangle.LineStyle.LineWidth = 0.5f;
        //    borderRectangle.ForeColor = Color.DarkGreen;
        //    htmlToPdfDocument.Footer.Layout(borderRectangle);
        //}

        //private PdfPageSize GetSelectedPageSize()
        //{
        //    switch (comboBoxPageSize.SelectedItem.ToString())
        //    {
        //        case "A0":
        //            return PdfPageSize.A0;
        //        case "A1":
        //            return PdfPageSize.A1;
        //        case "A10":
        //            return PdfPageSize.A10;
        //        case "A2":
        //            return PdfPageSize.A2;
        //        case "A3":
        //            return PdfPageSize.A3;
        //        case "A4":
        //            return PdfPageSize.A4;
        //        case "A5":
        //            return PdfPageSize.A5;
        //        case "A6":
        //            return PdfPageSize.A6;
        //        case "A7":
        //            return PdfPageSize.A7;
        //        case "A8":
        //            return PdfPageSize.A8;
        //        case "A9":
        //            return PdfPageSize.A9;
        //        case "ArchA":
        //            return PdfPageSize.ArchA;
        //        case "ArchB":
        //            return PdfPageSize.ArchB;
        //        case "ArchC":
        //            return PdfPageSize.ArchC;
        //        case "ArchD":
        //            return PdfPageSize.ArchD;
        //        case "ArchE":
        //            return PdfPageSize.ArchE;
        //        case "B0":
        //            return PdfPageSize.B0;
        //        case "B1":
        //            return PdfPageSize.B1;
        //        case "B2":
        //            return PdfPageSize.B2;
        //        case "B3":
        //            return PdfPageSize.B3;
        //        case "B4":
        //            return PdfPageSize.B4;
        //        case "B5":
        //            return PdfPageSize.B5;
        //        case "Flsa":
        //            return PdfPageSize.Flsa;
        //        case "HalfLetter":
        //            return PdfPageSize.HalfLetter;
        //        case "Ledger":
        //            return PdfPageSize.Ledger;
        //        case "Legal":
        //            return PdfPageSize.Legal;
        //        case "Letter":
        //            return PdfPageSize.Letter;
        //        case "Letter11x17":
        //            return PdfPageSize.Letter11x17;
        //        case "Note":
        //            return PdfPageSize.Note;
        //        default:
        //            return PdfPageSize.A4;
        //    }
        //}

        //private PdfPageOrientation GetSelectedPageOrientation()
        //{
        //    return (comboBoxPageOrientation.SelectedItem.ToString() == "Portrait") ?
        //        PdfPageOrientation.Portrait : PdfPageOrientation.Landscape;
        //}

        //private void ConvertUrlToPdf_Load(object sender, EventArgs e)
        //{
        //    comboBoxPageOrientation.SelectedItem = "Portrait";
        //    comboBoxPageSize.SelectedItem = "A4";

        //    panelEnterUrl.Visible = radioButtonConvertUrl.Checked;
        //    panelEnterHtmlCode.Visible = !radioButtonConvertUrl.Checked;

        //    comboBoxTriggeringMode.SelectedItem = "WaitTime";
        //    panelWaitTime.Visible = true;
        //}

        //private void radioButtonConvertUrl_CheckedChanged(object sender, EventArgs e)
        //{
        //    panelEnterUrl.Visible = radioButtonConvertUrl.Checked;
        //    panelEnterHtmlCode.Visible = !radioButtonConvertUrl.Checked;
        //}

        //private void radioButtonConvertHtmlCode_CheckedChanged(object sender, EventArgs e)
        //{
        //    panelEnterUrl.Visible = radioButtonConvertUrl.Checked;
        //    panelEnterHtmlCode.Visible = !radioButtonConvertUrl.Checked;
        //}

        //private void comboBoxTriggeringMode_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    panelWaitTime.Visible = comboBoxTriggeringMode.SelectedItem.ToString() == "WaitTime";
        //}



        #region convert pdf to image
        public static void ConvertPDFToImage(string pdfFile, string outputDir)
        {
            // create the PDF rasterizer
            PdfRasterizer pdfRasterizer = new PdfRasterizer();

            // set a demo serial number
            pdfRasterizer.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set the output images color space
            pdfRasterizer.ColorSpace = RasterImageColorSpace.Rgb;

            // set the rasterization resolution in DPI
            pdfRasterizer.DPI = 150;

            // the output directory for resulted images
            //string outputDir = Application.StartupPath + @"\DemoOut\PdfRasterizer";

            // the output TIFF file if the PDF is converted to a multipage TIFF image
            string outputTiffFile = System.IO.Path.Combine(outputDir, "pdfpages.tiff");

            //Cursor = Cursors.WaitCursor;
            try
            {
                // rasterize a range of pages of the PDF document and save the images to an output directory
                // the images can also be produced in memory using the RasterizeToImageObjects or RaisePageRasterizedEvent methods
                pdfRasterizer.RasterizeToImageFiles(pdfFile, 1, 0, outputDir, "page");

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Rasterization failed. {0}", ex.Message));
            }
        }


        #endregion

        public static void PrintPDF(string pdfFile)
        {
            int fromPdfPageNumber = 0;
            int toPdfPageNumber = 0;
            // create the PDF printer object
            PdfPrinter pdfPrinter = new PdfPrinter();
            PrintDialog dialog = new PrintDialog();
            dialog.AllowCurrentPage = true;
            dialog.AllowPrintToFile = true;
            dialog.AllowSomePages = true;

            if (dialog.ShowDialog()== DialogResult.OK)
            {
                pdfPrinter.PrinterSettings.PrinterName = dialog.PrinterSettings.PrinterName;

                if (dialog.PrinterSettings.FromPage>0 || dialog.PrinterSettings.ToPage>0)
                {
                    fromPdfPageNumber = dialog.PrinterSettings.FromPage;
                    toPdfPageNumber = dialog.PrinterSettings.ToPage;
                }

                pdfPrinter.PrinterSettings.Copies = dialog.PrinterSettings.Copies;

                pdfPrinter.PrinterSettings.Collate = dialog.PrinterSettings.Collate;

                pdfPrinter.PrintPdf(pdfFile, fromPdfPageNumber, toPdfPageNumber);

                MessageBox.Show("Report printed");
            }




            //// optionally enable the silent printing
            //pdfPrinter.SilentPrinting = true;

            //// select the printer
            //pdfPrinter.PrinterSettings.PrinterName = "My Printer Name";

            //// send the PDF to printer
           
        }

    }
}
