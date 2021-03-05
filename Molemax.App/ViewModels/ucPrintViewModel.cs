using Molemax.App.Core;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Molemax.App.ViewModels
{
    public class ucPrintViewModel: BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;

        public DelegateCommand GoUpdatePreviewCommand { get; set; }
        public DelegateCommand GoExportToPMSCommand { get; set; }
        public DelegateCommand GoPrintCommand { get; set; }
        public DelegateCommand GoCancelCommand { get; set; }

        private FileInfo[] pdfImageList;

        private string sPDFFullPath;

        private BitmapSource _pdfImage;
        public BitmapSource PDFImage
        {
            get { return _pdfImage; }
            set { SetProperty(ref _pdfImage, value); }
        }
        public bool KeepAlive => false;

        
        public ucPrintViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            GoUpdatePreviewCommand = new DelegateCommand(GoUpdatePreview);
            GoExportToPMSCommand = new DelegateCommand(GoExportToPMS);
            GoPrintCommand = new DelegateCommand(GoPrint);
            GoCancelCommand = new DelegateCommand(GoCancel);
        }

        private void GoCancel()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PMSSelect);
        }

        private void GoPrint()
        {
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.FileName = "Document";
            //dlg.DefaultExt = ".pdf";

            //System.Windows.Forms.DialogResult dr = dlg.ShowDialog();
            //if (dr == System.Windows.Forms.DialogResult.OK)
            //{

            //}
            PDFHandler.PrintPDF(sPDFFullPath);
        }

        private void GoExportToPMS()
        {
            throw new NotImplementedException();
        }

        private void GoUpdatePreview()
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.ParaImageList] != null)
            {
                pdfImageList = (FileInfo[])navigationContext.Parameters[Constants.ParaImageList];

                PDFImage = new BitmapImage(new Uri(pdfImageList[0].FullName));
            }

            if (navigationContext.Parameters[Constants.ParaFile] != null)
            {
                sPDFFullPath = (string)navigationContext.Parameters[Constants.ParaFile];
            }
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
