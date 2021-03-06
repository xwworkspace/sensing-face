﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Shell.Models;
using Shell.Views;
using SING.Data;
using SING.Data.BaseTools;
using SING.Data.Data;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;
using SING.Infrastructure.Events;
using Sofa.Commons;
using Sofa.Container;
using Telerik.Windows.Controls;

namespace Shell.ViewModels
{
    [Export]
    public class ShellViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator _eventAggregator;
        
        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            OnPopWindowsChangedEvent += new Action<string>(ShellViewModel_OnPopWindowsChangedEvent);

            ExitCommand = new DelegateCommand<object>(AppExit, CanAppExit);

            SwitchScreenCommand = new DelegateCommand<object>(ExecuteSwitchScreen, CanExecuteSwitchScreen);

            FACEIdentity identity = Thread.CurrentPrincipal.Identity as FACEIdentity;
            UserCfgData userCfgData = null;
            if (identity != null)
            {
                try
                {
                    FACEIdentity.CurrentUser = identity;
                    userCfgData = ScheduleGet.QueryUser(identity.UserName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("定义用户表示信息失败：FACEIdentity");
                    Logger.Error("定义用户表示信息失败：FACEIdentity", ex);
                }
                if (userCfgData != null)
                {
                    identity.UserInfo = userCfgData;
                }
            }

            #region 菜单 载入

            ApplicationMenus = IniApplicationMenu();
            //设置全局的菜单项目
            AppConfig.Instance.ApplicationMenus = ApplicationMenus;

            #endregion
        }
        public void ShellViewModel_OnPopWindowsChangedEvent(string obj)
        {
            this.OpendWindows = this.CombinOpendWindow();
        }

        #region 属性

        private MenuViewModel _applicationMenus;
        public MenuViewModel ApplicationMenus
        {
            get { return _applicationMenus; }
            set
            {
                _applicationMenus = value;
                RaisePropertyChanged("ApplicationMenus");
            }
        }

        public event Action<string> OnPopWindowsChangedEvent;

        /// <summary>
        /// 默认显示4个窗体列表。
        /// </summary>
        private int opendWindowListWidth = 25 * 4 + 2;

        public int OpendWindowListWidth
        {
            get
            {
                return this.opendWindowListWidth;
            }
            set
            {
                this.opendWindowListWidth = value;

                this.RaisePropertyChanged("OpendWindowListWidth");
            }
        }

        /// <summary>
        /// 所有打开的窗体（Window+RadWindow）。
        /// </summary>
        private ObservableCollection<OpendWindow> opendWindows;

        public ObservableCollection<OpendWindow> OpendWindows
        {
            get
            {
                return opendWindows;
            }
            set
            {
                opendWindows = value;

                this.OpendWindowListWidth = ((value != null && value.Count > 4) ? value.Count : 4) * 25 + 2;

                this.RaisePropertyChanged("OpendWindows");

                this.OpendWindowListChange(value);
            }
        }

        /// <summary>
        /// 打开的RadWindow。
        /// </summary>
        private IList<WindowBase> opendRadWindows;

        public IList<WindowBase> OpendRadWindows
        {
            get
            {
                return opendRadWindows;
            }
            set
            {
                opendRadWindows = value;

                // 重组集合。
                this.OpendWindows = CombinOpendWindow();
            }
        }

        #endregion

        #region 页面打开窗体列表相关
        /// <summary>
        /// 组合普通Window和RadWindow，并按名称排序。
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<OpendWindow> CombinOpendWindow()
        {
            List<OpendWindow> opendWindows = new List<OpendWindow>();

            if (this.OpendRadWindows != null && this.OpendRadWindows.Count > 0)
            {
                foreach (WindowBase windowBase in this.OpendRadWindows)
                {
                    opendWindows.Add(new OpendWindow() { Title = windowBase.Header.ToString(), RadWindow = windowBase as RadWindow, Window = null });
                }
            }

            if (Application.Current.MainWindow.OwnedWindows.Count > 0)
            {
                foreach (Window window in Application.Current.MainWindow.OwnedWindows)
                {
                    opendWindows.Add(new OpendWindow() { Title = window.Title, RadWindow = null, Window = window });
                }
            }

            opendWindows = opendWindows.OrderBy(s => s.Title).ToList<OpendWindow>();

            ObservableCollection<OpendWindow> opendWindowCollection = new ObservableCollection<OpendWindow>(opendWindows);

            return opendWindowCollection;
        }

        /// <summary>
        /// 关闭指定的OpendWindow。
        /// </summary>
        /// <param name="opendWindow">操作的窗体。</param>
        public void CloseOpendWindows(OpendWindow opendWindow)
        {
            if (this.OpendWindows.Contains(opendWindow))
            {
                this.OpendWindows.Remove(opendWindow);
            }
        }

        /// <summary>
        /// 更改窗体打开列表。
        /// </summary>
        /// <param name="windowBases"></param>
        private void OpendWindowListChange(ObservableCollection<OpendWindow> opendWindows)
        {
            if (this.ApplicationMenus != null)
            {
                // 取出“打开窗体列表”的菜单”索引
                int showOpendWindowListIndex = -1;

                for (int i = 0; i < this.ApplicationMenus.Count; i++)
                {
                    if (this.ApplicationMenus[i].TagStr == "ShowOpendWindowList")
                    {
                        showOpendWindowListIndex = i;

                        break;
                    }
                }

                if (showOpendWindowListIndex == -1)
                {
                    return;
                }

                SubscriptImageMenuItemViewMode subscriptImageMenuItemViewMode = this.ApplicationMenus[showOpendWindowListIndex] as SubscriptImageMenuItemViewMode;
                if (subscriptImageMenuItemViewMode != null)
                {
                    subscriptImageMenuItemViewMode.PromptCount = opendWindows.Count;
                }
            }
        }
        #endregion

        #region SwitchScreenCommand
        public DelegateCommand<object> SwitchScreenCommand { get; private set; }
        private bool CanExecuteSwitchScreen(object arg)
        {
            return true;
        }

        private void ExecuteSwitchScreen(object obj)
        {

            ShellView window = obj as ShellView;

            try
            {
                if (window != null)
                    ShellView.MaximizeToSecondaryMonitor(window);
            }
            catch (Exception)
            {

                Logger.Error("切换屏幕出错");
            }
        }
        #endregion

        #region ExitCommand
        public DelegateCommand<object> ExitCommand { get; private set; }

        private void AppExit(object commandArg)
        {
            MessageBoxResult result = MessageBox.Show("是否退出当前客户端程序？", "系统退出确认", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    this._eventAggregator.GetEvent<ClosingApplicationEvent>().Publish("");
                }
                catch (Exception ex)
                {

                    Logger.Error("保存登出信息错误", ex);
                }

                Environment.Exit(0);
            }
            else
            {
                CancelEventArgs ce = commandArg as CancelEventArgs;

                if (ce != null)
                {
                    ce.Cancel = true;
                }
            }

            //Environment.Exit(1);
        }



        private bool CanAppExit(object commandArg)
        {
            return true;
        }
        #endregion

        #region IniApplicationMenu

        private ParagraphMenuItemViewMode planManagement0;

        public ParagraphMenuItemViewMode PlanManagement0
        {
            get { return planManagement0; }
            set
            {
                this.planManagement0 = value;

                this.RaisePropertyChanged("PlanManagement0");
            }
        }

        public MenuViewModel IniApplicationMenu()
        {
            MenuViewModel menus = new MenuViewModel();

            menus.Add(new MenuItemViewModel()
            {
                Content = @"pack://application:,,,/FACE;component\Resources\logoIcon.png",
                Type = MenuItemViewModel.MenuItemTypes.Logo,
                ToolTip = "深醒动态人脸识别系统"
            });
            menus.Add(new MenuItemViewModel()
            {
                Content = @"pack://application:,,,/FACE;component\Resources\Exit.png",
                Type = MenuItemViewModel.MenuItemTypes.Image,
                TagStr = "CloseWindow",
                ToolTip = "关闭"
            });
            menus.Add(new MenuItemViewModel()
            {
                Content = @"pack://application:,,,/FACE;component\Resources\MinWin.png",
                Type = MenuItemViewModel.MenuItemTypes.Image,
                TagStr = "MinWindow",
                ToolTip = "最小化"
            });
            menus.Add(new MenuItemViewModel()
            {
                Content = @"pack://application:,,,/FACE;component\Resources\SwitchScreen.png",
                Type = MenuItemViewModel.MenuItemTypes.Image,
                TagStr = "SwitchScreen",
                ToolTip = "切换显示器"
            });
            menus.Add(new MenuItemViewModel()
            {
                Content = @"pack://application:,,,/FACE;component\Resources\FullScreen.png",
                Type = MenuItemViewModel.MenuItemTypes.Image,
                TagStr = "SwitchFullScreen",
                ToolTip = "全屏切换"
            });
            menus.Add(new SubscriptImageMenuItemViewMode()
            {
                Content = @"pack://application:,,,/FACE;component\Resources\WindowList.png",
                Type = MenuItemViewModel.MenuItemTypes.SubscriptImage,
                TagStr = "ShowOpendWindowList",
                ToolTip = "打开窗体列表",
                PromptCount = 0,
                Visibility = Visibility.Visible
            });

            PlanManagement0 = new ParagraphMenuItemViewMode()
            {
                Type = MenuItemViewModel.MenuItemTypes.Paragraph,
                ParagraphMargin = new Thickness(300, 4, 4, 4)
            };

            #region 人脸显示

            MenuItemViewModel planManagement1 = new MenuItemViewModel()
            {
                Content = "人脸显示",
                Type = MenuItemViewModel.MenuItemTypes.TopLevel,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true

            };
            planManagement1.Add(new MenuItemViewModel()
            {
                Content = "人脸抓拍比对",
                Type = MenuItemViewModel.MenuItemTypes.TopLevelSection,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement1[0].Add(new MenuItemViewModel()
            {
                Content = "抓拍比对",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "FACE_CaptureComparisonManagement",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement1[0].Add(new MenuItemViewModel()
            {
                Content = "交叉比对",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "FACE_CaptureComparisonManagement",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });

            #endregion

            #region 摄像通道

            MenuItemViewModel planManagement2 = new MenuItemViewModel()
            {
                Content = "摄像通道",
                Type = MenuItemViewModel.MenuItemTypes.TopLevel,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true

            };
            planManagement2.Add(new MenuItemViewModel()
            {
                Content = "通道管理",
                Type = MenuItemViewModel.MenuItemTypes.TopLevelSection,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement2[0].Add(new MenuItemViewModel()
            {
                Content = "通道管理",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "FACE_ChannelManagement",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });

            planManagement2[0].Add(new MenuItemViewModel()
            {
                Content = "轨迹追踪",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            #endregion

            #region 人脸记录

            MenuItemViewModel planManagement3 = new MenuItemViewModel()
            {
                Content = "人脸记录",
                Type = MenuItemViewModel.MenuItemTypes.TopLevel,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            };
            planManagement3.Add(new MenuItemViewModel()
            {
                Content = "人脸记录",
                Type = MenuItemViewModel.MenuItemTypes.TopLevelSection,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement3[0].Add(new MenuItemViewModel()
            {
                Content = "历史检索",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "FACE_SearchHistoryManagement",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement3[0].Add(new MenuItemViewModel()
            {
                Content = "抓拍记录",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });

            #endregion

            #region 模版管理

            MenuItemViewModel planManagement4 = new MenuItemViewModel()
            {
                Content = "人脸模版",
                Type = MenuItemViewModel.MenuItemTypes.TopLevel,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            };

            planManagement4.Add(new MenuItemViewModel()
            {
                Content = "人脸模版",
                Type = MenuItemViewModel.MenuItemTypes.TopLevelSection,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement4[0].Add(new MenuItemViewModel()
            {
                Content = "模版管理",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "FACE_ChannelManagement",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });

            #endregion

            #region 基础数据维护
            MenuItemViewModel planManagement5 = new MenuItemViewModel()
            {
                Content = "基础数据维护",
                Type = MenuItemViewModel.MenuItemTypes.TopLevel,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            };
            planManagement5.Add(new MenuItemViewModel() { Content = "数据维护", Type = MenuItemViewModel.MenuItemTypes.TopLevelSection });

            MenuItemViewModel mvmschedu6 = new MenuItemViewModel()
            {
                Content = "N:N功能",
                Type = MenuItemViewModel.MenuItemTypes.STopLevel,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            };
            var t1t1 = new MenuItemViewModel() { Content = "a9", Type = MenuItemViewModel.MenuItemTypes.TopLevelSection };
            mvmschedu6.Add(t1t1);

            planManagement5[0].Add(mvmschedu6);
            planManagement5[0].Add(new MenuItemViewModel()
            {
                Content = "用户管理",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            #endregion

            #region 系统

            MenuItemViewModel planManagement6 = new MenuItemViewModel()
            {
                Content = "系统管理",
                Type = MenuItemViewModel.MenuItemTypes.TopLevel,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            };
            planManagement6.Add(new MenuItemViewModel()
            {
                Content = "系统",
                Type = MenuItemViewModel.MenuItemTypes.TopLevelSection
            });
            planManagement6[0].Add(new MenuItemViewModel()
            {
                Content = "系统设置",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "SystemHelper",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement6[0].Add(new MenuItemViewModel()
            {
                Content = "系统帮助",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "SystemHelpOperate",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement6[0].Add(new MenuItemViewModel()
            {
                Content = "系统日志回收",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "CollectTodayLog",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            planManagement6[0].Add(new MenuItemViewModel()
            {
                Content = "注意事项",
                Type = MenuItemViewModel.MenuItemTypes.Link,
                TagStr = "NotifiedItem",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true
            });
            #endregion

            #region

            MenuItemViewModel planManagement8 = new MenuItemViewModel()
            {
                Content = "欢迎您，管理员",
                Type = MenuItemViewModel.MenuItemTypes.Gallery,
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true,
                SelectIndex = 0
            };
            planManagement8.Add(new MenuItemViewModel()
            {
                Content = "提示",
                Type = MenuItemViewModel.MenuItemTypes.TopLevelSection
            });
            planManagement8[0].Add(new MenuItemViewModel()
            {
                Content = "注销",
                Type = MenuItemViewModel.MenuItemTypes.Title,
                TagStr = "",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true,
                SelectIndex = 1
            });
            planManagement8[0].Add(new MenuItemViewModel()
            {
                Content = "退出",
                Type = MenuItemViewModel.MenuItemTypes.Title,
                TagStr = "",
                MenuVisibility = Visibility.Visible,
                MenuIsEnabled = true,
                SelectIndex = 1
            });

            #endregion

            menus.Add(planManagement0);
            menus.Add(planManagement1);
            menus.Add(planManagement2);
            menus.Add(planManagement3);
            menus.Add(planManagement4);
            menus.Add(planManagement5);
            menus.Add(planManagement6);
            menus.Add(planManagement8);

            return menus;
        }

        #endregion

        #region SofaComponent
        public IBaseContainer Container;
        public SofaComponent ThisSofaComponent { get; set; }
        public void SofaCommonEventHandler(object sender, SofaEventArgs e)
        {

        }

        public void SofaCommonCancelEventHandler(object sender, SofaCancelEventArgs e)
        {

        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
