using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Events;
using Shell.Models;
using Shell.ViewModels;
using SING.Data;
using SING.Data.BaseTools;
using SING.Data.Logger;
using SING.Infrastructure.Events;
using Telerik.Windows;
using Telerik.Windows.Controls;
using Application = System.Windows.Application;
using Logger = SING.Data.Logger.Logger;
using MessageBox = System.Windows.Forms.MessageBox;
using Screen = System.Windows.Forms.Screen;

using Timer = System.Threading.Timer;

namespace Shell.Views
{
    [Export]
    public partial class ShellView : Window,IPartImportsSatisfiedNotification
    {
        private readonly IEventAggregator _eventAggregator;

        [Import(AllowRecomposition = false)]
        public ShellViewModel ViewModel
        {
            get { return this.DataContext as ShellViewModel; }
            set { this.DataContext = value; }
        }

        [ImportingConstructor]
        public ShellView(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            _eventAggregator = eventAggregator;

            this.LayoutUpdated += new EventHandler(ShellView_LayoutUpdated);

            SetTheme();

            #region 设置窗体为最大化

            Screen screen = Screen.FromPoint(new System.Drawing.Point(0, 0));

            window.WindowState = WindowState.Maximized;

            window.MaxWidth = screen.Bounds.Width;
            window.MaxHeight = screen.Bounds.Height;

            #endregion

            this.TopMenu.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            this.TopMenu.MouseDoubleClick += TopMenu_MouseDoubleClick;
        }
       

        #region 属性

        #endregion

        #region Event
        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;
                this.DragMove();
            }
            catch
            {
            }
        }
        void ShellView_LayoutUpdated(object sender, EventArgs e)
        {
            SofaContainerContent1.UpdateLayout();
        }
        /// <summary>
        /// 显示窗口列表。
        /// </summary>
        private void ShowOpendWindowList()
        {
            if (this.OpendWindow.Visibility == Visibility.Visible)   // 当前是打开状态，则直接关闭。
            {
                this.OpendWindow.Visibility = Visibility.Hidden;
            }
            else                                                     // 当前是关闭状态，则更新后显示。
            {
                this.OpendWindow.Visibility = Visibility.Visible;
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (ViewModel.ExitCommand.CanExecute(e))
                ViewModel.ExitCommand.Execute(e);

            //topClock.AutoUpdate = false;
        }
        private void Handle_Click(object sender, RadRoutedEventArgs e)
        {
        }

        private void OnRadMenuItemClick(object sender, RoutedEventArgs e)
        {

        }
        private void TopMenu_OnItemClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Logger.Info("TopMenu_OnItemClick");

            RadMenuItem clickItem = e.OriginalSource as RadMenuItem;

            if (clickItem != null && clickItem.DataContext is MenuViewModel)
            {
                MenuViewModel menuView = clickItem.DataContext as MenuViewModel;

                if (String.IsNullOrEmpty(menuView.TagStr))
                {
                    return;
                }

                Logger.Info("TopMenu_OnItemClick");

                switch (menuView.TagStr)
                {
                    case "CloseWindow":
                        if (ViewModel.ExitCommand.CanExecute(null))
                        {
                            ViewModel.ExitCommand.Execute(null);
                        }
                        break;
                    case "MinWindow":
                        Application.Current.MainWindow.WindowState = WindowState.Minimized;
                        break;
                    case "SwitchScreen":
                        ExecuteSwitchScreen(this);
                        break;
                    case "SwitchFullScreen":
                        FullOrMined(this);
                        break;
                    case "ShowOpendWindowList":
                        ShowOpendWindowList();
                        break;
                    default:
                        Logger.Info("ClickOperator");
                        CallForOpenDocumentParameters openPara = new CallForOpenDocumentParameters();
                        openPara.TargetSofaContainer = "";
                        openPara.ProductPrimaryName = menuView.TagStr;
                        _eventAggregator.GetEvent<CallForOpenDocumentEvent>().Publish(openPara);
                        Logger.Info("ClickOperator2");
                        break;
                }
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ExitCommand.CanExecute(null))
                ViewModel.ExitCommand.Execute(null);
        }

        private void TopMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FullOrMined(this);
            #region
            //if (window.WindowState == WindowState.Maximized)
            //{
            //    window.Topmost = false;
            //    window.WindowState = WindowState.Normal;
            //    window.ResizeMode = ResizeMode.CanResize;
            //    //window.WindowStyle = WindowStyle.ThreeDBorderWindow;
            //    window.WindowStyle = WindowStyle.None;

            //    Logger.Info("窗口向下还原");

            //    var handle = new WindowInteropHelper(window).Handle;
            //    Screen screen = Screen.FromHandle(handle);
            //    System.Drawing.Rectangle r2 = screen.WorkingArea;

            //    window.Left = r2.Width - r2.Width * 0.85;
            //    window.Top = r2.Height - r2.Height * 0.85;
            //    window.Width = r2.Width - r2.Width * 0.3;
            //    window.Height = r2.Height - r2.Height * 0.3;

            //}
            //else
            //{
            //    window.Topmost = false;
            //    window.WindowState = WindowState.Normal;
            //    window.ResizeMode = ResizeMode.CanResize;
            //    //window.WindowStyle = WindowStyle.ThreeDBorderWindow;
            //    window.WindowStyle = WindowStyle.None;

            //    Logger.Info("窗口最大化");

            //    window.WindowState = WindowState.Maximized;

            //    var tt = SystemInformation.WorkingArea;

            //    window.Width = tt.Width;

            //    window.Height = tt.Height;


            //    window.Activated += new EventHandler(window_Activated);
            //    window.Deactivated += new EventHandler(window_Deactivated);
            //}
            #endregion
        }

        public void OnImportsSatisfied()
        {

        }
        #endregion

        #region 移动到第二个屏幕
        private void ExecuteSwitchScreen(object obj)
        {


            ShellView window1 = obj as ShellView;

            try
            {
                if (window1 != null)
                    ShellView.MaximizeToSecondaryMonitor(window1);
            }
            catch (Exception)
            {


            }
        }

        public static void MaximizeToSecondaryMonitor(Window window)
        {
            var secondaryScreen = Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            Logger.Info(string.Format("屏幕总数{0}", Screen.AllScreens.Count()));
            var priScreen = Screen.PrimaryScreen;
            if (secondaryScreen != null)
            {
                if (window.Left <= priScreen.WorkingArea.Left)
                {
                    if (window.IsLoaded)
                        window.WindowState = WindowState.Normal;

                    if (!window.IsLoaded)
                        window.WindowStartupLocation = WindowStartupLocation.Manual;

                    var workingArea = secondaryScreen.WorkingArea;

                    window.Left = workingArea.Left;
                    window.Top = workingArea.Top;
                    window.Width = workingArea.Width;
                    window.Height = workingArea.Height;

                    if (window.IsLoaded)
                        window.WindowState = WindowState.Maximized;
                }
                else
                {
                    if (window.IsLoaded)
                        window.WindowState = WindowState.Normal;

                    if (!window.IsLoaded)
                        window.WindowStartupLocation = WindowStartupLocation.Manual;

                    var workingArea = priScreen.WorkingArea;

                    window.Left = workingArea.Left;
                    window.Top = workingArea.Top;
                    window.Width = workingArea.Width;
                    window.Height = workingArea.Height;

                    if (window.IsLoaded)
                        window.WindowState = WindowState.Maximized;
                }
            }



        }
        #endregion

        #region 全屏切换

        public void FullOrMined(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                window.Topmost = false;
                window.WindowState = WindowState.Normal;
                window.ResizeMode = ResizeMode.CanResizeWithGrip;
                //window.WindowStyle = WindowStyle.ThreeDBorderWindow;
                window.WindowStyle = WindowStyle.None;

                Logger.Info("窗口向下还原");
                
              
                //var handle = new WindowInteropHelper(window).Handle;
                //Screen screen = Screen.FromHandle(handle);
                //System.Drawing.Rectangle r2 = screen.WorkingArea;
                //window.Left = r2.Width - r2.Width * 0.85;
                //window.Top = r2.Height - r2.Height * 0.85;
                //window.Width = r2.Width - r2.Width * 0.22;

                ViewModel.PlanManagement0.ParagraphMargin = new Thickness(0);
            }
            else
            {
                window.Topmost = false;
                window.WindowState = WindowState.Normal;
                window.WindowStyle = WindowStyle.None;
                window.ResizeMode = ResizeMode.CanResizeWithGrip;

                Logger.Info("窗口最大化");

                var handle = new WindowInteropHelper(window).Handle;

                Screen screen = Screen.FromPoint(new System.Drawing.Point(0, 0));

                window.WindowState = WindowState.Maximized;

                window.MaxWidth = screen.Bounds.Width;
                window.MaxHeight = screen.Bounds.Height;

                window.Activated += new EventHandler(window_Activated);
                window.Deactivated += new EventHandler(window_Deactivated);
                ViewModel.PlanManagement0.ParagraphMargin = new Thickness(400,0,0,0);
            }
        }

        public static void FullOrMin(Window window)
        {
            if (window.ResizeMode == ResizeMode.NoResize)
            {
                window.Topmost = false;
                window.WindowState = WindowState.Normal;
                window.ResizeMode = ResizeMode.CanResize;
                window.WindowStyle = WindowStyle.ThreeDBorderWindow;
                Logger.Info("窗口最大化为假");

                var handle = new WindowInteropHelper(window).Handle;
                Screen screen = Screen.FromHandle(handle);

                window.Left = 0;
                window.Top = 0;
                window.WindowState = WindowState.Maximized;

                window.MaxWidth = screen.Bounds.Width;
                window.MaxHeight = screen.Bounds.Height;
                //var tt = SystemInformation.WorkingArea;

                //window.Width = tt.Width;

                //window.Height = tt.Height;

                return;

            }
            else
            {
                window.WindowState = WindowState.Normal;
                window.WindowStyle = WindowStyle.None;
                window.ResizeMode = ResizeMode.NoResize;
                window.Topmost = true;

                Logger.Info("窗口最大化为真");

                var handle = new WindowInteropHelper(window).Handle;

                Screen screen = Screen.FromPoint(new System.Drawing.Point(0, 0));

                window.WindowState = WindowState.Maximized;

                window.MaxWidth = screen.Bounds.Width;
                window.MaxHeight = screen.Bounds.Height;

                window.Activated += new EventHandler(window_Activated);
                window.Deactivated += new EventHandler(window_Deactivated);
            }
        }
        static void window_Activated(object sender, EventArgs e)
        {
            var window = sender as Window;
            window.Topmost = true;
            Logger.Info("窗口最大化为真");
        }
        static void window_Deactivated(object sender, EventArgs e)
        {
            var window = sender as Window;
            window.Topmost = false;
            Logger.Info("窗口最大化为假");
        }
        #endregion

        #region Theme
        private void SetTheme()
        {
            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            StreamResourceInfo streamResourceInfo;
            string resourceStr = string.Empty;
            if (AppConfig.Instance.CurrentTheme is Windows7Theme)
            {
                resourceStr = @"/FACE;component/Resources/SystemBackground.jpg";
                this.TopMenu.Background = this.FindResource("TopMenuBrush_Windows7") as LinearGradientBrush;
            }
            else
            {
                resourceStr = @"/FACE;component/Resources/SystemBackground.jpg";
                this.TopMenu.Background = this.FindResource("TopMenuBrush_Windows7") as LinearGradientBrush;
                //this.TxtTitle.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(58, 88, 210));
            }
            streamResourceInfo = Application.GetResourceStream(new Uri(resourceStr, UriKind.Relative));
            this.Background = new ImageBrush((ImageSource)imageSourceConverter.ConvertFrom(streamResourceInfo.Stream));
        }

        #endregion

        #region 已打开窗体控件拖动。

        System.Windows.Point startPoint;

        Vector startOffset;

        /// <summary>
        /// 拖动-鼠标按下。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpendWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(window);
            startOffset = new Vector(ReTranslate.X, ReTranslate.Y);
            OpendWindow.CaptureMouse();
        }

        /// <summary>
        /// 拖动-鼠标移动。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpendWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (OpendWindow.IsMouseCaptured)
            {
                Vector offset = System.Windows.Point.Subtract(e.GetPosition(window), startPoint);

                ReTranslate.X = startOffset.X + offset.X;
                ReTranslate.Y = startOffset.Y + offset.Y;
            }
        }

        /// <summary>
        /// 拖动-鼠标松开。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpendWindow_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpendWindow.ReleaseMouseCapture();
        }

        /// <summary>
        /// ListBox的双击事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpendWindowListBox_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpendWindow opendWindow = OpendWindowListBox.SelectedItem as OpendWindow;

            if (opendWindow != null)
            {
                Window window = opendWindow.Window;

                RadWindow radWindow = opendWindow.RadWindow;

                if (radWindow != null)
                {
                    if (radWindow.WindowState == WindowState.Minimized)  // 最小化时正常显示。
                    {
                        radWindow.WindowState = WindowState.Normal;
                    }
                    radWindow.Focus();
                }
                else if (window != null)
                {
                    window.Show();
                    window.Activate();
                    window.WindowState = WindowState.Normal;
                }
            }

            ViewModel.ShellViewModel_OnPopWindowsChangedEvent("");

            e.Handled = true;   // 控制冒泡事件。
        }

        /// <summary>
        /// 右键菜单打开。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadMenuItemOpen_Click(object sender, RadRoutedEventArgs e)
        {
            RadMenuItem menuItem = sender as RadMenuItem;

            OpendWindow opendWindow = menuItem.DataContext as OpendWindow;

            if (opendWindow != null)
            {
                Window window = opendWindow.Window;

                RadWindow radWindow = opendWindow.RadWindow;

                if (radWindow != null)
                {
                    if (radWindow.WindowState == WindowState.Minimized)  // 最小化时正常显示。
                    {
                        radWindow.WindowState = WindowState.Normal;
                    }

                    radWindow.Focus();
                }
                else if (window != null)
                {
                    window.Show();
                    window.Activate();
                    window.WindowState = WindowState.Normal;
                }
            }

            ViewModel.ShellViewModel_OnPopWindowsChangedEvent("");

            e.Handled = true;
        }

        /// <summary>
        /// 右键菜单关闭。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadMenuItemClose_Click(object sender, RadRoutedEventArgs e)
        {
            RadMenuItem menuItem = sender as RadMenuItem;

            OpendWindow opendWindow = menuItem.DataContext as OpendWindow;

            if (opendWindow != null)
            {
                ShellViewModel shellViewModel = this.DataContext as ShellViewModel;

                if (shellViewModel != null)
                {
                    shellViewModel.CloseOpendWindows(opendWindow);
                }

                Window window = opendWindow.Window;

                RadWindow radWindow = opendWindow.RadWindow;

                if (radWindow != null)
                {
                    radWindow.Close();
                }
                else if (window != null)
                {
                    window.Close();
                }
            }

            ViewModel.ShellViewModel_OnPopWindowsChangedEvent("");
        }

        /// <summary>
        /// 弹出框不透明处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadWindowOpacity_Click(object sender, RadRoutedEventArgs e)
        {
            RadMenuItem menuItem = sender as RadMenuItem;

            double selectOpacity = Convert.ToDouble(menuItem.DataContext);

            this.OpendWindow.Opacity = selectOpacity;
        }

        #endregion

     
    }
}
