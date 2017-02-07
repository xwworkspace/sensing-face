using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class FaceObjData : INotifyPropertyChanged
    {
        private string _tcUuid;
        private string _tcName;
        private int _nMain_ftID;
        private int _nType;
        private int _nSST;
        private int _nExten;
        private int _nSex;
        private int _nAge;
        private long _dTm;
        private string _tcRemarks;
        private List<FaceObjTemplateData> _tmplate;

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

        public virtual string TcName
        {
            get
            {
                return _tcName;
            }
            set
            {
                this._tcName = value;
                OnPropertyChanged("TcName");
            }
        }

        public virtual int NMain_ftID
        {
            get
            {
                return _nMain_ftID;
            }
            set
            {
                this._nMain_ftID = value;
                OnPropertyChanged("NMain_ftID");
            }
        }

        public virtual int NType
        {
            get
            {
                return _nType;
            }
            set
            {
                this._nType = value;
                OnPropertyChanged("NType");
            }
        }

        public virtual int NSST
        {
            get
            {
                return _nSST;
            }
            set
            {
                this._nSST = value;
                OnPropertyChanged("NSST");
            }
        }

        public virtual int NExten
        {
            get
            {
                return _nExten;
            }
            set
            {
                this._nExten = value;
                OnPropertyChanged("NExten");
            }
        }

        public virtual int NSex
        {
            get
            {
                return _nSex;
            }
            set
            {
                this._nSex = value;
                OnPropertyChanged("NSex");
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

        public virtual List<FaceObjTemplateData> Tmplate
        {
            get
            {
                return _tmplate;
            }
            set
            {
                this._tmplate = value;
                OnPropertyChanged("Tmplate");
            }
        }
        public static FaceObj Convert(FaceObjData oridata)
        {
            FaceObj target = new FaceObj();
            target.TcUuid = oridata.TcUuid;
            target.TcName = oridata.TcName;
            target.NMain_ftID = oridata.NMain_ftID;
            target.NType = oridata.NType;
            target.NSST = oridata.NSST;
            target.NExten = oridata.NExten;
            target.NSex = oridata.NSex;
            target.NAge = oridata.NAge;
            target.DTm = oridata.DTm;
            target.TcRemarks = oridata.TcRemarks;
            target.Tmplate = oridata.Tmplate.ConvertAll<FaceObjTemplate>(p => FaceObjTemplateData.Convert(p)); 
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
