using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class CmpFaceLogInfoData : INotifyPropertyChanged
    {
        private string _uuid;
        private string _ChannelID;
        private string _channelname;
        private long _time;
        private int _quality;
        private int _score;
        private string _ID;
        private string _name;
        private int _age;
        private int _gender;
        private byte[] _idimg;
        private byte[] _capimg;
        private byte[] _idfea;
        private byte[] _capfea;

        public virtual string Uuid
        {
            get
            {
                return _uuid;
            }
            set
            {
                this._uuid = value;
                OnPropertyChanged("Uuid");
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

        public virtual string Channelname
        {
            get
            {
                return _channelname;
            }
            set
            {
                this._channelname = value;
                OnPropertyChanged("Channelname");
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

        public virtual byte[] Idimg
        {
            get
            {
                return _idimg;
            }
            set
            {
                this._idimg = value;
                OnPropertyChanged("Idimg");
            }
        }

        public virtual byte[] Capimg
        {
            get
            {
                return _capimg;
            }
            set
            {
                this._capimg = value;
                OnPropertyChanged("Capimg");
            }
        }

        public virtual byte[] Idfea
        {
            get
            {
                return _idfea;
            }
            set
            {
                this._idfea = value;
                OnPropertyChanged("Idfea");
            }
        }

        public virtual byte[] Capfea
        {
            get
            {
                return _capfea;
            }
            set
            {
                this._capfea = value;
                OnPropertyChanged("Capfea");
            }
        }
        public static CmpFaceLogInfo Convert(CmpFaceLogInfoData oridata)
        {
            CmpFaceLogInfo target = new CmpFaceLogInfo();
            target.Uuid = oridata.Uuid;
            target.ChannelID = oridata.ChannelID;
            target.Channelname = oridata.Channelname;
            target.Time = oridata.Time;
            target.Quality = oridata.Quality;
            target.Score = oridata.Score;
            target.ID = oridata.ID;
            target.Name = oridata.Name;
            target.Age = oridata.Age;
            target.Gender = oridata.Gender;
            target.Idimg = oridata.Idimg;
            target.Capimg = oridata.Capimg;
            target.Idfea = oridata.Idfea;
            target.Capfea = oridata.Capfea;
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
