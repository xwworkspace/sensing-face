using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class CaptureCfgData : INotifyPropertyChanged
    {
        private int _nLevel1ID;
        private int _nLevel2ID;
        private int _nCaptureType;
        private int _nPort;
        private string _tcAddr;
        private string _tcUID;
        private string _tcPSW;

        public virtual int NLevel1ID
        {
            get
            {
                return _nLevel1ID;
            }
            set
            {
                this._nLevel1ID = value;
                OnPropertyChanged("NLevel1ID");
            }
        }

        public virtual int NLevel2ID
        {
            get
            {
                return _nLevel2ID;
            }
            set
            {
                this._nLevel2ID = value;
                OnPropertyChanged("NLevel2ID");
            }
        }

        public virtual int NCaptureType
        {
            get
            {
                return _nCaptureType;
            }
            set
            {
                this._nCaptureType = value;
                OnPropertyChanged("NCaptureType");
            }
        }

        public virtual int NPort
        {
            get
            {
                return _nPort;
            }
            set
            {
                this._nPort = value;
                OnPropertyChanged("NPort");
            }
        }

        public virtual string TcAddr
        {
            get
            {
                return _tcAddr;
            }
            set
            {
                this._tcAddr = value;
                OnPropertyChanged("TcAddr");
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

        public static CaptureCfg Convert(CaptureCfgData oridata)
        {
            CaptureCfg target = new CaptureCfg();
            target.NLevel1ID = oridata.NLevel1ID;
            target.NLevel2ID = oridata.NLevel2ID;
            target.NCaptureType = oridata.NCaptureType;
            target.NPort = oridata.NPort;
            target.TcAddr = oridata.TcAddr;
            target.TcUID = oridata.TcUID;
            target.TcPSW = oridata.TcPSW;
            return target;
        }
        public static CaptureCfgData ConvertToData(CaptureCfg oridata)
        {
            CaptureCfgData target = new CaptureCfgData();
            target.NLevel1ID = oridata.NLevel1ID;
            target.NLevel2ID = oridata.NLevel2ID;
            target.NCaptureType = oridata.NCaptureType;
            target.NPort = oridata.NPort;
            target.TcAddr = oridata.TcAddr;
            target.TcUID = oridata.TcUID;
            target.TcPSW = oridata.TcPSW;
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
