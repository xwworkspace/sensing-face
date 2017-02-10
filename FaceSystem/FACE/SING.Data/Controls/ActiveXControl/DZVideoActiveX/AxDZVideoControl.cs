using System.Windows.Forms;

namespace SING.Data.Controls.ActiveXControl.DZVideoActiveX
{
    public partial class AxDZVideoControl : UserControl
    {
        public AxDZVideoControl()
        {
            InitializeComponent();
            axDZVideoActiveX1.Dock = DockStyle.Fill;
        }

        public void OpenCamera(int type, string ip, uint port, string uid, string psw, uint index, byte show)
        {
            uint _index = index;
            switch (type)
            {
                case 0: //未知设备
                    break;
                case 1: // 网络摄像头 rtsp
                case 3: // 海康威视摄像头
                    _index = 1;
                    break;
                case 2: // USB摄像头
                case 4: // 宇视摄像头
                case 5: // 大华RTSP
                    _index = 0;
                    break;
                default:
                    axDZVideoActiveX1.OpenCamera(1, ip, port, uid, psw, index, show);
                    break;
            }
            axDZVideoActiveX1.OpenCamera(type, ip, port, uid, psw, index, show);
        }
        public void CloseCamera()
        {
            axDZVideoActiveX1.CloseCamera();
        }
    }
}
