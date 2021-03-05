using Molemax.App.Core;
using Molemax.App.ViewModels;
using Molemax.App.Views;
using Molemax.Repository;
using Molemax.Repository.Sql;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Molemax.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    //initialize the splash screen and set it as the application main window
        //    var splashScreen = new frmSplash();
        //    this.MainWindow = splashScreen;
        //    splashScreen.Show();

        //    //in order to ensure the UI stays responsive, we need to
        //    //do the work on a different thread
        //    Task.Factory.StartNew(() =>
        //    {
        //        System.Threading.Thread.Sleep(3000);

        //        //once we're done we need to use the Dispatcher
        //        //to create and show the main window
        //        this.Dispatcher.Invoke(() =>
        //        {
        //            //initialize the main window, set it as the application main window
        //            //and close the splash screen
        //            var mainMenu = new frmMainMenu();
        //            this.MainWindow = mainMenu;
        //            mainMenu.Show();
        //            splashScreen.Close();
        //        });
        //    });
        //}
        protected override Window CreateShell()
        {
            return Container.Resolve<frmMainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ucTitle>();
            containerRegistry.RegisterForNavigation<ucPatient>();
            containerRegistry.RegisterForNavigation<ucMainMenu>();
            containerRegistry.RegisterForNavigation<ucExpress>();
            containerRegistry.RegisterForNavigation<ucAdminMainMenu>();
            containerRegistry.RegisterForNavigation<ucAdminLiveVideo>();
            containerRegistry.RegisterForNavigation<ucAdminLiveImage>();
            containerRegistry.RegisterForNavigation<ucAdminImageSelectionPreview>();
            containerRegistry.RegisterForNavigation<ucAdminImageSources>();
            containerRegistry.RegisterForNavigation<ucLiveVideo>();
            containerRegistry.RegisterForNavigation<ucPatientMenu>();
            containerRegistry.RegisterForNavigation<ucLocalization>();
            containerRegistry.RegisterForNavigation<ucImageImport>();
            containerRegistry.RegisterForNavigation<ucFullPic>();
            containerRegistry.RegisterForNavigation<ucSelection>();
            containerRegistry.RegisterForNavigation<ucFupImageImport>();
            containerRegistry.RegisterForNavigation<ucPatientSearch>();
            containerRegistry.RegisterForNavigation<ucFupLocalization>();
            containerRegistry.RegisterForNavigation<ucFupLiveVideo>();
            containerRegistry.RegisterForNavigation<ucPrintSelection>();
            containerRegistry.RegisterForNavigation<ucAdminUser>();
            containerRegistry.RegisterForNavigation<ucPMSSelect>();
            containerRegistry.RegisterForNavigation<ucPatientExpress>();
            containerRegistry.RegisterForNavigation<ucStiWia>();
            containerRegistry.RegisterForNavigation<ucImagePreview>();
            containerRegistry.RegisterForNavigation<ucPrint>();
            containerRegistry.RegisterForNavigation<ucAllSkin>();
            containerRegistry.RegisterForNavigation<ucAllSikinImageList>();

            containerRegistry.RegisterSingleton<IAppSettings, AppSettingsFromConfig>();
            containerRegistry.RegisterSingleton<IMolemaxRepository, SqlMolemaxRepository>();

            containerRegistry.RegisterDialog<ucAdminUserAdd, ucAdminUserAddViewModel>();
        }

    }
}
