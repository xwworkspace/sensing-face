using Microsoft.Practices.Prism.ViewModel;

namespace FACE_ChannelManagement.Models
{
    public class ChannelCameraCfgModel : NotificationObject
    {
        public ChannelCameraCfgModel ChannelCfgData { get; set; }

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
