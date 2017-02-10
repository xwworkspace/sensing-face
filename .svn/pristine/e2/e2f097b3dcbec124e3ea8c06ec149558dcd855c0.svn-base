using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class CmpFaceLogWidthImgData : INotifyPropertyChanged
    {
        private string _ID;
        private string _name;
        private string _channel;
        private long _time;
        private int _type;
        private int _score;
        private byte[] _img;
        private string _tcUuid;
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

        public virtual string TcUuid
        {
            get
            {
                return _tcUuid;
            }
            set
            {
                this._tcUuid = value;
                OnPropertyChanged("TcUuid");
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

        public static CmpFaceLogWidthImg Convert(CmpFaceLogWidthImgData oridata)
        {
            CmpFaceLogWidthImg target = new CmpFaceLogWidthImg();
            target.ID = oridata.ID;
            target.Name = oridata.Name;
            target.Channel = oridata.Channel;
            target.Time = oridata.Time;
            target.Type = oridata.Type;
            target.Score = oridata.Score;
            target.Img = oridata.Img;
            target.TcUuid = oridata.TcUuid;
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
