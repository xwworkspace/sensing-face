namespace FACE_ChannelManagement.Models
{
    /// <summary>
    /// ListBox中的各摄像头问题
    /// </summary>
    public class CameraSelectedItemModel
    {
        /// <summary>
        /// 摄像头名称
        /// </summary>
        public string CameraName { get; set; }

        /// <summary>
        /// 摄像头是否开启
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// 链接摄像头所需的配置信息
        /// </summary>
        public ChannelCfgViewData CameraConfig { get; set; }
    }
}
