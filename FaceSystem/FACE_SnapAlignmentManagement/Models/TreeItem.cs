using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Data;

namespace FACE_SnapAlignmentManagement.Models
{
    public class TreeItem: INotifyPropertyChanged
    {
        public string Header { get; set; }
        public string Distance { get; set; }
        public bool IsChannel { get; set; }
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
        public string Tooltip { get; set; }
        public ZoneCfgData zoneCfg { get; set; }
        public List<TreeItem> Child { get; set; }
        public ChannelCfgData channelCfg { get; set; }
        public bool IsExpended { set; get; }
        public TreeItem()
        {
            Child = new List<TreeItem>();
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
