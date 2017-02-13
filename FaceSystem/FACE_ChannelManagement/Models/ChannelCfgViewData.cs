using Microsoft.Practices.Prism.ViewModel;
using SING.Data.Data;

namespace FACE_ChannelManagement.Models
{
    public class ChannelCfgViewData : NotificationObject
    {
        public ChannelCfgData ChannelCfgData { get; set; }

        private bool isOpened { get; set; }
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                this.RaisePropertyChanged("IsOpened");
            }
        }
    }
}
