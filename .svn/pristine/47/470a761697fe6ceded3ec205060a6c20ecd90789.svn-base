using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class RectData: INotifyPropertyChanged
    {
        private int _left;
        private int _top;
        private int _right;
        private int _bottom;

        public virtual int Left
        {
            get
            {
                return _left;
            }
            set
            {
                this._left = value;
                OnPropertyChanged("Left");
            }
        }

        public virtual int Top
        {
            get
            {
                return _top;
            }
            set
            {
                this._top = value;
                OnPropertyChanged("Top");
            }
        }

        public virtual int Right
        {
            get
            {
                return _right;
            }
            set
            {
                this._right = value;
                OnPropertyChanged("Right");
            }
        }

        public virtual int Bottom
        {
            get
            {
                return _bottom;
            }
            set
            {
                this._bottom = value;
                OnPropertyChanged("Bottom");
            }
        }
        public static _RECT Convert(RectData oridata)
        {
            _RECT target = new _RECT();
            target.Left = oridata.Left;
            target.Top = oridata.Top;
            target.Right = oridata.Right;
            target.Bottom = oridata.Bottom;
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
