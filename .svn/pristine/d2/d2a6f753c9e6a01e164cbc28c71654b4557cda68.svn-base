using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SING.Data.BaseTools;
using SING.Data.Logger;
using Telerik.Windows.Controls;

namespace Shell
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            LoadResourceDictionary(@"Themes/Generic.xaml", "FACE");
            LoadResourceDictionary(@"Themes/Office2010/Blue.xaml", "Fluent");
            LoadResourceDictionary(@"Themes/Shell.aero.normalcolor.xaml", "FACE");
            LoadResourceDictionary(@"Themes/Shell.aero.normalcolor.brushes.xaml", "FACE");
            //LoadResourceDictionary(@"themes/aero.normalcolor.xaml","PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("zh-CN");

            base.OnStartup(e);

#if (DEBUG)
            RunInDebugMode();
#else
            RunInReleaseMode();
#endif
        }

        private static void RunInDebugMode()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            StyleManager.ApplicationTheme = AppConfig.Instance.CurrentTheme;

            //是否能登录成功
            try
            {
                if (Login.Execute())
                {
                    Logger.Info(DateTime.Now.ToShortTimeString() + "引导完成");
                }
                else
                {
                    Application.Current.Shutdown();
                    Logger.Info("引导登录失败，程序退出");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("引导窗体错误，退出", ex);
                Application.Current.Shutdown();
            }
        }

        private static void RunInReleaseMode()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            try
            {
                FACEBootstrapper bootstrapper = new FACEBootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }
        private static void HandleException(Exception ex)
        {
            if (ex == null) return;

            MessageBox.Show(ex.Message);
            MessageBox.Show(ex.InnerException.Message);

            Environment.Exit(1);
        }
        public static void LoadResourceDictionary(string path, string assemblyFullName)
        {
            string dictionaryName = string.Format("/{0};component/{1}", assemblyFullName, path);
            var uri = new Uri(dictionaryName, UriKind.Relative);
            var dictionary = (ResourceDictionary)Application.LoadComponent(uri);
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
