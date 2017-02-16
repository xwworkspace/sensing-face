using FACE_ChannelManagement.Models;
using FACE_ChannelManagement.Services.ChannelServices;
using Microsoft.Practices.Prism.ViewModel;
using SING.Data.Controls.ActiveXControl.DZVideoActiveX;
using SING.Data.Data;
using SING.Data.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Resources;

namespace FACE_ChannelManagement.ViewModels
{
    /// <summary>
    /// ChannelPreviewViewModel
    /// 通道预览视图 viewModel
    /// </summary>
    public partial class ViewModel : NotificationObject
    {
        #region ViewLableTile

        private string _cameraPreview;
        public string CameraPreview
        {
            get { return _cameraPreview; }
            set
            {
                _cameraPreview = value;
                RaisePropertyChanged("CameraPreview");
            }
        }


        #endregion


        #region MyRegion
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
        private ChannelConfigData channelListItem;
        public ChannelConfigData ChannelListItem
        {
            get { return channelListItem; }
            set
            {
                channelListItem = value;
                RaisePropertyChanged("ChannelListItem");
            }
        }

        private List<ChannelConfigData> channelList;
        public List<ChannelConfigData> ChannelList
        {
            get { return channelList; }
            set
            {
                channelList = value;
                RaisePropertyChanged("ChannelList");
            }
        }
        #endregion


        #region 初始化通道列表


        /// <summary>
        /// 监听服务器实时上传的抓拍信息
        /// </summary>
        public ManualResetEvent ResetServerRealtimeCapInfo;
        /// <summary>
        /// 监听服务器实时上传的比对信息
        /// </summary>
        public ManualResetEvent ResetServerRealtimeCmpInfo;
        ///// <summary>
        ///// 当前正在播放的视频数量
        ///// </summary>
        //private int currentVideo = 0;
        ///// <summary>
        ///// 当前分屏允许的最大分屏数量
        ///// </summary>
        //private int currentMaxvideo = 0;


        private void InitialChannel()
        {
            _dataService.InitialChannel(this);
        }

        #region 初始化阈值
        private void IniThreshold()
        {
            _dataService.InitThreshold(this);
        }
        #endregion

        public void ChannelListItemChanged(object sender, EventArgs e)
        {
            if (true)
            {

            }
            if (Cameras != null && Cameras.CurrentItem != null)
            {
                Camera = Cameras.CurrentItem as ChannelConfigData;
                CameraPreview = Camera.ChannelCfgData.Name;//视频预览窗口抬头
                if (varPrevSelectedCamera == null)
                {
                    varPrevSelectedCamera = Camera;//上一次选中的摄像头
                }
                //not null，即：有一个已被选中，且与当前选中的相同
                else if (varPrevSelectedCamera != Camera)
                {
                    //关闭上一个预览的摄像头
                    CloseChannelService.CloseChannelFunc(WfhList, varPrevSelectedCamera)();

                    //然后设置当前选中的摄像头为上一个
                    varPrevSelectedCamera = Camera;
                }
            }

            ChannelCfg channelCfg = ChannelCfgData.Convert(Camera.ChannelCfgData);
            ChannelInfoData = _dataService.ConvertToViewData(channelCfg);

            ChannelVideoSearch();
        }

        private void ChannelVideoSearch()
        {
            if (Camera == null) return;
            try
            {
                string IP = Camera.ChannelCfgData.CaptureCfgData.TcAddr;
                if (IP == string.Empty)
                {
                    System.Windows.MessageBox.Show("摄像机IP为空！");
                    return;
                }

                if (Camera.IsOpened == false)
                {
                    Camera.IsOpened = true;

                    AxDZVideoControl AxVideoControl = new AxDZVideoControl();
                    AxVideoControl.OpenCamera(Camera.ChannelCfgData.CaptureCfgData.NCaptureType,
                                                Camera.ChannelCfgData.CaptureCfgData.TcAddr + "|" +
                                                Camera.ChannelCfgData.TcDescription, (uint)Camera.ChannelCfgData.CaptureCfgData.NPort,
                                                Camera.ChannelCfgData.CaptureCfgData.TcUID, Camera.ChannelCfgData.CaptureCfgData.TcPSW, 1, 1);

                    foreach (WindowsFormsHost wfh in WfhList)
                    {
                        if (wfh.Tag == null)
                        {
                            wfh.Child = AxVideoControl;
                            wfh.Tag = Camera.ChannelCfgData.TcChaneelID;
                            break;
                        }
                    }

                    CameraVideoPlayerFunc(WfhList, AxVideoControl, Camera)();
                    SingleScreen(1)();// 设置分屏
                }
                else
                {
                    CloseChannelService.CloseChannelFunc(WfhList, Camera)();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("摄像机无法连接！");
                Logger.Error("通道摄像机连接异常，方法名：ChannelListItemChanged", ex);
            }
        }

        #endregion
        
    }
}
