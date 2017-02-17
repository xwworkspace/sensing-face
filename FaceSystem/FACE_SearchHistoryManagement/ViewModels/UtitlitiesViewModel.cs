using FACE_SearchHistoryManagement.Models;
using Microsoft.Practices.Prism.ViewModel;
using SING.Data.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace FACE_SearchHistoryManagement.ViewModels
{
    /// <summary>
    /// UtitlitiesViewModel
    /// </summary>
    public partial class ViewModel : NotificationObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void ThreadQueuenViewSnapHistory(object obj)
        {
            try
            {
                #region
                MyCapFaceLogWithImg _MyCapFaceLogWithImg = (MyCapFaceLogWithImg)obj; ;
                List<byte[]> listImageBytes = new List<byte[]>();
                listImageBytes = _dataService.QueryCapLogImageH(_MyCapFaceLogWithImg.ID, currDay);
                //得到图片
                if (listImageBytes[0].Length > 0)
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                    {
                        _historySnapSelectedItem.SnapImage = new BitmapImage(new Uri("pack://application:,,,/Images/抓拍照片纯背景.png"));
                    }));

                    //读入MemoryStream对象
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                    {
                        //btnPicCaptureRecord.Visibility = Visibility.Visible;
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        myBitmapImage.StreamSource = new System.IO.MemoryStream(listImageBytes[0]);
                        myBitmapImage.EndInit();
                        _historySnapSelectedItem.SnapBackground = new ImageBrush { ImageSource = myBitmapImage };
                        myBitmapImage = null;
                    }));

                    List<byte[]> senceImg = _dataService.QuerySenceImg(_MyCapFaceLogWithImg.ID, _MyCapFaceLogWithImg.Time.Split(' ')[0].Replace(@"/", "").Replace(@"/", ""));
                    if (senceImg != null && senceImg.Count > 0 && senceImg[0].Length > 0)
                    {
                        Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                        {
                            BitmapImage bitImage = new BitmapImage();
                            bitImage.BeginInit();
                            bitImage.StreamSource = new System.IO.MemoryStream(senceImg[0]);
                            bitImage.EndInit();
                            _historySnapSelectedItem.EnvironmentImage = bitImage;
                        }));
                    }
                    else
                    {
                        Dispatcher.CurrentDispatcher.BeginInvoke(
                            new Action(() =>
                        { _historySnapSelectedItem.EnvironmentImage = null; }
                        ));
                    }
                }
                else
                {
                    //MyMessage.showYes("未查询到结果");
                    //btnPicCaptureRecord.Dispatcher.BeginInvoke(new Action(() =>
                    //{ btnPicCaptureRecord.Background = null; }));
                }

                #endregion
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("threadlistViewCaptureRecord", ex));
                //MyMessage.showYes(ex.Message); 
            }
            Thread.CurrentThread.Abort();
        }
    }
}
