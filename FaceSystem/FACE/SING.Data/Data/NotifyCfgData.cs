﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class NotifyCfgData : INotifyPropertyChanged
    {
        private int _itemcode;
        private string _itemstr;

        public virtual int Itemcode
        {
            get
            {
                return _itemcode;
            }
            set
            {
                this._itemcode = value;
                OnPropertyChanged("Itemcode");
            }
        }

        public virtual string Itemstr
        {
            get
            {
                return _itemstr;
            }
            set
            {
                this._itemstr = value;
                OnPropertyChanged("Itemstr");
            }
        }
        public static NotifyCfg Convert(NotifyCfgData oridata)
        {
            NotifyCfg target = new NotifyCfg();
            target.Itemcode = oridata.Itemcode;
            target.Itemstr = oridata.Itemstr;
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