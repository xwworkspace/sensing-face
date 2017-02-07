using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class FaceTemplateExData : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private int _type;
        private int _sst;
        private int _ext;
        private byte[] _fea;
        private string _faceObjID;

        public virtual string Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged("Id");
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

        public virtual int Type
        {
            get
            {
                return _type;
            }
            set
            {
                this._type = value;
                OnPropertyChanged("Type");
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

        public virtual int Ext
        {
            get
            {
                return _ext;
            }
            set
            {
                this._ext = value;
                OnPropertyChanged("Ext");
            }
        }

        public virtual byte[] Fea
        {
            get
            {
                return _fea;
            }
            set
            {
                this._fea = value;
                OnPropertyChanged("Fea");
            }
        }

        public virtual string FaceObjID
        {
            get
            {
                return _faceObjID;
            }
            set
            {
                this._faceObjID = value;
                OnPropertyChanged("FaceObjID");
            }
        }

        public static FaceTemplateEx Convert(FaceTemplateExData oridata)
        {
            FaceTemplateEx target = new FaceTemplateEx();
            target.Id = oridata.Id;
            target.Name = oridata.Name;
            target.Type = oridata.Type;
            target.Sst = oridata.Sst;
            target.Ext = oridata.Ext;
            target.Fea = oridata.Fea;
            target.FaceObjID = oridata.FaceObjID;
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
