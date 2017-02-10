using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class CapFaceLogWithImgData : INotifyPropertyChanged
    {
        private string _ID;
        private string _ChannelID;
        private long _time;
        private long _timeIn;
        private long _timeOut;
        private int _quality;
        private int _age;
        private int _gender;
        private byte[] _img;
        private string _channelname;

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

        public virtual string ChannelID
        {
            get
            {
                return _ChannelID;
            }
            set
            {
                this._ChannelID = value;
                OnPropertyChanged("ChannelID");
            }
        }

        public virtual long Time
        {
            get
            {
                return _time;
            }
            set
            {
                this._time = value;
                OnPropertyChanged("Time");
            }
        }

        public virtual long TimeIn
        {
            get
            {
                return _timeIn;
            }
            set
            {
                this._timeIn = value;
                OnPropertyChanged("TimeIn");
            }
        }

        public virtual long TimeOut
        {
            get
            {
                return _timeOut;
            }
            set
            {
                this._timeOut = value;
                OnPropertyChanged("TimeOut");
            }
        }

        public virtual int Quality
        {
            get
            {
                return _quality;
            }
            set
            {
                this._quality = value;
                OnPropertyChanged("Quality");
            }
        }

        public virtual int Age
        {
            get
            {
                return _age;
            }
            set
            {
                this._age = value;
                OnPropertyChanged("Age");
            }
        }

        public virtual int Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                this._gender = value;
                OnPropertyChanged("Gender");
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

        public virtual string ChannelName
        {
            get
            {
                return _channelname;
            }
            set
            {
                this._channelname = value;
                OnPropertyChanged("ChannelName");
            }
        }

        public static CapFaceLogWithImg Convert(CapFaceLogWithImgData oridata)
        {
            CapFaceLogWithImg target = new CapFaceLogWithImg();
            target.ID = oridata.ID;
            target.ChannelID = oridata.ChannelID;
            target.Time = oridata.Time;
            target.TimeIn = oridata.TimeIn;
            target.TimeOut = oridata.TimeOut;
            target.Quality = oridata.Quality;
            target.Age = oridata.Age;
            target.Gender = oridata.Gender;
            target.Img = oridata.Img;
            target.Channelname = oridata.ChannelName;
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
