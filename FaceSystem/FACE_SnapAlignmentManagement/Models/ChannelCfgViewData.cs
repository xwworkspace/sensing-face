using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Data;

namespace FACE_SnapAlignmentManagement.Models
{
    public class ChannelCfgViewData: INotifyPropertyChanged
    {
        public ChannelCfgData ChannelCfgData { get; set; }

        private bool isOpened { get; set; }
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                this.OnPropertyChanged("IsOpened");
            }
        }

        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
