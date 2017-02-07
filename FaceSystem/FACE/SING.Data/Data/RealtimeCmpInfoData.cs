using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class RealtimeCmpInfoData : INotifyPropertyChanged
    {
        private string _CapID;
        private string _ObjID;
        private byte[] _CapImg;
        private byte[] _ObjImg;
        private string _name;
        private string _channel;
        private long _time;
        private int _type;
        private int _score;

        public virtual string CapID
        {
            get
            {
                return _CapID;
            }
            set
            {
                this._CapID = value;
                OnPropertyChanged("CapID");
            }
        }

        public virtual string ObjID
        {
            get
            {
                return _ObjID;
            }
            set
            {
                this._ObjID = value;
                OnPropertyChanged("ObjID");
            }
        }

        public virtual byte[] CapImg
        {
            get
            {
                return _CapImg;
            }
            set
            {
                this._CapImg = value;
                OnPropertyChanged("CapImg");
            }
        }

        public virtual byte[] ObjImg
        {
            get
            {
                return _ObjImg;
            }
            set
            {
                this._ObjImg = value;
                OnPropertyChanged("ObjImg");
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

        public virtual string Channel
        {
            get
            {
                return _channel;
            }
            set
            {
                this._channel = value;
                OnPropertyChanged("Channel");
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

        public virtual int Type
        {
            get
            {
                return _type;
            }
            set
            {
                this._type = value;
                OnPropertyChanged("Type");
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

        public static RealtimeCmpInfo Convert(RealtimeCmpInfoData oridata)
        {
            RealtimeCmpInfo target = new RealtimeCmpInfo();
            target.CapID = oridata.CapID;
            target.ObjID = oridata.ObjID;
            target.CapImg = oridata.CapImg;
            target.ObjImg = oridata.ObjImg;
            target.Name = oridata.Name;
            target.Channel = oridata.Channel;
            target.Time = oridata.Time;
            target.Type = oridata.Type;
            target.Score = oridata.Score;
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
