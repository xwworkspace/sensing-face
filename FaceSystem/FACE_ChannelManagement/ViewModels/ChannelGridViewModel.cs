using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using SING.Data.Controls.ActiveXControl.DZVideoActiveX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Input;

namespace FACE_ChannelManagement.ViewModels
{
    public class ChannelGridViewModel : NotificationObject
    {
        public ICommand SelectedCameraCommand { get; private set; }
        private ChannelViewModel channelVModel { get; set; }

        ChannelCameraCfgModel _linkCameraChannel;//连接摄像头所需的参数

        #region Properties

        /// <summary>
        /// 连接到摄像头所需要的参数
        /// </summary>
        public ChannelCameraCfgModel LinkCameraChannel
        {
            get { return _linkCameraChannel; }
            set { _linkCameraChannel = value; }
        }

        #endregion //Properties

        public ChannelGridViewModel(ChannelViewModel channelvmodel)
        {
            //初始化OCX控件载体
            for (int i = 0; i < 16; i++)
            {
                WindowsFormsHost wfh = new WindowsFormsHost();
                wfh.Tag = null;
                wFHList.Add(wfh);
            }

            //初始化默认分屏

            SelectedCameraCommand = new DelegateCommand<object>(SelectedCameraFunc);
        }

        List<WindowsFormsHost> wFHList = new List<WindowsFormsHost>();
        int currentPlayVideoCount = 0;
        int currentMaxPlayvideoCount = 0;
        private void SelectedCameraFunc(object obj)
        {
            try
            {
                ChannelListItemViewModel lbi = (obj as ListBox).SelectedItem as ChannelListItemViewModel;
                if (lbi == null)
                {
                    return;
                }
                string ip = lbi.MyChannelCfg.CaptureCfg.TcAddr;
                if (ip == string.Empty)
                {
                    System.Windows.MessageBox.Show("摄像机IP为空！");
                    return;
                }
                if (lbi.IsOpened == false)
                {
                    lbi.IsOpened = true;
                    currentPlayVideoCount++;
                    AxDZVideoControl usercontrol = new AxDZVideoControl();
                    usercontrol.OpenCamera(lbi.MyChannelCfg.CaptureCfg.NCaptureType, lbi.MyChannelCfg.CaptureCfg.TcAddr + "|" + lbi.MyChannelCfg.TcDescription, (uint)lbi.MyChannelCfg.CaptureCfg.NPort, lbi.MyChannelCfg.CaptureCfg.TcUID, lbi.MyChannelCfg.CaptureCfg.TcPSW, 1, 1);
                    foreach (WindowsFormsHost wfh in wFHList)
                    {
                        if (wfh.Tag == null)
                        {
                            wfh.Child = usercontrol;
                            wfh.Tag = lbi.MyChannelCfg.TcChaneelID;
                            break;
                        }
                    }
                    if (currentPlayVideoCount > currentMaxPlayvideoCount)
                    {
                        SetVideoGridScreen(currentPlayVideoCount);
                    }

                    //usercontrol.Update();
                    this.UpdateLayout();
                    
                }
                else
                {
                    currentPlayVideoCount--;
                    foreach (WindowsFormsHost wfh in wFHList)
                    {
                        if (wfh.Tag != null && wfh.Tag.ToString() == lbi.MyChannelCfg.TcChaneelID)
                        {
                            (wfh.Child as AxDZVideoControl).CloseCamera();
                            //wfh.Child = null;
                            //wfh.Child.Dispose();
                            wfh.Child = null;
                            wfh.Tag = null;
                            break;
                        }
                    }
                    lbi.IsOpened = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置摄像头显示分屏
        /// </summary>
        /// <param name="currentPlayVideoCount"></param>
        private void SetVideoGridScreen(int currentPlayVideoCount)
        {
            throw new NotImplementedException();
        }
    }
}
