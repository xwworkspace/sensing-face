﻿using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Input;
using System;
using System.Windows;
using SING.Data.Logger;
using System.ComponentModel;
using System.Collections.Generic;
using SING.Data.Data;

namespace FACE_ChannelManagement.ViewModels
{
    /// <summary>
    /// //ChannelGridViewModel
    /// 摄像头列表显示页
    /// </summary>
    public partial class ViewModel : NotificationObject
    {
        #region 方法
        /// <summary>
        /// 初始化器
        /// </summary>
        void InitChannelGridViewModel()
        {
            PreviewCameraCommand = new DelegateCommand(PreviewCameraFunc);
            EditCameraCommand = new DelegateCommand<object>(EditCameraFunc);
            DeleteCameraCommand = new DelegateCommand<object>(DeleteCameraFunc);
            AddCameraInfoCommand = new DelegateCommand(AddCameraInfoFunc);

            IsViewChannelList = Visibility.Visible;
            IsEditChannelCameraInfo = Visibility.Collapsed;

            //初始化OCX控件载体
        }

        void AddCameraInfoFunc()
        {
            IsEditChannelCameraInfo = Visibility.Visible;
            IsViewChannelList = Visibility.Collapsed;

            ChannelInfoData.Title = "添加通道数据";
            isAddChannelData = true;//添加新的通道数据
            //初始化通道数据
            this.InitChannelCameraInfoData();

        }
        #endregion //方法

        #region Properties

        Visibility _isViewChannelList;//是否查看通道列表
        Visibility _isEditChannelCameraInfo;//是否编辑摄像头信息       
        ChannelConfigData _linkCameraChannel;//连接摄像头所需的参数
        private bool isSelectedCamera;

        private ChannelTreeViewModel channelVModel { get; set; }
        private ICollectionView cameras;
        private ChannelConfigData camera;

        #region 通道分组及摄像头通道

        #region deleted
        //private ChannelCfgViewData _channelCurrentItem;

        //public ChannelCfgViewData ChannelCurrentItem
        //{
        //    get { return _channelCurrentItem; }
        //    set
        //    {
        //        _channelCurrentItem = value;
        //        RaisePropertyChanged("ChannelCurrentItem");
        //    }
        //}

        //private ICollectionView _channelListCV;
        //public ICollectionView ChannelListCV
        //{
        //    get
        //    {
        //        return _channelListCV;
        //    }
        //    set
        //    {
        //        _channelListCV = value;
        //        RaisePropertyChanged("ChannelListCV");
        //    }
        //} 
        #endregion

        /// <summary>
        /// 通道组下所有的摄像头列表
        /// </summary>
        public ICollectionView Cameras
        {
            get { return cameras; }
            set { cameras = value; RaisePropertyChanged("Cameras"); }
        }

        /// <summary>
        /// 该通道组下当前选中的摄像头
        /// </summary>
        public ChannelConfigData Camera
        {
            get { return camera; }
            set { camera = value; RaisePropertyChanged("Camera"); }
        }
        #endregion //通道组及通道 

        #region Properties

        /// <summary>
        /// 连接到摄像头所需要的参数
        /// </summary>
        public ChannelConfigData LinkCameraChannel
        {
            get { return _linkCameraChannel; }
            set { _linkCameraChannel = value; }
        }

        public Visibility IsViewChannelList
        {
            get { return _isViewChannelList; }
            set { _isViewChannelList = value; this.RaisePropertyChanged("IsViewChannelList"); }
        }

        public Visibility IsEditChannelCameraInfo
        {
            get { return _isEditChannelCameraInfo; }
            set { _isEditChannelCameraInfo = value; this.RaisePropertyChanged("IsEditChannelCameraInfo"); }
        }

        #endregion //Properties

        #endregion //Properties

        #region Command
        public ICommand PreviewCameraCommand { get; private set; }
        /// <summary>
        /// 编辑摄像头参数 （即：通道参数信息）
        /// </summary>
        public ICommand EditCameraCommand { get; private set; }
        /// <summary>
        /// 删除摄像头
        /// </summary>
        public ICommand DeleteCameraCommand { get; private set; }
        /// <summary>
        /// 添加摄像头信息
        /// </summary>
        public ICommand AddCameraInfoCommand { get; private set; }
        #endregion //Command

        #region Command指令执行方法
        private void PreviewCameraFunc()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("ViewModel.PreviewCameraFunc\n摄像头预览出现异常：【{0}】", ex.Message));
            }
        }

        /// <summary>
        /// 删除当前摄像头 及其通道配置信息
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteCameraFunc(object obj)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("ViewModel.DeleteCameraFunc\n摄像头预览出现异常：【{0}】", ex.Message));
            }
        }

        /// <summary>
        /// 编辑当前摄像头 及其通道配置信息
        /// </summary>
        /// <param name="obj"></param>
        private void EditCameraFunc(object obj)
        {
            try
            {
                IsEditChannelCameraInfo = Visibility.Visible;
                IsViewChannelList = Visibility.Collapsed;

                channelInfoData.Title = "编辑通道数据";
                isAddChannelData = false;//添加新的通道数据
                                
                //加载通道类型
                List<string> channelType = new List<string>();
                _dataService.InitChannelType(this, ref channelType);                
                
                //加载视频源类型
                List<string> cameraSourceType = new List<string>();
                _dataService.InitChannelCameraSourceType(this, ref cameraSourceType);               

                ChannelConfigData da = obj as ChannelConfigData;
                ChannelCfg thriftData = ChannelCfgData.Convert(da.ChannelCfgData);
                channelInfoData = _dataService.ConvertToViewData(thriftData);//视图与DB数据转换
                channelInfoData.ChannelType = channelType;
                channelInfoData.CaptureType = cameraSourceType;

                RaisePropertyChanged("ChannelInfoData");//刷新
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("ViewModel.EditCameraFunc\n摄像头预览出现异常：【{0}】", ex.Message));
            }
        }
        #endregion
    }
}
