using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class TmpGroupCfgData : INotifyPropertyChanged
    {
        private string _tmpgid;
        private string _uid;
        private string _tmpgname;
        private string _rtype;
        private List<ResourceCfgData> _rescfg;
        private string _pid;

        public virtual string Tmpgid
        {
            get
            {
                return _tmpgid;
            }
            set
            {
                this._tmpgid = value;
                OnPropertyChanged("Tmpgid");
            }
        }

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

        public virtual string Tmpgname
        {
            get
            {
                return _tmpgname;
            }
            set
            {
                this._tmpgname = value;
                OnPropertyChanged("Tmpgname");
            }
        }

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

        public virtual List<ResourceCfgData> Rescfg
        {
            get
            {
                return _rescfg;
            }
            set
            {
                this._rescfg = value;
                OnPropertyChanged("Rescfg");
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

        public static TmpGroupCfg Convert(TmpGroupCfgData oridata)
        {
            TmpGroupCfg target = new TmpGroupCfg();
            target.Tmpgid = oridata.Tmpgid;
            target.Uid = oridata.Uid;
            target.Tmpgname = oridata.Tmpgname;
            target.Rtype = oridata.Rtype;
            target.Rescfg = oridata.Rescfg.ConvertAll<ResourceCfg>(p => ResourceCfgData.Convert(p));
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
