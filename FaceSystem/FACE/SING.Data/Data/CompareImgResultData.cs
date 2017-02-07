using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class CompareImgResultData : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private int _score;
        private byte[] _img;

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

        public virtual int Score
        {
            get
            {
                return _score;
            }
            set
            {
                this._score = value;
                OnPropertyChanged("Score");
            }
        }

        public virtual byte[] Img
        {
            get
            {
                return _img;
            }
            set
            {
                this._img = value;
                OnPropertyChanged("Img");
            }
        }
        public static CompareImgResult Convert(CompareImgResultData oridata)
        {
            CompareImgResult target = new CompareImgResult();
            target.Id = oridata.Id;
            target.Name = oridata.Name;
            target.Score = oridata.Score;
            target.Img = oridata.Img;
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
