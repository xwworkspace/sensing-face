using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class CatchFaceCfgData : INotifyPropertyChanged
    {
        private int _nMinFace;
        private int _nMinQuality;
        private int _nMinCapDistance;
        private int _nMaxFaceSaveDistance;
        private int _nYaw;
        private int _nPitch;
        private int _nYoll;
        private int _nReserved;
        private string _tcSdkVer;

        public virtual int NMinFace
        {
            get { return _nMinFace; }
            set
            {
                this._nMinFace = value;
                OnPropertyChanged("NMinFace");
            }
        }

        public virtual int NMinQuality
        {
            get { return _nMinQuality; }
            set
            {
                this._nMinQuality = value;
                OnPropertyChanged("NMinQuality");
            }
        }

        public virtual int NMinCapDistance
        {
            get { return _nMinCapDistance; }
            set
            {
                this._nMinCapDistance = value;
                OnPropertyChanged("NMinCapDistance");
            }
        }

        public virtual int NMaxFaceSaveDistance
        {
            get { return _nMaxFaceSaveDistance; }
            set
            {
                this._nMaxFaceSaveDistance = value;
                OnPropertyChanged("NMaxFaceSaveDistance");
            }
        }

        public virtual int NYaw
        {
            get { return _nYaw; }
            set
            {
                this._nYaw = value;
                OnPropertyChanged("NYaw");
            }
        }

        public virtual int NPitch
        {
            get { return _nPitch; }
            set
            {
                this._nPitch = value;
                OnPropertyChanged("NPitch");
            }
        }

        public virtual int NYoll
        {
            get { return _nYoll; }
            set
            {
                this._nYoll = value;
                OnPropertyChanged("NYoll");
            }
        }

        public virtual int NReserved
        {
            get { return _nReserved; }
            set
            {
                this._nReserved = value;
                OnPropertyChanged("NReserved");
            }
        }

        public virtual string TcSdkVer
        {
            get { return _tcSdkVer; }
            set
            {
                this._tcSdkVer = value;
                OnPropertyChanged("TcSdkVer");
            }
        }

        public static CatchFaceCfg Convert(CatchFaceCfgData oridata)
        {
            CatchFaceCfg target = new CatchFaceCfg();
            target.NMinFace = oridata.NMinFace;
            target.NMinQuality = oridata.NMinQuality;
            target.NMinCapDistance = oridata.NMinCapDistance;
            target.NMaxFaceSaveDistance = oridata.NMaxFaceSaveDistance;
            target.NYaw = oridata.NYaw;
            target.NPitch = oridata.NPitch;
            target.NYoll = oridata.NYoll;
            target.NReserved = oridata.NReserved;
            target.TcSdkVer = oridata.TcSdkVer;
            return target;
        }
        public static CatchFaceCfgData ConvertToData(CatchFaceCfg oridata)
        {
            CatchFaceCfgData target = new CatchFaceCfgData();
            target.NMinFace = oridata.NMinFace;
            target.NMinQuality = oridata.NMinQuality;
            target.NMinCapDistance = oridata.NMinCapDistance;
            target.NMaxFaceSaveDistance = oridata.NMaxFaceSaveDistance;
            target.NYaw = oridata.NYaw;
            target.NPitch = oridata.NPitch;
            target.NYoll = oridata.NYoll;
            target.NReserved = oridata.NReserved;
            target.TcSdkVer = oridata.TcSdkVer;
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
