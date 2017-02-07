using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class ResourceCfgData : INotifyPropertyChanged
    {
        private string _rtype;
        private string _resid;
        private string _pid;

        public virtual string Rtype
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

        public virtual string Resid
        {
            get
            {
                return _resid;
            }
            set
            {
                this._resid = value;
                OnPropertyChanged("Resid");
            }
        }

        public virtual string Pid
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
        public static ResourceCfg Convert(ResourceCfgData oridata)
        {
            ResourceCfg target = new ResourceCfg();
            target.Rtype = oridata.Rtype;
            target.Resid = oridata.Resid;
            target.Pid = oridata.Pid;
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
