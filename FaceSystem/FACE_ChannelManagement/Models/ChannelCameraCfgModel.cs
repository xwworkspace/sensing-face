using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FACE_ChannelManagement.Models
{
    public class ChannelCameraCfgModel
    {
        public string TcChaneelID { get; set; }
        public string TcUID { get; set; }
        public string TcPSW { get; set; }
        public string Name { get; set; }
        public string TcDescription { get; set; }
        public CaptureCfg CaptureCfg { get; set; }
        public CatchFaceCfg CatchFaceCfg { get; set; }
        public string Addr { get; set; }
        public int Port { get; set; }
        public ImageSource ImageSource { get; set; }
        public ChannelCfg MyChannelCfgToChannelCfg(ChannelCameraCfgModel _MyChannelCfg)
        {
            ChannelCfg _ChannelCfg = new ChannelCfg();
            _ChannelCfg.TcChaneelID = _MyChannelCfg.TcChaneelID;
            _ChannelCfg.TcUID = _MyChannelCfg.TcUID;
            _ChannelCfg.TcPSW = _MyChannelCfg.TcPSW;
            _ChannelCfg.Name = _MyChannelCfg.Name;
            _ChannelCfg.TcDescription = _MyChannelCfg.TcDescription;
            _ChannelCfg.CaptureCfg = _MyChannelCfg.CaptureCfg;
            _ChannelCfg.CatchFaceCfg = _MyChannelCfg.CatchFaceCfg;
            _ChannelCfg.Addr = _MyChannelCfg.Addr;
            _ChannelCfg.Port = _MyChannelCfg.Port;
            return _ChannelCfg;
        }
        public ChannelCameraCfgModel ChannelCfgToMyChannelCfg(ChannelCfg _ChannelCfg)
        {
            ChannelCameraCfgModel _MyChannelCfg = new ChannelCameraCfgModel();
            _MyChannelCfg.TcChaneelID = _ChannelCfg.TcChaneelID;
            _MyChannelCfg.TcUID = _ChannelCfg.TcUID;
            _MyChannelCfg.TcPSW = _ChannelCfg.TcPSW;
            _MyChannelCfg.Name = _ChannelCfg.Name;
            _MyChannelCfg.TcDescription = _ChannelCfg.TcDescription;
            _MyChannelCfg.CaptureCfg = _ChannelCfg.CaptureCfg;
            _MyChannelCfg.CatchFaceCfg = _ChannelCfg.CatchFaceCfg;
            _MyChannelCfg.Addr = _ChannelCfg.Addr;
            _MyChannelCfg.Port = _ChannelCfg.Port;
            return _MyChannelCfg;
        }
    }
}
