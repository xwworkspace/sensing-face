using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class ErrorInfoData : INotifyPropertyChanged
    {
        private string _ID;
        private int _ErrCode;

        public virtual string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                this._ID = value;
                OnPropertyChanged("ID");
            }
        }

        public virtual int ErrCode
        {
            get
            {
                return _ErrCode;
            }
            set
            {
                this._ErrCode = value;
                OnPropertyChanged("ErrCode");
            }
        }
        public static ErrorInfo Convert(ErrorInfoData oridata)
        {
            ErrorInfo target = new ErrorInfo();
            target.ID = oridata.ID;
            target.ErrCode = oridata.ErrCode;
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
