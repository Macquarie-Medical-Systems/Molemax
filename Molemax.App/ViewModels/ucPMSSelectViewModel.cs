using Molemax.App.Core;
using Molemax.Repository;
using Molemax.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Molemax.App.ViewModels
{
    public class ucPMSSelectViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private List<SelectionImage> visitedImageList;
        private List<ImageHandler> makroHistoryList;
        private List<ImageHandler> mikroHistoryList;
        private List<ImageHandler> closeupHistoryList;
        private IEnumerable<Image> _dbImages
        {
            get { return _repository.Images.Get(); }
        }
        private IEnumerable<Timestamp> _dbTimestamps
        {
            get { return _repository.Timestamps.Get(); }
        }
        private IEnumerable<Makro> _dbMakros
        {
            get { return _repository.Makros.Get(); }
        }
        private IEnumerable<Closeup> _dbCloseups
        {
            get { return _repository.Closeups.Get(); }
        }
        private IEnumerable<Fup> _dbFups
        {
            get { return _repository.Fups.Get(); }
        }
        private IEnumerable<Mikro> _dbMikros
        {
            get { return _repository.Mikros.Get(); }
        }
        public REPORT_VISIT_OPTION VisitOption { get; set; }

        public DelegateCommand GoSelectCommand { get; set; }

        public DelegateCommand GoCancelCommand { get; set; }

        private ObservableCollection<VisitGroup> _visitGroupList;
        public ObservableCollection<VisitGroup> VisitGroupList
        {
            get { return _visitGroupList; }
            set { SetProperty(ref _visitGroupList, value); }
        }

        private IList _selectedVisitGroupList;
        public IList SelectedVisitGroupList
        {
            get { return _selectedVisitGroupList; }
            set { SetProperty(ref _selectedVisitGroupList, value); }
        }

        public bool KeepAlive => false;

        public ucPMSSelectViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings appSettings)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = appSettings;
            VisitGroupList = new ObservableCollection<VisitGroup>();
            SelectedVisitGroupList = new ObservableCollection<VisitGroup>();
            GoSelectCommand = new DelegateCommand(GoSelect);
            GoCancelCommand = new DelegateCommand(GoCancel);
            FillDataGrid();
        }

        private void GoCancel()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu);
        }

        private void FillDataGrid()
        {
            
            var groups = _dbImages.Where(i => i.patientId == GlobalValue.Instance.CurrentPatient.id).GroupBy(i => i.treatment).OrderByDescending(i=>i.Key).Select(i=> new { treatment = i.Key });

            foreach (var item in groups)
            {
                VisitGroup vg = new VisitGroup();
                vg.Date =  item.treatment.Value;
                vg.Images = _dbImages.Where(i => i.patientId == GlobalValue.Instance.CurrentPatient.id && i.treatment == vg.Date).Count();
                vg.MAC = _dbImages.Where(i => i.patientId == GlobalValue.Instance.CurrentPatient.id && i.treatment == vg.Date && i.kind == 1).Count();
                vg.CUP = _dbImages.Where(i => i.patientId == GlobalValue.Instance.CurrentPatient.id && i.treatment == vg.Date && i.kind == 3).Count();
                vg.ELM = _dbImages.Where(i => i.patientId == GlobalValue.Instance.CurrentPatient.id && i.treatment == vg.Date && i.kind == 2).Count();
                VisitGroupList.Add(vg);
            }
        }

        protected virtual void GoSelect()
        {
            List<string> pdfList;
            string sDestPDFFullPath;
            string sOutputImageDir;

            Cursor.Current = Cursors.WaitCursor;

            var navigationParameters = new NavigationParameters();
            
            switch (VisitOption)
            {
                case REPORT_VISIT_OPTION.ALL_VISITS:
                    visitedImageList = CreateImageArray();
                    pdfList = new List<string>();
                    sDestPDFFullPath = Path.Combine(_applicationSetting.Temp, "TEST.PDF");
                    sOutputImageDir = Path.Combine(_applicationSetting.Temp, Guid.NewGuid().ToString());
                    if (visitedImageList.Count != 0)
                    {
                        //PDFHandler.CheckLicense();

                        foreach (var si in visitedImageList)
                        {
                            makroHistoryList = new List<ImageHandler>();
                            mikroHistoryList = new List<ImageHandler>();
                            closeupHistoryList = new List<ImageHandler>();

                            if (si.Makro != null && si.CloseUp != null && si.Mikro != null)
                            {
                                GetMikroHistoryList(si, ref mikroHistoryList);
                                GetMakroHistoryList(si, ref makroHistoryList);
                                GetCloseUpHistoryList(si, ref closeupHistoryList);

                                string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                                string sCloseUpHtmlFullPath = GenerateHtml(si, closeupHistoryList, KIND_ENUM.KIND_CLOSEUP, "008.dat");
                                string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                                pdfList.Add(sMikroHtmlFullPath);
                                pdfList.Add(sCloseUpHtmlFullPath);
                                pdfList.Add(sMakroHtmlFullPath);
                            }

                            if (si.Makro != null && si.CloseUp != null && si.Mikro == null)
                            {
                                GetMakroHistoryList(si, ref makroHistoryList);
                                GetCloseUpHistoryList(si, ref closeupHistoryList);

                                string sCloseUpHtmlFullPath = GenerateHtml(si, closeupHistoryList, KIND_ENUM.KIND_CLOSEUP, "008.dat");
                                string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                                pdfList.Add(sCloseUpHtmlFullPath);
                                pdfList.Add(sMakroHtmlFullPath);
                            }

                            if (si.Makro != null && si.CloseUp == null && si.Mikro != null)
                            {
                                GetMikroHistoryList(si, ref mikroHistoryList);
                                GetMakroHistoryList(si, ref makroHistoryList);

                                string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                                string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                                pdfList.Add(sMikroHtmlFullPath);
                                pdfList.Add(sMakroHtmlFullPath);
                            }

                            if (si.Makro != null && si.CloseUp == null && si.Mikro == null)
                            {
                                GetMakroHistoryList(si, ref makroHistoryList);

                                string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                                pdfList.Add(sMakroHtmlFullPath);
                            }

                            if (si.Makro == null && si.CloseUp == null && si.Mikro != null)
                            {
                                GetMikroHistoryList(si, ref mikroHistoryList);

                                string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                                pdfList.Add(sMikroHtmlFullPath);
                            }

                        }

                        if (pdfList.Count > 0)
                            PDFHandler.MergeHtmlsToPDF(pdfList.ToArray(), sDestPDFFullPath);

                        if (!Directory.Exists(sOutputImageDir))
                            Directory.CreateDirectory(sOutputImageDir);

                        PDFHandler.ConvertPDFToImage(sDestPDFFullPath, sOutputImageDir);

                        if (Directory.Exists(sOutputImageDir))
                        {
                            DirectoryInfo di = new DirectoryInfo(sOutputImageDir);
                            FileInfo[] pdfImageList = di.GetFiles();
                            if (pdfImageList.Count() > 0)
                            {
                                navigationParameters.Add(Constants.ParaFile, sDestPDFFullPath);
                                navigationParameters.Add(Constants.ParaImageList, pdfImageList);
                                navigationParameters.Add(Constants.FromForm, UserControlNames.PMSSelect);
                                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Print, navigationParameters);
                            }
                        }
                    }
                    break;
                case REPORT_VISIT_OPTION.SELECT_VISITS:
                    pdfList = new List<string>();
                    sDestPDFFullPath = Path.Combine(_applicationSetting.Temp, "TEST.PDF");
                    sOutputImageDir = Path.Combine(_applicationSetting.Temp, Guid.NewGuid().ToString());
                    visitedImageList = CreateImageArray();
                    foreach (VisitGroup item in SelectedVisitGroupList)
                    {
                        var selectedVisitedImageList = visitedImageList.Where(i => i.Treatment == item.Date).ToList<SelectionImage>();
                        if (selectedVisitedImageList.Count != 0)
                        {
                            foreach (var si in selectedVisitedImageList)
                            {
                                makroHistoryList = new List<ImageHandler>();
                                mikroHistoryList = new List<ImageHandler>();
                                closeupHistoryList = new List<ImageHandler>();

                                if (si.Makro != null && si.CloseUp != null && si.Mikro != null)
                                {
                                    GetMikroHistoryList(si, ref mikroHistoryList);
                                    GetMakroHistoryList(si, ref makroHistoryList);
                                    GetCloseUpHistoryList(si, ref closeupHistoryList);

                                    string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                                    string sCloseUpHtmlFullPath = GenerateHtml(si, closeupHistoryList, KIND_ENUM.KIND_CLOSEUP, "008.dat");
                                    string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                                    pdfList.Add(sMikroHtmlFullPath);
                                    pdfList.Add(sCloseUpHtmlFullPath);
                                    pdfList.Add(sMakroHtmlFullPath);
                                }

                                if (si.Makro != null && si.CloseUp != null && si.Mikro == null)
                                {
                                    GetMakroHistoryList(si, ref makroHistoryList);
                                    GetCloseUpHistoryList(si, ref closeupHistoryList);

                                    string sCloseUpHtmlFullPath = GenerateHtml(si, closeupHistoryList, KIND_ENUM.KIND_CLOSEUP, "008.dat");
                                    string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                                    pdfList.Add(sCloseUpHtmlFullPath);
                                    pdfList.Add(sMakroHtmlFullPath);
                                }

                                if (si.Makro != null && si.CloseUp == null && si.Mikro != null)
                                {
                                    GetMikroHistoryList(si, ref mikroHistoryList);
                                    GetMakroHistoryList(si, ref makroHistoryList);

                                    string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                                    string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                                    pdfList.Add(sMikroHtmlFullPath);
                                    pdfList.Add(sMakroHtmlFullPath);
                                }

                                if (si.Makro != null && si.CloseUp == null && si.Mikro == null)
                                {
                                    GetMakroHistoryList(si, ref makroHistoryList);

                                    string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                                    pdfList.Add(sMakroHtmlFullPath);
                                }

                                if (si.Makro == null && si.CloseUp == null && si.Mikro != null)
                                {
                                    GetMikroHistoryList(si, ref mikroHistoryList);

                                    string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                                    pdfList.Add(sMikroHtmlFullPath);
                                }

                            }
                        }
                    }
                    if (pdfList.Count > 0)
                        PDFHandler.MergeHtmlsToPDF(pdfList.ToArray(), sDestPDFFullPath);

                    if (!Directory.Exists(sOutputImageDir))
                        Directory.CreateDirectory(sOutputImageDir);

                    PDFHandler.ConvertPDFToImage(sDestPDFFullPath, sOutputImageDir);

                    if (Directory.Exists(sOutputImageDir))
                    {
                        DirectoryInfo di = new DirectoryInfo(sOutputImageDir);
                        FileInfo[] pdfImageList = di.GetFiles();
                        if (pdfImageList.Count() > 0)
                        {
                            navigationParameters.Add(Constants.ParaFile, sDestPDFFullPath);
                            navigationParameters.Add(Constants.ParaImageList, pdfImageList);
                            navigationParameters.Add(Constants.FromForm, UserControlNames.PMSSelect);
                            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Print, navigationParameters);
                        }
                    }
                    break;
                case REPORT_VISIT_OPTION.SELECT_INDIVIDUAL:
                    navigationParameters = new NavigationParameters();
                    navigationParameters.Add(Constants.FromForm, UserControlNames.PMSSelect);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PrintSelection, navigationParameters);
                    break;
            }


            Cursor.Current = Cursors.Default;
        }

        private void GetMikroHistoryList(SelectionImage si, ref List<ImageHandler> mikroHistoryList)
        {
            int? t_fupId = _dbMikros.Where(mi => mi.id == si.Mikro.Id).SingleOrDefault().fupId;
            int? t_imageId = _dbMikros.Where(mi => mi.id == si.Mikro.Id).SingleOrDefault().imageId;
            int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
            int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;


            if (fupId != 0)
            {
                //get image Id that beginning of history
                var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                //get all fups belong to the first image
                var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                                                                                                 //get all closeup image id belong to the fist image
                var hisImageIdList = _dbMikros.Where(i => fupList.Contains(i.fupId.Value)).Select(i => i.imageId).ToList();
                hisImageIdList.Add(firstHisImageId);

                //get information from image table and convert it to ObservableCollection list
                mikroHistoryList = _dbImages.Join(_dbTimestamps, i => i.tsId, ts => ts.id, (x, y) => new { image = x, ts = y })
                    .Where(i => hisImageIdList.Contains(i.image.id))
                    .OrderByDescending(i => i.ts.id)
                    .Select(i => new ImageHandler
                    {
                        ImageId = i.image.id,
                        Loctext = i.image.loctext,
                        CreateDate = i.ts.date_created.ToString("d"),
                        Image = new BitmapImage(new Uri(i.image.defpath + "\\" + i.image.imgname)),
                    }).ToList<ImageHandler>();

            }
        }

        private void GetMakroHistoryList(SelectionImage si, ref List<ImageHandler> makroHistoryList)
        {
            int? t_fupId = _dbMakros.Where(m => m.id == si.Makro.Id).SingleOrDefault().fupId;
            int? t_imageId = _dbMakros.Where(m => m.id == si.Makro.Id).SingleOrDefault().imageId;
            int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
            int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;


            if (fupId != 0)
            {
                //get image Id that beginning of history
                var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                //get all fups belong to the first image
                var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                                                                                                 //get all makro image id belong to the fist image
                var hisImageIdList = _dbMakros.Where(i => fupList.Contains(i.fupId.Value)).Select(i => i.imageId).ToList();
                hisImageIdList.Add(firstHisImageId);

                //get information from image table and convert it to ObservableCollection list
                makroHistoryList = _dbImages.Join(_dbTimestamps, i => i.tsId, ts => ts.id, (x, y) => new { image = x, ts = y })
                    .Where(i => hisImageIdList.Contains(i.image.id))
                    .OrderByDescending(i => i.ts.id)
                    .Select(i => new ImageHandler
                    {
                        ImageId = i.image.id,
                        Loctext = i.image.loctext,
                        CreateDate = i.ts.date_created.ToString("d"),
                        Image = new BitmapImage(new Uri(i.image.defpath + "\\" + i.image.imgname)),
                    }).ToList<ImageHandler>();
            }
        }

        private void GetCloseUpHistoryList(SelectionImage si, ref List<ImageHandler> closeupHistoryList)
        {
            int? t_fupId = _dbCloseups.Where(c => c.id == si.CloseUp.Id).SingleOrDefault().fupId;
            int? t_imageId = _dbCloseups.Where(c => c.id == si.CloseUp.Id).SingleOrDefault().imageId;
            int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
            int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;

            if (fupId != 0)
            {
                //get image Id that beginning of history
                var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                //get all fups belong to the first image
                var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                                                                                                 //get all closeup image id belong to the fist image
                var hisImageIdList = _dbCloseups.Where(i => fupList.Contains(i.fupId.Value)).Select(i => i.imageId).ToList();
                hisImageIdList.Add(firstHisImageId);

                //get information from image table and convert it to ObservableCollection list
                closeupHistoryList = _dbImages.Join(_dbTimestamps, i => i.tsId, ts => ts.id, (x, y) => new { image = x, ts = y })
                    .Where(i => hisImageIdList.Contains(i.image.id))
                    .OrderByDescending(i => i.ts.id)
                    .Select(i => new ImageHandler
                    {
                        ImageId = i.image.id,
                        Loctext = i.image.loctext,
                        CreateDate = i.ts.date_created.ToString("d"),
                        Image = new BitmapImage(new Uri(i.image.defpath + "\\" + i.image.imgname)),
                    }).ToList<ImageHandler>();
            }
        }



        //check frmPrint form, ddImageObject2HTMLPMS function
        private string GenerateHtml(SelectionImage si, List<ImageHandler> historyList, KIND_ENUM imageKind, string sTemplateFile = "001.dat")
        {
            string sContent;

            var sfileId = (Guid.NewGuid()).ToString();
            var shtmlFile = $"{sfileId}.html";
            var spdfFils = $"{sfileId}.pdf";
            var shtmlFileFullPath = Path.Combine(_applicationSetting.Temp, shtmlFile);
            //var spdfFilsFullPath = Path.Combine(_applicationSetting.Temp, spdfFils);

            if (!Directory.Exists(_applicationSetting.Temp))
                Directory.CreateDirectory(_applicationSetting.Temp);

            if (File.Exists(shtmlFileFullPath))
                File.Delete(shtmlFileFullPath);
            File.Copy(@"C:\Projects\Molemax\Molemax.App\Templates\008.dat", shtmlFileFullPath);

            sContent = File.ReadAllText(shtmlFileFullPath);

            sContent = UpdateFields(sContent, "%%APP_TITLE%%", "MoleMax HD");
            sContent = AddPatientInfoToHTML(sContent);
            sContent = UpdateFields(sContent, "%%CLINIC%%", "Sydney skin cancer practice");
            sContent = UpdateFields(sContent, "%%CLINICADDRESS%%", "Test address (Sydney Skin Cancer Practice");
            sContent = UpdateFields(sContent, "%%PHONE%%", "Phone: " + "Test phone (02 93456678)");
            sContent = UpdateFields(sContent, "%%EMAIL%%", "Mail: " + "Test mail (skinhealth@sydney.com.au)");
            sContent = UpdateFields(sContent, "%%WEB%%", "Web: " + "Test web (www.skinhealth.com.au");
            sContent = UpdateFields(sContent, "%%BUSINESSNAME%%", "Test (ANB 41 824753 556)");


            sContent = AddImgInfo2HTML(sContent, si, historyList, imageKind);

            sContent = UpdateFields(sContent, "%%PAGE_TITLE%%", $"{GlobalValue.Instance.CurrentPatient.firstname} {GlobalValue.Instance.CurrentPatient.lastname}");
            sContent = UpdateFields(sContent, "%%DATE%%", $"{DateTime.Now.ToString("MM/dd/yyyy")}");
            
            sContent = UpdateFields(sContent, "%%HEADER_1%%", $"{GlobalValue.Instance.CurrentPatient.firstname} {GlobalValue.Instance.CurrentPatient.lastname}");
            sContent = UpdateFields(sContent, "%%NAME%%", "g_tApp.Printing.strName");
            sContent = UpdateFields(sContent, "%%ADDRESS%%", "g_tApp.Printing.strAddress");

            sContent = UpdateFields(sContent, "%%PAGE_NO%%", "1");
            sContent = UpdateFields(sContent, "%%TOTAL_PAGES%%", "7");
            File.WriteAllText(shtmlFileFullPath, sContent);

            return shtmlFileFullPath;
        }

        private string AddImgInfo2HTML(string sContent, SelectionImage si, List<ImageHandler> historyList, KIND_ENUM imageKind)
        {
            string strDummyHTML;
            string strMakroHTML;
            string strCloseupHTML;
            string strMikroHTML;
            string originalImage;
            FileInfo fi;
            string newImage;
            System.Drawing.Image image;

            switch (imageKind)
            {
                case KIND_ENUM.KIND_MIKRO:
                    if (si.Makro != null)
                    {
                        originalImage = @"C:/Projects/Molemax/Molemax.App/Images/Dummy/Ken/" + si.Dummy.Id + ".bmp";
                        fi = new FileInfo(originalImage);
                        newImage = _applicationSetting.Temp + "\\" + fi.Name;
                        image = System.Drawing.Image.FromFile(originalImage);
                        //ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.Makro.FullPicRectangleX), (int)(si.Makro.FullPicRectangleY), (int)(si.Makro.FullPicRectangleWidth), (int)(si.Makro.FullPicRectangleHeight));
                        ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, 50, 50, 100, 100);
                        strDummyHTML = "<img src=" + newImage + " width =300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG01%%", strDummyHTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT01%%", "Date: test date");

                        if (si.Mikro.ContainerImageKind == KIND_ENUM.KIND_MAKRO)
                        {
                            originalImage = si.Makro.Image.UriSource.AbsolutePath;
                            fi = new FileInfo(originalImage);
                            newImage = _applicationSetting.Temp + "\\" + fi.Name;
                            image = System.Drawing.Image.FromFile(originalImage);
                            ImageHelpers.AddRectangleOrPoint(originalImage, newImage, false, (int)(si.Mikro.ImageAndRectangleXRatio * image.Width), (int)(si.Mikro.ImageAndRectangleYRatio * image.Height));
                            strMakroHTML = "<img src=" + newImage + " width=300 height=150 alt=''>";
                        }
                        else if (si.Mikro.ContainerImageKind == KIND_ENUM.KIND_CLOSEUP)
                        {
                            originalImage = si.Makro.Image.UriSource.AbsolutePath;
                            fi = new FileInfo(originalImage);
                            newImage = _applicationSetting.Temp + "\\" + fi.Name;
                            image = System.Drawing.Image.FromFile(originalImage);
                            ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.CloseUp.ImageAndRectangleXRatio * image.Width), (int)(si.CloseUp.ImageAndRectangleYRatio * image.Height), (int)(si.CloseUp.ImageAndRectangleWidthRatio * image.Width), (int)(si.CloseUp.ImageAndRectangleHeightRatio * image.Height));
                            strMakroHTML = "<img src=" + newImage + " width=300 height=150 alt=''>";
                        }
                        else
                        {
                            strMakroHTML = "<img src=" + si.Makro.Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";

                        }
                        sContent = UpdateFields(sContent, "%%IMGTAG11%%", strMakroHTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT11%%", "");
                    }
                    else
                    {
                        originalImage = @"C:/Projects/Molemax/Molemax.App/Images/Dummy/Ken/" + si.Dummy.Id + ".bmp";
                        fi = new FileInfo(originalImage);
                        newImage = _applicationSetting.Temp + "\\" + fi.Name;
                        image = System.Drawing.Image.FromFile(originalImage);
                        //ImageHelpers.AddRectangleOrPoint(originalImage, newImage, false, (int)(si.Mikro.FullPicPointX), (int)(si.Mikro.FullPicPointY));
                        ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, 50, 50, 100, 100);
                        strDummyHTML = "<img src=" + newImage + " width =300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG01%%", strDummyHTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT01%%", "Date: test date");
                    }

                    if (si.CloseUp != null)
                    {

                        originalImage = si.CloseUp.Image.UriSource.AbsolutePath;
                        fi = new FileInfo(si.CloseUp.Image.UriSource.AbsolutePath);
                        newImage = _applicationSetting.Temp + "\\" + fi.Name;
                        image = System.Drawing.Image.FromFile(originalImage);
                        ImageHelpers.AddRectangleOrPoint(originalImage, newImage, false, (int)(si.Mikro.ImageAndRectangleXRatio * image.Width), (int)(si.Mikro.ImageAndRectangleYRatio * image.Height));
                        strCloseupHTML = "<img src=" + newImage + " width=300 height=150 alt=''>";

                        sContent = UpdateFields(sContent, "%%IMGTAG21%%", strCloseupHTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT21%%", "");
                    }

                    strMikroHTML = "<img src=" + si.Mikro.Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG02%%", strMikroHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT02%%", "");

                    if (historyList != null && historyList.Count > 1)
                    {
                        var strMikroFollowUp1HTML = "<img src=" + historyList[1].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG12%%", strMikroFollowUp1HTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT12%%", "");

                        if (historyList.Count > 2)
                        {
                            var strMikroFollowUp2HTML = "<img src=" + historyList[2].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                            sContent = UpdateFields(sContent, "%%IMGTAG22%%", strMikroFollowUp2HTML);
                            sContent = UpdateFields(sContent, "%%IMGDAT22%%", "");
                        }
                    }
                    break;
                case KIND_ENUM.KIND_CLOSEUP:
                    originalImage = @"C:/Projects/Molemax/Molemax.App/Images/Dummy/Ken/" + si.Dummy.Id + ".bmp";
                    fi = new FileInfo(originalImage);
                    newImage = _applicationSetting.Temp + "\\" + fi.Name;
                    image = System.Drawing.Image.FromFile(originalImage);
                    //ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.Makro.FullPicRectangleX), (int)(si.Makro.FullPicRectangleY), (int)(si.Makro.FullPicRectangleWidth), (int)(si.Makro.FullPicRectangleHeight));
                    ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, 50, 50, 100, 100);
                    strDummyHTML = "<img src=" + newImage + " width =300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG01%%", strDummyHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT01%%", "Date: test date");


                    originalImage = si.Makro.Image.UriSource.AbsolutePath;
                    fi = new FileInfo(originalImage);
                    newImage = _applicationSetting.Temp + "\\" + fi.Name;
                    image = System.Drawing.Image.FromFile(originalImage);
                    ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.CloseUp.ImageAndRectangleXRatio * image.Width), (int)(si.CloseUp.ImageAndRectangleYRatio * image.Height), (int)(si.CloseUp.ImageAndRectangleWidthRatio * image.Width), (int)(si.CloseUp.ImageAndRectangleHeightRatio * image.Height));
                    strMakroHTML = "<img src=" + newImage + " width=300 height=150 alt=''>";


                    sContent = UpdateFields(sContent, "%%IMGTAG11%%", strMakroHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT11%%", "");


                    strCloseupHTML = "<img src=" + si.CloseUp.Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG02%%", strCloseupHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT02%%", "");

                    if (historyList != null && historyList.Count > 1)
                    {
                        var strCloseupFollowUp1HTML = "<img src=" + historyList[1].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG12%%", strCloseupFollowUp1HTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT12%%", "");

                        if (historyList.Count > 2)
                        {
                            var strCloseupFollowUp2HTML = "<img src=" + historyList[2].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                            sContent = UpdateFields(sContent, "%%IMGTAG22%%", strCloseupFollowUp2HTML);
                            sContent = UpdateFields(sContent, "%%IMGDAT22%%", "");
                        }
                    }
                    break;
                case KIND_ENUM.KIND_MAKRO:
                    originalImage = @"C:/Projects/Molemax/Molemax.App/Images/Dummy/Ken/" + si.Dummy.Id + ".bmp";
                    fi = new FileInfo(originalImage);
                    newImage = _applicationSetting.Temp + "\\" + fi.Name;
                    image = System.Drawing.Image.FromFile(originalImage);
                    //ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.Makro.FullPicRectangleX), (int)(si.Makro.FullPicRectangleY), (int)(si.Makro.FullPicRectangleWidth), (int)(si.Makro.FullPicRectangleHeight));
                    ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, 50, 50, 100, 100);
                    strDummyHTML = "<img src=" + newImage + " width =300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG01%%", strDummyHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT01%%", "Date: test date");

                    strMakroHTML = "<img src=" + si.Makro.Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG02%%", strMakroHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT02%%", "");

                    if (historyList != null && historyList.Count > 1)
                    {
                        var strMakroFollowUp1HTML = "<img src=" + historyList[1].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG12%%", strMakroFollowUp1HTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT12%%", "");

                        if (historyList.Count > 2)
                        {
                            var strMakroFollowUp2HTML = "<img src=" + historyList[2].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                            sContent = UpdateFields(sContent, "%%IMGTAG22%%", strMakroFollowUp2HTML);
                            sContent = UpdateFields(sContent, "%%IMGDAT22%%", "");
                        }
                    }
                    break;
            }


            return sContent;
        }

        private string AddPatientInfoToHTML(string sContent)
        {
            //calculate patient age
            var birthdate = GlobalValue.Instance.CurrentPatient.birthdate;
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age))
            { 
               age--;
            }

            sContent = UpdateFields(sContent, "%%REPDATE%%", DateTime.Today.ToString("MM/dd/yyyy"));
            sContent = UpdateFields(sContent, "%%USER%%", "Test (Dr John Smith)");
            sContent = UpdateFields(sContent, "%%CLINIC%%", "Test (Sydney skin cancer Practice");
            sContent = UpdateFields(sContent, "%%PATNAME%%", $"{GlobalValue.Instance.CurrentPatient.title} {GlobalValue.Instance.CurrentPatient.lastname} {GlobalValue.Instance.CurrentPatient.firstname}");
            sContent = UpdateFields(sContent, "%%PATAGE%%", age.ToString());
            sContent = UpdateFields(sContent, "%%PATDOB%%", GlobalValue.Instance.CurrentPatient.birthdate.ToString("MM/dd/yyyy"));
            sContent = UpdateFields(sContent, "%%PATSEX%%", GlobalValue.Instance.CurrentPatient.sex);
            sContent = UpdateFields(sContent, "%%PATREC%%", GlobalValue.Instance.CurrentPatient.id.ToString());
            sContent = UpdateFields(sContent, "%%PATLVD%%", "Test (30/01/2021)");
            sContent = UpdateFields(sContent, "%%PATFUP%%", "---");
            return sContent;
        }
        private string UpdateFields(string sContent, string sFieldCode, string sValue)
        {
            return sContent.Replace(sFieldCode, sValue);
        }

        private object getMikroFup(SelectionImage si)
        {
            ImageHandler _selectedImage;
            List<ImageHandler> ImageHistoryList = new List<ImageHandler>();
            int? t_fupId = _dbMikros.Where(mi => mi.id == si.Mikro.Id).SingleOrDefault().fupId;
            int? t_imageId = _dbMikros.Where(mi => mi.id == si.Mikro.Id).SingleOrDefault().imageId;
            int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
            int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;
            _selectedImage = si.Mikro;

            if (fupId != 0)
            {
                //get image Id that beginning of history
                var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                //get all fups belong to the first image
                var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                                                                                                 //get all closeup image id belong to the fist image
                var hisImageIdList = _dbMikros.Where(i => fupList.Contains(i.fupId.Value)).Select(i => i.imageId).ToList();
                hisImageIdList.Add(firstHisImageId);

                //get information from image table and convert it to ObservableCollection list
                var tempImageList = _dbImages.Join(_dbTimestamps, i => i.tsId, ts => ts.id, (x, y) => new { image = x, ts = y })
                    .Where(i => hisImageIdList.Contains(i.image.id))
                    .OrderByDescending(i => i.ts.id)
                    .Select(i => new ImageHandler
                    {
                        ImageId = i.image.id,
                        Loctext = i.image.loctext,
                        CreateDate = i.ts.date_created.ToString("d"),
                        Image = new BitmapImage(new Uri(i.image.defpath + "\\" + i.image.imgname)),
                    });

                ImageHistoryList = new List<ImageHandler>(tempImageList);
            }

            return ImageHistoryList;
        }

        private List<ImageHandler> getCloseUpFup(SelectionImage si)
        {
            ImageHandler _selectedImage;
            List<ImageHandler> ImageHistoryList = new List<ImageHandler>();
            int? t_fupId = _dbCloseups.Where(c => c.id == si.CloseUp.Id).SingleOrDefault().fupId;
            int? t_imageId = _dbCloseups.Where(c => c.id == si.CloseUp.Id).SingleOrDefault().imageId;
            int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
            int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;
            _selectedImage = si.CloseUp;

            if (fupId != 0)
            {
                //get image Id that beginning of history
                var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                //get all fups belong to the first image
                var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                                                                                                 //get all closeup image id belong to the fist image
                var hisImageIdList = _dbCloseups.Where(i => fupList.Contains(i.fupId.Value)).Select(i => i.imageId).ToList();
                hisImageIdList.Add(firstHisImageId);

                //get information from image table and convert it to ObservableCollection list
                var tempImageList = _dbImages.Join(_dbTimestamps, i => i.tsId, ts => ts.id, (x, y) => new { image = x, ts = y })
                    .Where(i => hisImageIdList.Contains(i.image.id))
                    .OrderByDescending(i => i.ts.id)
                    .Select(i => new ImageHandler
                    {
                        ImageId = i.image.id,
                        Loctext = i.image.loctext,
                        CreateDate = i.ts.date_created.ToString("d"),
                        Image = new BitmapImage(new Uri(i.image.defpath + "\\" + i.image.imgname)),
                    });

                ImageHistoryList = new List<ImageHandler>(tempImageList);
            }

            return ImageHistoryList;
        }

        private List<ImageHandler> getMakroFup(SelectionImage si)
        {
            ImageHandler _selectedImage;
            List<ImageHandler> ImageHistoryList = new List<ImageHandler>();

            int? t_fupId = _dbMakros.Where(m => m.id == si.Makro.Id).SingleOrDefault().fupId;
            int? t_imageId = _dbMakros.Where(m => m.id == si.Makro.Id).SingleOrDefault().imageId;
            int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
            int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;
            _selectedImage = si.Makro;

            if (fupId != 0)
            {
                //get image Id that beginning of history
                var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                //get all fups belong to the first image
                var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                                                                                                 //get all makro image id belong to the fist image
                var hisImageIdList = _dbMakros.Where(i => fupList.Contains(i.fupId.Value)).Select(i => i.imageId).ToList();
                hisImageIdList.Add(firstHisImageId);

                //get information from image table and convert it to ObservableCollection list
                var tempImageList = _dbImages.Join(_dbTimestamps, i => i.tsId, ts => ts.id, (x, y) => new { image = x, ts = y })
                    .Where(i => hisImageIdList.Contains(i.image.id))
                    .OrderByDescending(i => i.ts.id)
                    .Select(i => new ImageHandler
                    {
                        ImageId = i.image.id,
                        Loctext = i.image.loctext,
                        CreateDate = i.ts.date_created.ToString("d"),
                        Image = new BitmapImage(new Uri(i.image.defpath + "\\" + i.image.imgname)),
                    });

                ImageHistoryList = new List<ImageHandler>(tempImageList);
            }

            return ImageHistoryList;
        }

        private void GetVisitImages(DateTime visitDate)
        {
            var imageList  = _dbImages.Where(i => i.treatment == visitDate && i.patientId == GlobalValue.Instance.CurrentPatient.id).OrderByDescending(i => i.treatment);
            foreach (var image in imageList)
            {

            }


        }

        private List<SelectionImage> CreateImageArray()
        {
            SelectionImage si;
            List<SelectionImage> returnList = new List<SelectionImage>();

            //get Max fup id and relative image id from fup and image table
            var maxfupList = _dbFups.Join(_dbImages, fup => fup.imageId, image => image.id, (fup, image) => new { fup, image })
                           .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                           .GroupBy(item => item.fup.imageId).Select(item => new
                            {
                                MaxFup = item.Max(i => i.fup.id),
                                ImageId = item.Key
                            }).ToList();

            //get makro records that does not have follow up
            var makroWithNoFupList = _dbMakros.Join(_dbImages, ma => ma.imageId, image => image.id, (makro, image) => new { makro, image })
                    .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id && item.makro.bms_id == 0)
                    .Where(item => item.makro.fupId == 0)
                    .Where(item => !maxfupList.Any(b => b.ImageId == item.makro.imageId)).ToList();

            //get makro records that has follow up
            var makroWithFupList = _dbMakros.Join(_dbImages, ma => ma.imageId, image => image.id, (makro, image) => new { makro, image })
                    .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id && item.makro.bms_id == 0)
                    .Where(item => maxfupList.Any(b => b.MaxFup == item.makro.fupId)).ToList();

            //get closeup records that does not have fupid
            var closeupWithNoFupList = _dbCloseups.Join(_dbImages, cu => cu.imageId, image => image.id, (closeup, image) => new { closeup, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => item.closeup.fupId == 0)
                .Where(item => !maxfupList.Any(b => b.ImageId == item.closeup.imageId)).ToList();

            //get closeup records that is in max fup list
            var closeupWithFupList = _dbCloseups.Join(_dbImages, cu => cu.imageId, image => image.id, (closeup, image) => new { closeup, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => maxfupList.Any(b => b.MaxFup == item.closeup.fupId)).ToList();

            //get mikro records that does not have fupid
            var mikroWithNoFupList = _dbMikros.Join(_dbImages, mi => mi.imageId, image => image.id, (mikro, image) => new { mikro, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => item.mikro.fupId == 0)
                .Where(item => !maxfupList.Any(b => b.ImageId == item.mikro.imageId)).ToList();

            //get mikro records that is in max fup list
            var mikroWithFupList = _dbMikros.Join(_dbImages, mi => mi.imageId, image => image.id, (mikro, image) => new { mikro, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => maxfupList.Any(b => b.MaxFup == item.mikro.fupId)).ToList();


            //final makro list
            var makroList = makroWithNoFupList.Concat(makroWithFupList).OrderByDescending(item => item.image.tsId).ToList();
            //final closeup list
            var closeupList = closeupWithNoFupList.Concat(closeupWithFupList).OrderByDescending(item => item.image.tsId).ToList();
            //final mikro list
            var mikroList = mikroWithNoFupList.Concat(mikroWithFupList).OrderByDescending(item => item.image.tsId).ToList();


            var macumiList = makroList.Join(closeupList, m => m.makro.id, c => c.closeup.makroId, (x, y) => new { makro = x, closeup = y })
                                   .Join(mikroList, mc => mc.closeup.closeup.id, mi => mi.mikro.closeupId, (x, y) => new { makro = x.makro, closeup = x.closeup, mikro = y }).ToList();

            var mamiList = makroList.Join(mikroList, ma => ma.makro.id, mi => mi.mikro.makroId, (x, y) => new { makro = x, mikro = y }).ToList();

            var macuList = makroList.Join(closeupList, m => m.makro.id, c => c.closeup.makroId, (x, y) => new { makro = x, closeup = y })
                         .Where(c => !mikroList.Select(b => b.mikro.closeupId).Contains(c.closeup.closeup.id)).ToList();

            var maList = makroList.Where(c => !closeupList.Select(b => b.closeup.makroId).Contains(c.makro.id))
                                  .Where(c => !mikroList.Select(b => b.mikro.makroId).Contains(c.makro.id)).ToList();
            var miList = mikroList.Where(c => c.mikro.makroId == 0 && c.mikro.closeupId == 0).ToList();


            foreach (var item in macumiList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.makro.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));
                si.Makro.FullPicRectangleX = item.makro.makro.X1 / 1000;
                si.Makro.FullPicRectangleY = item.makro.makro.Y1 / 1000;
                si.Makro.FullPicRectangleWidth = item.makro.makro.X2 / 1000;
                si.Makro.FullPicRectangleHeight = item.makro.makro.Y2 / 1000;

                si.CloseUp = new ImageHandler();
                si.CloseUp.Id = item.closeup.closeup.id;
                si.CloseUp.ImageId = item.closeup.closeup.imageId;
                si.CloseUp.Loctext = item.closeup.image.loctext;
                si.CloseUp.Kenpos = item.closeup.image.kenpos;
                si.CloseUp.Image = new BitmapImage(new Uri(item.closeup.image.defpath + "\\" + item.closeup.image.imgname));
                si.CloseUp.ImageAndRectangleXRatio = (double)item.closeup.closeup.X1 / (double)1000;
                si.CloseUp.ImageAndRectangleYRatio = (double)item.closeup.closeup.Y1 / (double)1000;
                si.CloseUp.ImageAndRectangleWidthRatio = (double)item.closeup.closeup.X2 / (double)1000;
                si.CloseUp.ImageAndRectangleHeightRatio = (double)item.closeup.closeup.Y2 / (double)1000;
                si.CloseUp.ContainerImageKind = KIND_ENUM.KIND_MAKRO;


                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.mikro.id;
                si.Mikro.ImageId = item.mikro.mikro.imageId;
                si.Mikro.Loctext = item.mikro.image.loctext;
                si.Mikro.Kenpos = item.mikro.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.mikro.image.defpath + "\\" + item.mikro.image.imgname));
                si.Mikro.FullPicPointX = item.mikro.mikro.X / 1000;
                si.Mikro.FullPicPointY = item.mikro.mikro.Y / 1000;
                si.Mikro.ImageAndRectangleXRatio = (double)item.mikro.mikro.X_Pic / (double)1000;
                si.Mikro.ImageAndRectangleYRatio = (double)item.mikro.mikro.Y_Pic / (double)1000;
                si.Mikro.ContainerImageKind = KIND_ENUM.KIND_CLOSEUP;

                si.Treatment = item.mikro.image.treatment.Value;
                returnList.Add(si);
            }

            foreach (var item in mamiList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.makro.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));
                si.Makro.FullPicRectangleX = item.makro.makro.X1 / 1000;
                si.Makro.FullPicRectangleY = item.makro.makro.Y1 / 1000;
                si.Makro.FullPicRectangleWidth = item.makro.makro.X2 / 1000;
                si.Makro.FullPicRectangleHeight = item.makro.makro.Y2 / 1000;

                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.mikro.id;
                si.Mikro.ImageId = item.mikro.mikro.imageId;
                si.Mikro.Loctext = item.mikro.image.loctext;
                si.Mikro.Kenpos = item.mikro.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.mikro.image.defpath + "\\" + item.mikro.image.imgname));
                si.Mikro.FullPicPointX = item.mikro.mikro.X / 1000;
                si.Mikro.FullPicPointY = item.mikro.mikro.Y / 1000;
                si.Mikro.ImageAndRectangleXRatio = (double)item.mikro.mikro.X_Pic / (double)1000;
                si.Mikro.ImageAndRectangleYRatio = (double)item.mikro.mikro.Y_Pic / (double)1000;
                si.Mikro.ContainerImageKind = KIND_ENUM.KIND_MAKRO;

                si.Treatment = item.mikro.image.treatment.Value;
                returnList.Add(si);
            }

            foreach (var item in macuList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.makro.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));
                si.Makro.FullPicRectangleX = item.makro.makro.X1 / 1000;
                si.Makro.FullPicRectangleY = item.makro.makro.Y1 / 1000;
                si.Makro.FullPicRectangleWidth = item.makro.makro.X2 / 1000;
                si.Makro.FullPicRectangleHeight = item.makro.makro.Y2 / 1000;

                si.CloseUp = new ImageHandler();
                si.CloseUp.Id = item.closeup.closeup.id;
                si.CloseUp.ImageId = item.closeup.closeup.imageId;
                si.CloseUp.Loctext = item.closeup.image.loctext;
                si.CloseUp.Kenpos = item.closeup.image.kenpos;
                si.CloseUp.Image = new BitmapImage(new Uri(item.closeup.image.defpath + "\\" + item.closeup.image.imgname));
                si.CloseUp.ImageAndRectangleXRatio = (double)item.closeup.closeup.X1 / (double)1000;
                si.CloseUp.ImageAndRectangleYRatio = (double)item.closeup.closeup.Y1 / (double)1000;
                si.CloseUp.ImageAndRectangleWidthRatio = (double)item.closeup.closeup.X2 / (double)1000;
                si.CloseUp.ImageAndRectangleHeightRatio = (double)item.closeup.closeup.Y2 / (double)1000;
                si.CloseUp.ContainerImageKind = KIND_ENUM.KIND_MAKRO;

                si.Treatment = item.closeup.image.treatment.Value;

                returnList.Add(si);
            }

            foreach (var item in maList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.id;
                si.Makro.ImageId = item.makro.imageId;
                si.Makro.Loctext = item.image.loctext;
                si.Makro.Kenpos = item.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.image.defpath + "\\" + item.image.imgname));
                si.Makro.FullPicRectangleX = item.makro.X1 / 1000;
                si.Makro.FullPicRectangleY = item.makro.Y1 / 1000;
                si.Makro.FullPicRectangleWidth = item.makro.X2 / 1000;
                si.Makro.FullPicRectangleHeight = item.makro.Y2 / 1000;

                si.Treatment = item.image.treatment.Value;

                returnList.Add(si);
            }

            foreach (var item in miList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.id;
                si.Mikro.ImageId = item.mikro.imageId;
                si.Mikro.Loctext = item.image.loctext;
                si.Mikro.Kenpos = item.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.image.defpath + "\\" + item.image.imgname));
                si.Mikro.FullPicPointX = item.mikro.X / 1000;
                si.Mikro.FullPicPointY = item.mikro.Y / 1000;
                si.Mikro.ImageAndRectangleXRatio = (double)item.mikro.X_Pic / (double)1000;
                si.Mikro.ImageAndRectangleYRatio = (double)item.mikro.Y_Pic / (double)1000;

                si.Treatment = item.image.treatment.Value;
                returnList.Add(si);
            }

            return returnList.OrderByDescending(i => i.Makro).ThenByDescending(i => i.CloseUp).ThenByDescending(i => i.Mikro).ToList<SelectionImage>();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //if (navigationContext.Parameters[Constants.FromForm] != null)
            //    fromForm = (string)navigationContext.Parameters[Constants.FromForm];
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

    }

    public class VisitGroup
    {
        public DateTime Date { get; set; }
        public int Images { get; set; }
        public int MAC { get; set; }
        public int CUP { get; set; }
        public int ELM { get; set; }
    }
}
