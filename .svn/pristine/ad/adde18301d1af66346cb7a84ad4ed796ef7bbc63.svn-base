using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Windows;
using SING.Data.Logger;

namespace FACE_ChannelManagement.ViewModels
{
    /// <summary>
    /// //ChannelGridViewModel
    /// </summary>
    public partial class ViewModel : NotificationObject
    {
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

        #region Properties

        Visibility _isViewChannelList;//是否查看通道列表
        Visibility _isEditChannelCameraInfo;//是否编辑摄像头信息       
        ChannelCameraCfgModel _linkCameraChannel;//连接摄像头所需的参数
        private bool isSelectedCamera;

        private ChannelTreeViewModel channelVModel { get; set; }
        private IList<CameraSelectedItemModel> cameras = new List<CameraSelectedItemModel>();
        private CameraSelectedItemModel camera;       


        #region 通道分组及摄像头通道

        /// <summary>
        /// 通道组下所有的摄像头列表
        /// </summary>
        public IList<CameraSelectedItemModel> Cameras
        {
            get { return cameras; }
            set { cameras = value; RaisePropertyChanged("Cameras"); }
        }

        /// <summary>
        /// 该通道组下当前选中的摄像头
        /// </summary>
        public CameraSelectedItemModel Camera
        {
            get { return camera; }
            set { camera = value; RaisePropertyChanged("Camera"); }
        }
        #endregion //通道组及通道 

        #region Properties

        /// <summary>
        /// 连接到摄像头所需要的参数
        /// </summary>
        public ChannelCameraCfgModel LinkCameraChannel
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

        public void InitChannelGridViewModel()
        {
            PreviewCameraCommand = new DelegateCommand(PreviewCameraFunc);
            EditCameraCommand = new DelegateCommand<object>(EditCameraFunc);
            DeleteCameraCommand = new DelegateCommand<object>(DeleteCameraFunc);
            AddCameraInfoCommand = new DelegateCommand(AddCameraInfoFunc);

            IsViewChannelList = Visibility.Visible;
            IsEditChannelCameraInfo = Visibility.Collapsed;

            //初始化OCX控件载体

            //初始化默认分屏


            for (int i = 0; i < 100; i++)
            {
                Cameras.Add(new CameraSelectedItemModel()
                {
                    CameraName = "Camera" + i,
                    IsOpen = false
                });
            }

        }

        private void AddCameraInfoFunc()
        {
            IsEditChannelCameraInfo = Visibility.Visible;
            IsViewChannelList = Visibility.Collapsed;
        }

        private void PreviewCameraFunc()
        {
            try
            {
                if (Camera != null && Cameras.Count > 0)
                {
                    MessageBox.Show(Camera.CameraName);
                }
                else
                {

                }
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
                if (Camera != null && Cameras.Count > 0)
                {
                    string cameraName = Camera.CameraName;
                    Cameras.Remove(Camera);
                }
                else
                {

                }
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
                if (Camera != null && Cameras.Count > 0)
                {
                    MessageBox.Show(Camera.CameraName);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("ViewModel.EditCameraFunc\n摄像头预览出现异常：【{0}】", ex.Message));
            }
        }
    }
}
