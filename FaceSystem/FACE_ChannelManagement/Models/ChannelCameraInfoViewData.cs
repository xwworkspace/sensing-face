using System.Collections.Generic;

namespace FACE_ChannelManagement.Models
{
    public class ChannelCameraInfoViewData
    {
        #region 属性的声明
        private string title { get; set; }
        /// <summary>
        /// 标题栏
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }

        #region 通道参数设置

        private string channelId { get; set; }
        /// <summary>
        /// 通道编号
        /// </summary>
        public string ChannelId
        {
            get { return channelId; }
            set
            {
                channelId = value;
            }
        }

        private string channelName { get; set; }
        /// <summary>
        /// 通道名称
        /// </summary>
        public string ChannelName
        {
            get { return channelName; }
            set
            {
                channelName = value;
            }
        }

        private int selectedChannelType { get; set; }
        /// <summary>
        /// 通道类型选中项
        /// </summary>
        public int SelectedChannelType
        {
            get { return selectedChannelType; }
            set
            {
                selectedChannelType = value;
            }
        }

        private List<string> channelType { get; set; }
        /// <summary>
        /// 通道类型
        /// </summary>
        public List<string> ChannelType
        {
            get { return channelType; }
            set
            {
                channelType = value;
            }
        }

        private string captureAddr { get; set; }
        /// <summary>
        /// 抓拍服务器地址
        /// </summary>
        public string CaptureAddr
        {
            get { return captureAddr; }
            set
            {
                captureAddr = value;
            }
        }


        private string capturePort { get; set; }
        /// <summary>
        /// 视频源端口
        /// </summary>
        public string CapturePort
        {
            get { return capturePort; }
            set
            {
                capturePort = value;
            }
        }

        private string remark { get; set; }
        /// <summary>
        /// 通道备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set
            {
                remark = value;
            }
        }

        #endregion

        #region 图像源参数设置

        private int selectedType { get; set; }
        /// <summary>
        /// 视频源类型选中项
        /// </summary>
        public int SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
            }
        }

        private List<string> captureType { get; set; }
        /// <summary>
        /// 视频源类型
        /// </summary>
        public List<string> CaptureType
        {
            get { return captureType; }
            set
            {
                captureType = value;
            }
        }

        private string videoAddr { get; set; }
        /// <summary>
        /// 视频源地址
        /// </summary>
        public string VideoAddr
        {
            get { return videoAddr; }
            set
            {
                videoAddr = value;
            }
        }


        private string videoPort { get; set; }
        /// <summary>
        /// 视频源端口
        /// </summary>
        public string VideoPort
        {
            get { return videoPort; }
            set{videoPort = value;}
        }


        private string uID { get; set; }
        /// <summary>
        /// 登录相机用户名
        /// </summary>
        public string UID
        {
            get { return uID; }
            set
            {
                uID = value;
            }
        }


        private string pSW { get; set; }
        /// <summary>
        /// 登录相机端密码
        /// </summary>
        public string PSW
        {
            get { return pSW; }
            set
            {
                pSW = value;
            }
        }


        #endregion

        #region 人脸抓拍参数设置

        private string minFace { get; set; }
        /// <summary>
        /// 最小检测尺寸
        /// </summary>
        public string MinFace
        {
            get { return minFace; }
            set
            {
                minFace = value;
            }
        }

        private string minQuality { get; set; }
        /// <summary>
        /// 最小有效图像质量
        /// </summary>
        public string MinQuality
        {
            get { return minQuality; }
            set
            {
                minQuality = value;
            }
        }

        private string minCapDistance { get; set; }
        /// <summary>
        /// 最小采集帧间隔
        /// </summary>
        public string MinCapDistance
        {
            get { return minCapDistance; }
            set
            {
                minCapDistance = value;
            }
        }

        private string maxFaceSaveDistance { get; set; }
        /// <summary>
        /// 最大人脸存储间隔
        /// </summary>
        public string MaxFaceSaveDistance
        {
            get { return maxFaceSaveDistance; }
            set
            {
                maxFaceSaveDistance = value;
            }
        }

        private string yaw { get; set; }
        /// <summary>
        /// x轴 俯仰角
        /// </summary>
        public string Yaw
        {
            get { return yaw; }
            set
            {
                yaw = value;
            }
        }

        private string pitch { get; set; }
        /// <summary>
        /// y轴 偏航角
        /// </summary>
        public string Pitch
        {
            get { return pitch; }
            set
            {
                pitch = value;
            }
        }

        private string yoll { get; set; }
        /// <summary>
        /// z轴 翻滚角
        /// </summary>
        public string Yoll
        {
            get { return yoll; }
            set
            {
                yoll = value;
            }
        }
        #endregion

        #endregion
    }
}
