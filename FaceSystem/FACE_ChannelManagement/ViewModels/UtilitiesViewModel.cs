
using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.ViewModel;
using SING.Data.Controls.ActiveXControl.DZVideoActiveX;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Resources;

namespace FACE_ChannelManagement.ViewModels
{
    /// <summary>
    /// UtilitiesViewModel
    /// 
    /// 因为mef导致有些功能无法使用，暂时提供该解决方案
    /// </summary>
    public partial class ViewModel : NotificationObject
    {

        #region Camera Screen Channel 
        /**
         * 通道影像播放的问题均来自这里
         * 
         * **/


        /// <summary>
        /// 加载影像播放控件
        /// </summary>
        private Action IniWindowsFormsHostlist()
        {
            Action act = () =>
            {
                WfhList = new List<WindowsFormsHost>();
                WindowsFormsHost wfh = new WindowsFormsHost();
                wfh.Tag = null;
                WfhList.Add(wfh);
            };
            return act;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowsFormHostList"></param>
        /// <param name="videoPlayerCtrlCom"></param>
        /// <param name="CameraData"></param>
        /// <returns></returns>
        private Action CameraVideoPlayerFunc(List<WindowsFormsHost> windowsFormHostList, AxDZVideoControl videoPlayerCtrlCom, ChannelConfigData CameraData)
        {
            Action act = () =>
            {
                if (WfhList != null && WfhList.Count >= 1)
                {
                    WindowsFormsHost wfh = WfhList[0];
                    if (wfh.Tag == null)
                    {
                        wfh.Child = videoPlayerCtrlCom;
                        wfh.Tag = Camera.ChannelCfgData.TcChaneelID;

                        Camera.IsOpened = true;//此摄像头标记为开启状态
                    }
                }
            };
            return act;
        }

        /// <summary>
        /// 设置分屏,并添加子项
        /// </summary>
        /// <param name="i">几分屏</param>
        public Action SingleScreen(int sceenCount)
        {
            Action act = () =>
            {
                //页面上若已存在，必须执行清理工作
                if (VideoPartGrid == null) VideoPartGrid = new Grid();
                try
                {
                    //清理上次播放遗留组件
                    for (int i = 0; i < VideoPartGrid.Children.Count; i++)
                    {
                        ((Grid)VideoPartGrid.Children[i]).Children.Clear();
                    }

                    VideoPartGrid.Children.Clear();
                    VideoPartGrid.RowDefinitions.Clear();
                    VideoPartGrid.ColumnDefinitions.Clear();

                    VideoPartGrid.RowDefinitions.Add(new RowDefinition());
                    VideoPartGrid.ColumnDefinitions.Add(new ColumnDefinition());

                    Grid screenGrid = new Grid();
                    ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                    StreamResourceInfo streamResourceInfo;
                    string resourceStr = string.Empty;
                    resourceStr = @"pack://application:,,,/FACE;component/Resources/noVideoBackground.png";
                    streamResourceInfo = Application.GetResourceStream(new Uri(resourceStr, UriKind.Absolute));
                    screenGrid.Background = new ImageBrush((ImageSource)imageSourceConverter.ConvertFrom(streamResourceInfo.Stream));

                    screenGrid.Children.Add(WfhList[0]);
                    VideoPartGrid.Children.Add(screenGrid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
            return act;
        }

        #endregion

    }
}
