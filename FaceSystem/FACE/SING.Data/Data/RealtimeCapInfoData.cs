using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class RealtimeCapInfoData : INotifyPropertyChanged
    {
        private string _id;
        private long _time;
        private string _channel;
        private byte[] _image;
        private long _beginTm;
        private long _endTm;

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

        public virtual byte[] Image
        {
            get
            {
                return _image;
            }
            set
            {
                this._image = value;
                OnPropertyChanged("Image");
            }
        }

        public virtual long BeginTm
        {
            get
            {
                return _beginTm;
            }
            set
            {
                this._beginTm = value;
                OnPropertyChanged("BeginTm");
            }
        }

        public virtual long EndTm
        {
            get
            {
                return _endTm;
            }
            set
            {
                this._endTm = value;
                OnPropertyChanged("EndTm");
            }
        }

        public static RealtimeCapInfo Convert(RealtimeCapInfoData oridata)
        {
            RealtimeCapInfo target = new RealtimeCapInfo();
            target.Id = oridata.Id;
            target.Time = oridata.Time;
            target.Channel = oridata.Channel;
            target.Image = oridata.Image;
            target.BeginTm = oridata.BeginTm;
            target.EndTm = oridata.EndTm;
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
