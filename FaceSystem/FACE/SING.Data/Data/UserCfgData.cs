using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class UserCfgData: INotifyPropertyChanged
    {
        private string _uid;
        public virtual string Uid
        {
            get
            {
                return _uid;
            }
            set
            {
                this._uid = value;
                OnPropertyChanged("Uid");
            }
        }

        private string _uname;
        public virtual string Uname
        {
            get
            {
                return _uname;
            }
            set
            {
                this._uname = value;
                OnPropertyChanged("Uname");
            }
        }

        private string _upwd;
        public virtual string Upwd
        {
            get
            {
                return _upwd;
            }
            set
            {
                this._upwd = value;
                OnPropertyChanged("Upwd");
            }
        }

        private string _utype;
        public virtual string Utype
        {
            get
            {
                return _utype;
            }
            set
            {
                this._utype = value;
                OnPropertyChanged("Utype");
            }
        }

        private string _div_index;
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

        private string _div_order;
        public virtual string Div_order
        {
            get
            {
                return _div_order;
            }
            set
            {
                this._div_order = value;
                OnPropertyChanged("Div_order");
            }
        }

        public static UserCfg Convert(UserCfgData oridata)
        {
            UserCfg target = new UserCfg();
            target.Uid = oridata.Uid;
            target.Uname = oridata.Uname;
            target.Upwd = oridata.Upwd;
            target.Utype = oridata.Utype;
            target.Div_index = oridata.Div_index;
            target.Div_order = oridata.Div_order;
            return target;
        }

        public static UserCfgData ConvertToData(UserCfg oridata)
        {
            UserCfgData target = new UserCfgData();
            target.Uid = oridata.Uid;
            target.Uname = oridata.Uname;
            target.Upwd = oridata.Upwd;
            target.Utype = oridata.Utype;
            target.Div_index = oridata.Div_index;
            target.Div_order = oridata.Div_order;
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
