using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using SING.Data.BaseTools;
using SING.Data.Logger;

namespace Shell
{
    public partial class SplashWindow : Window
    {
        //private static readonly string ConfigPath = AppDomain.CurrentDomain.BaseDirectory;
        Thread loadingThread;
        Storyboard Showboard;
        Storyboard Hideboard;
        public delegate void ShowDelegate(string txt);
        public delegate void HideDelegate();
        public event ShowDelegate ShowLoadProcess;
        public ShowDelegate showDelegate;
        HideDelegate hideDelegate;
        public SplashWindow()
        {
            InitializeComponent();

            this.versionText.Text = "Version " + AppConfig.Instance.AppShortVersion;
            showDelegate = new ShowDelegate(this.showText);
            hideDelegate = new HideDelegate(this.hideText);
            Showboard = this.Resources["showStoryBoard"] as Storyboard;
            Hideboard = this.Resources["HideStoryBoard"] as Storyboard;
        }

        public void System_Start_Loaded()
        {
            loadingThread = new Thread(load);
            loadingThread.Start();
        }

        private void load()
        {
            this.Dispatcher.Invoke(DispatcherPriority.Render, showDelegate, "引导初始化......");

            Dispatcher.Invoke(hideDelegate);
            this.Dispatcher.Invoke(showDelegate, "载入程序中......");
            FACEBootstrapper bootstrapper = new FACEBootstrapper();
            bootstrapper.OwnerDispater = this.Dispatcher;
            bootstrapper.ShowDelegateEvent = showText;
            bootstrapper.Run();
            Logger.Info("已引导完成");
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate ()
            {
                Logger.Info("已进入主界面显示");
                Application.Current.MainWindow.Visibility = Visibility.Visible;
                Application.Current.MainWindow.Show();
                Logger.Info("显示最后一步进度");
                this.Dispatcher.Invoke(showDelegate, "显示界面......");
            });

            Dispatcher.Invoke(DispatcherPriority.Loaded, (Action)delegate { Close(); });
        }

        private void showText(string txt)
        {
            if (ShowLoadProcess != null)
                ShowLoadProcess.Invoke(txt);

            txtLoading.Text = txt;
            BeginStoryboard(Showboard);
        }
        private void hideText()
        {
            BeginStoryboard(Hideboard);
        }
    }
}
