using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SING.Data;
using SING.Data.BaseTools;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;

namespace Shell
{
    public partial class Login : Window
    {
        SplashWindow tempOpen;
        private bool _result;
        public bool Result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
        private RoutedCommand _skipEnter;
        public RoutedCommand SkipEnter
        {
            get { return _skipEnter; }
            set { _skipEnter = value; }
        }
        public static RoutedCommand SkipEnterCommand = new RoutedCommand();
        public Login()
        {
            this._result = false;

            InitializeComponent();

            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;

            tempOpen = new SplashWindow();

            tempOpen.ShowLoadProcess += new SplashWindow.ShowDelegate(tempOpen_ShowLoadProcess);

            SkipEnterCommand.InputGestures.Add(new KeyGesture(Key.Enter, ModifierKeys.Control));

            txtHost.Text = AppConfig.Instance.LoginHost;
            txtPort.Text = AppConfig.Instance.LoginPort;
            txtUserName.Text = AppConfig.Instance.LoginName;
            txtPassword.Password = AppConfig.Instance.LoginPwd;

            if (AppConfig.Instance.LoginHost == AppConfig.Instance.IP || AppConfig.Instance.LoginHost == "127.0.0.1")
            {
                AppConfig.Instance.VersionType = VersionType.Local;
            }
            else
            {
                AppConfig.Instance.VersionType = VersionType.Net;
            }
        }

        #region  跳过密码验证
        private void CanExecuteSkipEnter(object sender, CanExecuteRoutedEventArgs e)
        {
            //e.CanExecute = !(this.progressReport.Value > 0);
        }
        private void OnExecuteSkipEnter(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            Load();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Load()
        {
            AfterLoginClick();

            this.progressReport.Value += 5;
            this._result = false;

            bool isAuth = false;
            string userInfo = string.Empty;
            string Uid = string.Empty;
            string UType = string.Empty;
            string divIndex = string.Empty;
            string divOrder = string.Empty;
            try
            {
                isAuth = IsAuth(out userInfo);
                if (AppConfig.Instance.VersionType == VersionType.Net)
                {
                    if (userInfo == string.Empty)
                        throw new Exception("用户登录错误!");
                    try
                    {
                        string[] infos = userInfo.Split('=', ';');

                        for (int i = 0; i < infos.Length; i++)
                        {
                            string info = infos[i];
                            if (info == "UID")
                            {
                                Uid = infos[i + 1];
                                continue;
                            }
                            if (info == "UTYPE")
                            {
                                UType = infos[i + 1];
                                continue;
                            }
                            if (info == "DIVINDEX")
                            {
                                divIndex = infos[i + 1];
                                continue;
                            }

                            if (info == "DIVORDER")
                            {
                                divOrder = infos[i + 1];
                                continue;
                            }
                        }
                        userInfo = string.Empty;
                        if (Uid == VerifyUserLogin.One)
                        {
                            userInfo = "设备信息有误!";
                            Logger.Error(userInfo);
                        }
                        else if (Uid == VerifyUserLogin.Two)
                        {
                            userInfo = "用户非法!";
                            Logger.Error(userInfo);
                        }
                        else if (Uid == VerifyUserLogin.Three)
                        {
                            userInfo = "用户状态更新出错!";
                            Logger.Error(userInfo);
                        }
                        else if (int.Parse(UType) <= 0)
                        {
                            userInfo = "用户类型错误!";
                            Logger.Error(userInfo);
                        }
                        if (userInfo == string.Empty)
                        {
                            AfterLoginClick();
                            MessageBox.Show(userInfo, "登录失败");
                            RecoverFromLoginClick();
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        Logger.Error("分离用户信息错误", ex);
                        RecoverFromLoginClick();
                    }
                }
                else if (isAuth == false)
                {
                    AfterLoginClick();
                    MessageBox.Show("服务器连接错误！", "登录失败");
                    RecoverFromLoginClick();
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("获取用户出错", ex);
                RecoverFromLoginClick();

            }
            this.progressReport.Value += 5;

            FACEIdentity identity = new FACEIdentity(txtUserName.Text, txtPassword.Password, isAuth);

            if (identity.IsAuthenticated == false)
            {
                AfterLoginClick();
                MessageBox.Show("用户或密码错误，请重新输入！", "登录失败");
                RecoverFromLoginClick();
            }
            else
            {
                //记录登录用户名
                AppConfig.Instance.LoginName = txtUserName.Text;
                AppConfig.Instance.LoginPwd = txtPassword.Password;
                AppConfig.Instance.LoginHost = txtHost.Text;
                AppConfig.Instance.LoginPort = txtPort.Text;
                var localip = AppConfig.Instance.IP;
                var mac = AppConfig.Instance.Machine_Mac;
                AppConfig.Instance.Save(true);
                AppConfig.Instance.UserInfo = identity;


               
                Thread.CurrentPrincipal = new GenericPrincipal(identity, new string[] { Uid, UType, divIndex, divOrder });
                this._result = true;

                this.progressReport.Value = 5;

                try
                {
                    tempOpen.System_Start_Loaded();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("FACE", ex.ToString());
                    Environment.Exit(0);
                }
            }
        }

        private void AfterLoginClick()
        {
            this.progressReport.Visibility = Visibility.Hidden;
            this.btnLogin.IsEnabled = false;
        }
        private void RecoverFromLoginClick()
        {
            this.progressReport.Visibility = Visibility.Hidden;
            this.progressReport.Value = 0;
            this.btnLogin.IsEnabled = true;
        }
        #endregion

        private void tempOpen_ShowLoadProcess(string txt)
        {
            this.progressReport.Value = this.progressReport.Value + 10;
            Logger.Info(txt + "---->" + progressReport.Value);
            if (this.progressReport.Value >= 100)
                this.Close();
        }

        private bool IsAuth(out string userInfo)
        {
            try
            {
                // 验证用户信息
                if (AppConfig.Instance.VersionType == VersionType.Net)
                {
                    userInfo = ScheduleGet.ValidtionUser(txtHost.Text, txtPort.Text, txtUserName.Text, txtPassword.Password, AppConfig.Instance.EquipInfo);
                    if (userInfo != string.Empty)
                    { return true; }
                    else
                    { return false; }
                }
                else
                {
                    userInfo = string.Empty;
                    return ScheduleGet.Login(txtHost.Text, txtPort.Text);
                }

            }
            catch (Exception ex)
            {
                Logger.Error("连接服务器错误", ex);
            }
            userInfo = string.Empty;
            return false;
        }
        public static bool Execute()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;  //防止登录后Application退出
            Login loginWin = new Login();
            loginWin.ShowDialog();
            try
            {
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            catch (Exception)
            {


            }

            return loginWin.Result;
        }
    }
}
