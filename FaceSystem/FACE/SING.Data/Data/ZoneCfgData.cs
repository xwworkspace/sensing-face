using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class ZoneCfgData : INotifyPropertyChanged
    {
        private string _div_index;
        private string _div_name;
        private string _div_parent;
        private string _div_parents;
        private string _div_order;
        private string _div_orderidx;
        private string _div_memo;

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

        public virtual string Div_name
        {
            get
            {
                return _div_name;
            }
            set
            {
                this._div_name = value;
                OnPropertyChanged("Div_name");
            }
        }

        public virtual string Div_parent
        {
            get
            {
                return _div_parent;
            }
            set
            {
                this._div_parent = value;
                OnPropertyChanged("Div_parent");
            }
        }

        public virtual string Div_parents
        {
            get
            {
                return _div_parents;
            }
            set
            {
                this._div_parents = value;
                OnPropertyChanged("Div_parents");
            }
        }

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

        public virtual string Div_orderidx
        {
            get
            {
                return _div_orderidx;
            }
            set
            {
                this._div_orderidx = value;
                OnPropertyChanged("Div_orderidx");
            }
        }

        public virtual string Div_memo
        {
            get
            {
                return _div_memo;
            }
            set
            {
                this._div_memo = value;
                OnPropertyChanged("Div_memo");
            }
        }

        public static ZoneCfg Convert(ZoneCfgData oridata)
        {
            ZoneCfg target = new ZoneCfg();
            target.Div_index = oridata.Div_index;
            target.Div_name = oridata.Div_name;
            target.Div_parent = oridata.Div_parent;
            target.Div_parents = oridata.Div_parents;
            target.Div_order = oridata.Div_order;
            target.Div_orderidx = oridata.Div_orderidx;
            target.Div_memo = oridata.Div_memo;
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
