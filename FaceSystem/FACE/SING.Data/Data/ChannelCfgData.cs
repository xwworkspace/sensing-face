using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class ChannelCfgData : INotifyPropertyChanged
    {
        private string _tcChaneelID;
        private string _tcUID;
        private string _tcPSW;
        private string _name;
        private string _tcDescription;
        private CaptureCfgData _captureCfgData;
        private CatchFaceCfgData _catchFaceCfgData;
        private string _addr;
        private int _port;
        private string _div_index;
        private int _sst;

        public virtual string TcChaneelID
        {
            get
            {
                return _tcChaneelID;
            }
            set
            {
                this._tcChaneelID = value;
                OnPropertyChanged("TcChaneelID");
            }
        }

        public virtual string TcUID
        {
            get
            {
                return _tcUID;
            }
            set
            {
                this._tcUID = value;
                OnPropertyChanged("TcUID");
            }
        }

        public virtual string TcPSW
        {
            get
            {
                return _tcPSW;
            }
            set
            {
                this._tcPSW = value;
                OnPropertyChanged("TcPSW");
            }
        }

        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this._name = value;
                OnPropertyChanged("Name");
            }
        }

        public virtual string TcDescription
        {
            get
            {
                return _tcDescription;
            }
            set
            {
                this._tcDescription = value;
                OnPropertyChanged("TcDescription");
            }
        }

        public virtual CaptureCfgData CaptureCfgData
        {
            get
            {
                return _captureCfgData;
            }
            set
            {
                this._captureCfgData = value;
                OnPropertyChanged("CaptureCfgData");
            }
        }

        public virtual CatchFaceCfgData CatchFaceCfgData
        {
            get
            {
                return _catchFaceCfgData;
            }
            set
            {
                this._catchFaceCfgData = value;
                OnPropertyChanged("CatchFaceCfgData");
            }
        }

        public virtual string Addr
        {
            get
            {
                return _addr;
            }
            set
            {
                this._addr = value;
                OnPropertyChanged("Addr");
            }
        }

        public virtual int Port
        {
            get
            {
                return _port;
            }
            set
            {
                this._port = value;
                OnPropertyChanged("Port");
            }
        }

        public virtual string Div_index
        {
            get
            {
                return _div_index;
            }
            set
            {
                this._div_index = value;
                OnPropertyChanged("Div_index");
            }
        }

        public virtual int Sst
        {
            get
            {
                return _sst;
            }
            set
            {
                this._sst = value;
                OnPropertyChanged("Sst");
            }
        }
        public static ChannelCfg Convert(ChannelCfgData oridata)
        {
            ChannelCfg target = new ChannelCfg();
            target.TcChaneelID = oridata.TcChaneelID;
            target.TcUID = oridata.TcUID;
            target.TcPSW = oridata.TcPSW;
            target.Name = oridata.Name;
            target.TcDescription = oridata.TcDescription;
            target.CaptureCfg = CaptureCfgData.Convert(oridata.CaptureCfgData);
            target.CatchFaceCfg = CatchFaceCfgData.Convert(oridata.CatchFaceCfgData);
            target.Addr = oridata.Addr;
            target.Port = oridata.Port;
            target.Div_index = oridata.Div_index;
            target.Sst = oridata.Sst;
            return target;
        }
        public static ChannelCfgData ConvertToData(ChannelCfg oridata)
        {
            ChannelCfgData target = new ChannelCfgData();
            target.TcChaneelID = oridata.TcChaneelID;
            target.TcUID = oridata.TcUID;
            target.TcPSW = oridata.TcPSW;
            target.Name = oridata.Name;
            target.TcDescription = oridata.TcDescription;
            target.CaptureCfgData = CaptureCfgData.ConvertToData(oridata.CaptureCfg);
            target.CatchFaceCfgData = CatchFaceCfgData.ConvertToData(oridata.CatchFaceCfg);
            target.Addr = oridata.Addr;
            target.Port = oridata.Port;
            target.Div_index = oridata.Div_index;
            target.Sst = oridata.Sst;
            return target;
        }

        public static void CopyValue(object origin, object target)
        {
            System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
            System.Reflection.PropertyInfo[] fields = (origin.GetType()).GetProperties();
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {

                    if (fields[i].Name.ToUpper() == properties[j].Name.ToUpper() && properties[j].CanWrite)
                    {
                        properties[j].SetValue(target, fields[i].GetValue(origin, null), null);
                    }
                }
            }
        }

        #region  PropertyChanged

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
