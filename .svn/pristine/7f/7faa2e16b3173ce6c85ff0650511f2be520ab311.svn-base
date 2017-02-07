using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class PointData: INotifyPropertyChanged
    {
        private int _x;
        private int _y;

        public virtual int X
        {
            get
            {
                return _x;
            }
            set
            {
                this._x = value;
                OnPropertyChanged("X");
            }
        }

        public virtual int Y
        {
            get
            {
                return _y;
            }
            set
            {
                this._y = value;
                OnPropertyChanged("Y");
            }
        }

        public static _POINT Convert(PointData oridata)
        {
            _POINT target = new _POINT();
            target.X = oridata.X;
            target.Y = oridata.Y;
           
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
