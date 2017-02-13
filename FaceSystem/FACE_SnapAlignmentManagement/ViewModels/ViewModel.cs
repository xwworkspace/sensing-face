using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Resources;
using FACE_SnapAlignmentManagement.Models;
using FACE_SnapAlignmentManagement.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.ServiceLocation;
using SING.Data.Logger;
using Sofa.Commons;
using Sofa.Container;
using SING.Data.Controls.ActiveXControl.DZVideoActiveX;
using SING.Data.Data;
using SING.Data.ScheduleProcess;
using SING.Infrastructure.Events;

namespace FACE_SnapAlignmentManagement.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewModel : NotificationObject, INavigationAware
    {
        public readonly IDataService _dataService;
        public readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        private readonly IServiceLocator _serviceLocator;

        [ImportingConstructor]
        public ViewModel(IDataService dataService, IEventAggregator eventAggregator, IRegionManager regionManager, IServiceLocator serviceLocator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _serviceLocator = serviceLocator;


            ResetServerRealtimeCapInfo = new ManualResetEvent(false);
            ResetServerRealtimeCmpInfo = new ManualResetEvent(false);

            IniThreshold();

            InitialChannel();

            IniWindowsFormsHostlist();

            //SetVideoGridScreen(1);
            MessageBox.Show("cap");
            //打开客户端服务，接收业务服务器上传的实时抓拍和实时识别结果     
            //Thread ThreadStarServer = new System.Threading.Thread(new ParameterizedThreadStart(StartServer));
            //ThreadStarServer.SetApartmentState(ApartmentState.STA);
            //ThreadStarServer.Start();

            //_eventAggregator.GetEvent<RealtimeCaptureEvent>().Subscribe(OnRealtimeCaptureEvent);
            //_eventAggregator.GetEvent<RealtimeCmpInfoEvent>().Subscribe(OnRealtimeCmpInfoEvent);
            //CommandSetScreen = new DelegateCommand<string>(ExecuteCommandSetScreen, CanCommandSetScreen);
            //CommandChannelVideoSearch = new DelegateCommand<string>(ExecuteCommandChannelVideoSearch, CanCommandChannelVideoSearch);
            //CommandRefreshChannel = new DelegateCommand<string>(ExecuteCommandRefreshChannel, CanCommandRefreshChannel);
        }

        #region 属性

        /// <summary>
        /// 监听服务器实时上传的抓拍信息
        /// </summary>
        public ManualResetEvent ResetServerRealtimeCapInfo;

        /// <summary>
        /// 监听服务器实时上传的比对信息
        /// </summary>
        public ManualResetEvent ResetServerRealtimeCmpInfo;           
        /// <summary>
        /// 当前正在播放的视频数量
        /// </summary>
        private int currentVideo = 0;

        /// <summary>
        /// 当前分屏允许的最大分屏数量
        /// </summary>
        private int currentMaxvideo = 0; 

        private Grid _videoPartGrid;
        public Grid VideoPartGrid
        {
            get
            {
                return _videoPartGrid;
            }
            set
            {
                _videoPartGrid = value;
                RaisePropertyChanged("VideoPartGrid");
            }
        }

        private List<WindowsFormsHost> _wfhList;
        public List<WindowsFormsHost> WfhList
        {
            get
            {
                return _wfhList;
            }
            set
            {
                _wfhList = value;
                RaisePropertyChanged("WfhList");
            }
        }
        private ChannelCfgViewData _channelCurrentItem;

        public ChannelCfgViewData ChannelCurrentItem
        {
            get { return _channelCurrentItem; }
            set
            {
                _channelCurrentItem = value;
                RaisePropertyChanged("ChannelCurrentItem");
            }
        }

        private List<ChannelCfgViewData> channelList;

        public List<ChannelCfgViewData> ChannelList
        {
            get { return channelList; }
            set
            {
                channelList = value;
                RaisePropertyChanged("ChannelList");
            }
        }

        private ICollectionView _channelListCV;
        public ICollectionView ChannelListCV
        {
            get
            {
                return _channelListCV;
            }
            set
            {
                _channelListCV = value;
                RaisePropertyChanged("ChannelListCV");
            }
        }

        private List<string> threshold;
        /// <summary>
        /// 阈值
        /// </summary>
        public List<string> Threshold
        {
            get { return threshold; }
            set
            {
                threshold = value;
                RaisePropertyChanged("Threshold");
            }
        }

        private ICollectionView _thresholdCV;
        public ICollectionView ThresholdCV
        {
            get
            {
                return _thresholdCV;
            }
            set
            {
                _thresholdCV = value;
                RaisePropertyChanged("ThresholdCV");
            }
        }

        private int selectedThreshold;
        /// <summary>
        /// 阈值选中项
        /// </summary>
        public int SelectedThreshold
        {
            get { return selectedThreshold; }
            set
            {
                selectedThreshold = value;
                RaisePropertyChanged("SelectedThreshold");
            }
        }

        private CapFaceLogWithImgData _currentCapFaceLogWithImgData;
        /// <summary>
        /// 当前抓拍信息
        /// </summary>
        public CapFaceLogWithImgData CurrentCapFaceLogWithImgData 
        {
            get
            {
                return _currentCapFaceLogWithImgData;
            }
            set
            {
                _currentCapFaceLogWithImgData = value;
                RaisePropertyChanged("CurrentCapFaceLogWithImgData");
            }
        }

        private List<CapFaceLogWithImgData> _listCapFaceLogWithImgData;
        public List<CapFaceLogWithImgData> ListCapFaceLogWithImgData
        {
            get { return _listCapFaceLogWithImgData; }
            set
            {
                _listCapFaceLogWithImgData = value;
                RaisePropertyChanged("ListCapFaceLogWithImgData");
            }
        }

        private ICollectionView _capFaceLogWithImgDataCV;
        public ICollectionView CapFaceLogWithImgDataCV
        {
            get { return _capFaceLogWithImgDataCV; }
            set
            {
                _capFaceLogWithImgDataCV = value;
                RaisePropertyChanged("CapFaceLogWithImgDataCV");
            }
        }

        private RealtimeCmpInfoViewData _currentRealtimeCmpInfoViewData;
        /// <summary>
        /// 当前比对信息
        /// </summary>
        public RealtimeCmpInfoViewData CurrentRealtimeCmpInfoViewData
        {
            get
            {
                return _currentRealtimeCmpInfoViewData;
            }
            set
            {
                _currentRealtimeCmpInfoViewData = value;
                RaisePropertyChanged("CurrentRealtimeCmpInfoViewData");
            }
        }

        private List<RealtimeCmpInfoViewData> _listRealtimeCmpInfoViewData;
        public List<RealtimeCmpInfoViewData> ListRealtimeCmpInfoViewData
        {
            get { return _listRealtimeCmpInfoViewData; }
            set
            {
                _listRealtimeCmpInfoViewData = value;
                RaisePropertyChanged("ListRealtimeCmpInfoViewData");
            }
        }

        private ICollectionView _realtimeCmpInfoViewDataCV;
        public ICollectionView RealtimeCmpInfoViewDataCV
        {
            get { return _realtimeCmpInfoViewDataCV; }
            set
            {
                _realtimeCmpInfoViewDataCV = value;
                RaisePropertyChanged("RealtimeCmpInfoViewDataCV");
            }
        }

        #endregion

        #region 设置视频分屏
        private void IniWindowsFormsHostlist()
        {
            if (WfhList == null) WfhList = new List<WindowsFormsHost>();
            for (int i = 0; i < 16; i++)
            {
                WindowsFormsHost wfh = new WindowsFormsHost();
                wfh.Tag = null;
                WfhList.Add(wfh);
            }
        }

        /// <summary>
        /// 设置分屏,并添加子项
        /// </summary>
        /// <param name="i">几分屏</param>
        public void SetVideoGridScreen(int sceenCount)
        {
            currentMaxvideo = sceenCount;
            if(VideoPartGrid == null) VideoPartGrid = new Grid();
            try
            {
                //设置分屏,添加行列
                int rowCount = 0;
                int ColCount = 0;
                for (int i = 0; i < VideoPartGrid.Children.Count; i++)
                {
                    if (VideoPartGrid.Children[i] is Grid)
                    {
                        ((Grid)VideoPartGrid.Children[i]).Children.Clear();
                    }
                }
                //foreach (Grid thing in VideoPartGrid.Children)
                //{
                //    thing.Children.Clear();
                //}
                VideoPartGrid.Children.Clear();
                VideoPartGrid.RowDefinitions.Clear();
                VideoPartGrid.ColumnDefinitions.Clear();
                switch (sceenCount)
                {
                    case 1:
                        rowCount = 1;
                        ColCount = 1;
                        break;
                    case 2:
                        rowCount = 2;
                        ColCount = 1;
                        break;
                    case 3:
                        rowCount = 2;
                        ColCount = 2;
                        break;
                    case 4:
                        rowCount = 2;
                        ColCount = 2;
                        break;
                    case 5:
                    case 6:
                        rowCount = 3;
                        ColCount = 2;
                        break;
                    case 7:
                    case 8:
                    case 9:
                        rowCount = 3;
                        ColCount = 3;
                        break;
                    case 10:
                    case 11:
                    case 12:
                        rowCount = 4;
                        ColCount = 3;
                        break;
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        rowCount = 4;
                        ColCount = 4;
                        break;
                }
                for (int i = 1; i <= rowCount; i++)
                {
                    VideoPartGrid.RowDefinitions.Add(new RowDefinition());
                }
                for (int i = 1; i <= ColCount; i++)
                {
                    VideoPartGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }

                //添加子项
                for (int i = 0; i < sceenCount; i++)
                {
                    Grid screenGrid = new Grid();
                    ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                    StreamResourceInfo streamResourceInfo;
                    string resourceStr = string.Empty;
                    resourceStr = @"pack://application:,,,/FACE;component/Resources/noVideoBackground.png";
                    streamResourceInfo = Application.GetResourceStream(new Uri(resourceStr, UriKind.Absolute));
                    screenGrid.Background = new ImageBrush((ImageSource)imageSourceConverter.ConvertFrom(streamResourceInfo.Stream));
                    if (sceenCount == 3 && i == 2)
                    {
                        screenGrid.SetValue(Grid.RowProperty, i / ColCount);
                        screenGrid.SetValue(Grid.ColumnProperty, i % ColCount);
                        screenGrid.SetValue(Grid.ColumnSpanProperty, 2);
                    }
                    else
                    {
                        screenGrid.SetValue(Grid.RowProperty, i / ColCount);
                        screenGrid.SetValue(Grid.ColumnProperty, i % ColCount);
                    }

                    screenGrid.Children.Add(WfhList[i]);
                    VideoPartGrid.Children.Add(screenGrid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 初始化阈值
        private void IniThreshold()
        {
            _dataService.IniThreshold(this);
        }
        #endregion

        #region 初始化通道列表

        private void InitialChannel()
        {
            _dataService.InitialChannel(this);
        }

        public void ChannelListItemChanged(object sender, EventArgs e)
        {
            if (ChannelListCV != null && ChannelListCV.CurrentItem != null)
            {
                ChannelCurrentItem = ChannelListCV.CurrentItem as ChannelCfgViewData;
            }

            ChannelVideoSearch();
        }

        private void ChannelVideoSearch()
        {
            if (ChannelCurrentItem == null) return;
            try
            {
                string IP = ChannelCurrentItem.ChannelCfgData.CaptureCfgData.TcAddr;
                if (IP == string.Empty)
                {
                    System.Windows.MessageBox.Show("摄像机IP为空！");
                    return;
                }

                if (ChannelCurrentItem.IsOpened == false)
                {
                    ChannelCurrentItem.IsOpened = true;
                    currentVideo++;


                    AxDZVideoControl AxVideoControl = new AxDZVideoControl();
                    AxVideoControl.OpenCamera(ChannelCurrentItem.ChannelCfgData.CaptureCfgData.NCaptureType,
                                                ChannelCurrentItem.ChannelCfgData.CaptureCfgData.TcAddr + "|" +
                                                ChannelCurrentItem.ChannelCfgData.TcDescription, (uint)ChannelCurrentItem.ChannelCfgData.CaptureCfgData.NPort,
                                                ChannelCurrentItem.ChannelCfgData.CaptureCfgData.TcUID, ChannelCurrentItem.ChannelCfgData.CaptureCfgData.TcPSW, 1, 1);


                    foreach (WindowsFormsHost wfh in WfhList)
                    {
                        if (wfh.Tag == null)
                        {
                            wfh.Child = AxVideoControl;
                            wfh.Tag = ChannelCurrentItem.ChannelCfgData.TcChaneelID;
                            break;
                        }
                    }

                    SetVideoGridScreen(1);
                    if (currentVideo > currentMaxvideo)
                    {
                        SetVideoGridScreen(currentVideo);
                    }
                }
                else
                {
                    currentVideo--;
                    foreach (WindowsFormsHost wfh in WfhList)
                    {
                        if (wfh.Tag != null && wfh.Tag.ToString() == ChannelCurrentItem.ChannelCfgData.TcChaneelID)
                        {
                            (wfh.Child as AxDZVideoControl).CloseCamera();
                            //wfh.Child = null;
                            //wfh.Child.Dispose();
                            wfh.Child = null;
                            wfh.Tag = null;
                            break;
                        }
                    }
                    ChannelCurrentItem.IsOpened = false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("摄像机无法连接！");
                Logger.Error("通道摄像机连接异常，方法名：ChannelListItemChanged", ex);
            }

        }

        #endregion

        #region 接收业务服务器上传的实时抓拍和实时识别结果

        public void StartServer(object ob)
        {
            _dataService.RealtimeCap(this);
            _dataService.RealtimeCmp(this);
            ScheduleUIServer.ServiceProcessor();
        }

        #endregion

        #region CommandChannelVideoSearch
        public DelegateCommand<string> CommandChannelVideoSearch { get; private set; }

        private void ExecuteCommandChannelVideoSearch(string commandParameter)
        {
            ChannelVideoSearch();
        }

        private bool CanCommandChannelVideoSearch(string commandParameter)
        {
            return true;
        }
        #endregion

        #region CommandSetScreen
        public DelegateCommand<string> CommandSetScreen { get; private set; }

        private void ExecuteCommandSetScreen(string commandParameter)
        {
            try
            {
                if (!string.IsNullOrEmpty(commandParameter))
                {
                    switch (commandParameter)
                    {
                        case "btnOneScreen":
                            SetVideoGridScreen(1);
                            break;
                        case "btnTowScreen":
                            SetVideoGridScreen(2);
                            break;
                        case "btnThreeScreen":
                            SetVideoGridScreen(3);
                            break;
                        case "btnFourScreen":
                            SetVideoGridScreen(4);
                            break;
                        case "btnSixScreen":
                            SetVideoGridScreen(6);
                            break;
                        case "btnNineScreen":
                            SetVideoGridScreen(9);
                            break;
                        case "btnTwelveScreen":
                            SetVideoGridScreen(12);
                            break;
                        case "btnSixteenScreen":
                            SetVideoGridScreen(16);
                            break;
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("分屏失败，稍后重试！");
                Logger.Error("选择分屏设置命令异常：CommandSetScreen", err);
            }
        }

        private bool CanCommandSetScreen(string commandParameter)
        {
            return true;
        }
        #endregion

        #region RefreshChannel
        public DelegateCommand<string> CommandRefreshChannel { get; private set; }

        private void ExecuteCommandRefreshChannel(string commandParameter)
        {
            try
            {

            }
            catch (Exception err)
            {

            }
        }

        private bool CanCommandRefreshChannel(string commandParameter)
        {
            return true;
        }
        #endregion

        #region Event

        private void OnRealtimeCaptureEvent(CapFaceLogWithImgData obj)
        {
            if (obj == null) return;
            CurrentCapFaceLogWithImgData = null;
            CurrentCapFaceLogWithImgData = obj;
            ResetServerRealtimeCapInfo.Set();
        }

        private void OnRealtimeCmpInfoEvent(RealtimeCmpInfoViewData obj)
        {
            if (obj == null) return;
            CurrentRealtimeCmpInfoViewData = null;
            CurrentRealtimeCmpInfoViewData = obj;
            ResetServerRealtimeCapInfo.Set();
        }

        #endregion

        #region INavigationAware Members
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // Called to see if this view can handle the navigation request.
            // If it can, this view is activated.
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Called when this view is deactivated as a result of navigation to another view.
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Called to initialize this view during navigation.

            // Retrieve any required paramaters from the navigation Uri.
            string id = navigationContext.Parameters["ID"];

        }
        #endregion

        #region SofaCommonEventHandler


        public SofaComponent ThisSofaComponent;
        public IBaseContainer Container;

        public void SofaCommonEventHandler(object sender, SofaEventArgs e)
        {
            if (e.TargetGUID == ThisSofaComponent.GUID)
            {
                if (e.EventType == "PostOpen")
                {



                }

                if (e.EventType == "DataItemSelected")
                {

                }

            }

            if (e.EventType == "GotFocus")
            {
                e.Handled = true;
            }

            if (e.EventType == "Closed")
            {

            }

        }

        public void SofaCommonCancelEventHandler(object sender, SofaCancelEventArgs e)
        {

        }
        #endregion
    }
}
