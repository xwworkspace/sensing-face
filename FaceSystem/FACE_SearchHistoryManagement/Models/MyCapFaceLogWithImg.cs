using System.Windows.Media;

namespace FACE_SearchHistoryManagement.Models
{
    public class MyCapFaceLogWithImg
    {
        public int Id { get; set; }//类Id
        public string ID { get; set; }//抓拍ID
        public string ChannelID { get; set; }//通道ID
        public string ChannelName { get; set; }//通道名称
        public string Time { get; set; }//抓拍时间
        public string TimeIn { get; set; }//对象进入摄像头时间
        public string TimeOut { get; set; }
        public int Quality { get; set; }
        public int Age { get; set; }//年龄
        public int Genger { get; set; }//性别
        public ImageSource Image { get; set; }//

        public ImageSource EnvironmentImage { get; set; }//场景对象
        public ImageSource SnapImage { get; set; }//抓拍对象
        public Brush SnapBackground { get; set; }
    }
}
