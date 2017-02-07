using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class FaceObjTemplateData : INotifyPropertyChanged
    {
        private string _tcUuid;
        private string _tcObjid;
        private string _tcKey;
        private int _nIndex;
        private long _dTm;
        private string _tcRemarks;
        private byte[] _img;

        public virtual string TcUuid
        {
            get
            {
                return _tcUuid;
            }
            set
            {
                this._tcUuid = value;
                OnPropertyChanged("TcUuid");
            }
        }

        public virtual string TcObjid
        {
            get
            {
                return _tcObjid;
            }
            set
            {
                this._tcObjid = value;
                OnPropertyChanged("TcObjid");
            }
        }

        public virtual string TcKey
        {
            get
            {
                return _tcKey;
            }
            set
            {
                this._tcKey = value;
                OnPropertyChanged("TcKey");
            }
        }

        public virtual int NIndex
        {
            get
            {
                return _nIndex;
            }
            set
            {
                this._nIndex = value;
                OnPropertyChanged("NIndex");
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

        public virtual string TcRemarks
        {
            get
            {
                return _tcRemarks;
            }
            set
            {
                this._tcRemarks = value;
                OnPropertyChanged("TcRemarks");
            }
        }

        public virtual byte[] Img
        {
            get
            {
                return _img;
            }
            set
            {
                this._img = value;
                OnPropertyChanged("Img");
            }
        }

        public static FaceObjTemplate Convert(FaceObjTemplateData oridata)
        {
            FaceObjTemplate target = new FaceObjTemplate();
            target.TcUuid = oridata.TcUuid;
            target.TcObjid = oridata.TcObjid;
            target.TcKey = oridata.TcKey;
            target.NIndex = oridata.NIndex;
            target.DTm = oridata.DTm;
            target.TcRemarks = oridata.TcRemarks;
            target.Img = oridata.Img;

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
