using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class FaceInfoData : INotifyPropertyChanged
    {
        private RectData _rcFace;
        private PointData _ptLeftEye;
        private PointData _ptRightEye;
        private PointData _ptMouth;
        private PointData _ptNose;
        private int _nYaw;
        private int _nPitch;
        private int _nRoll;
        private int _nQuality;
        private int _nGender;
        private int _nAge;
        private long _dTm;
        private string _tcSdkVer;
        private byte[] _Fea;
        private byte[] _Img;
        private string _channelID;

        public virtual RectData RcFace
        {
            get
            {
                return _rcFace;
            }
            set
            {
                this._rcFace = value;
                OnPropertyChanged("RcFace");
            }
        }

        public virtual PointData PtLeftEye
        {
            get
            {
                return _ptLeftEye;
            }
            set
            {
                this._ptLeftEye = value;
                OnPropertyChanged("PtLeftEye");
            }
        }

        public virtual PointData PtRightEye
        {
            get
            {
                return _ptRightEye;
            }
            set
            {
                this._ptRightEye = value;
                OnPropertyChanged("PtRightEye");
            }
        }

        public virtual PointData PtMouth
        {
            get
            {
                return _ptMouth;
            }
            set
            {
                this._ptMouth = value;
                OnPropertyChanged("PtMouth");
            }
        }

        public virtual PointData PtNose
        {
            get
            {
                return _ptNose;
            }
            set
            {
                this._ptNose = value;
                OnPropertyChanged("PtNose");
            }
        }

        public virtual int NYaw
        {
            get
            {
                return _nYaw;
            }
            set
            {
                this._nYaw = value;
                OnPropertyChanged("NYaw");
            }
        }

        public virtual int NPitch
        {
            get
            {
                return _nPitch;
            }
            set
            {
                this._nPitch = value;
                OnPropertyChanged("NPitch");
            }
        }

        public virtual int NRoll
        {
            get
            {
                return _nRoll;
            }
            set
            {
                this._nRoll = value;
                OnPropertyChanged("NRoll");
            }
        }

        public virtual int NQuality
        {
            get
            {
                return _nQuality;
            }
            set
            {
                this._nQuality = value;
                OnPropertyChanged("NQuality");
            }
        }

        public virtual int NGender
        {
            get
            {
                return _nGender;
            }
            set
            {
                this._nGender = value;
                OnPropertyChanged("NGender");
            }
        }

        public virtual int NAge
        {
            get
            {
                return _nAge;
            }
            set
            {
                this._nAge = value;
                OnPropertyChanged("NAge");
            }
        }

        public virtual long DTm
        {
            get
            {
                return _dTm;
            }
            set
            {
                this._dTm = value;
                OnPropertyChanged("DTm");
            }
        }

        public virtual string TcSdkVer
        {
            get
            {
                return _tcSdkVer;
            }
            set
            {
                this._tcSdkVer = value;
                OnPropertyChanged("TcSdkVer");
            }
        }

        public virtual byte[] Fea
        {
            get
            {
                return _Fea;
            }
            set
            {
                this._Fea = value;
                OnPropertyChanged("Fea");
            }
        }

        public virtual byte[] Img
        {
            get
            {
                return _Img;
            }
            set
            {
                this._Img = value;
                OnPropertyChanged("Img");
            }
        }

        public virtual string ChannelID
        {
            get
            {
                return _channelID;
            }
            set
            {
                this._channelID = value;
                OnPropertyChanged("ChannelID");
            }
        }
        public static FaceInfo Convert(FaceInfoData oridata)
        {
            FaceInfo target = new FaceInfo();
            target.RcFace = RectData.Convert(oridata.RcFace);
            target.PtLeftEye = PointData.Convert(oridata.PtLeftEye);
            target.PtRightEye = PointData.Convert(oridata.PtRightEye);
            target.PtMouth = PointData.Convert(oridata.PtMouth);
            target.PtNose = PointData.Convert(oridata.PtNose);
            target.NYaw = oridata.NYaw;
            target.NPitch = oridata.NPitch;
            target.NRoll = oridata.NRoll;
            target.NQuality = oridata.NQuality;
            target.NGender = oridata.NGender;
            target.NAge = oridata.NAge;
            target.DTm = oridata.DTm;
            target.TcSdkVer = oridata.TcSdkVer;
            target.Fea = oridata.Fea;
            target.Img = oridata.Img;
            target.ChannelID = oridata.ChannelID;
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
