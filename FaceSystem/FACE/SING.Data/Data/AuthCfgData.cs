using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class AuthCfgData: INotifyPropertyChanged
    {
        private int _rtype;
        private int _pid;
        private int _flag;

        public virtual int Rtype
        {
            get
            {
                return _rtype;
            }
            set
            {
                this._rtype = value;
                OnPropertyChanged("Rtype");
            }
        }

        public virtual int Pid
        {
            get
            {
                return _pid;
            }
            set
            {
                this._pid = value;
                OnPropertyChanged("Pid");
            }
        }

        public virtual int Flag
        {
            get
            {
                return _flag;
            }
            set
            {
                this._flag = value;
                OnPropertyChanged("Flag");
            }
        }

        public static AuthCfg Convert(AuthCfgData oridata)
        {
            AuthCfg target = new AuthCfg();
            target.Rtype = oridata.Rtype;
            target.Pid = oridata.Pid;
            target.Flag = oridata.Flag;
         
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
