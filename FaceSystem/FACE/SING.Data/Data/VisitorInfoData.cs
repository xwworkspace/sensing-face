using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class VisitorInfoData : INotifyPropertyChanged
    {
        private string _idnumber;
        private string _name;
        private int _nGender;
        private int _nAge;
        private long _dTm;
        private string _channelID;
        private byte[] _IdImg;
        private byte[] _Img;

        public virtual string Idnumber
        {
            get
            {
                return _idnumber;
            }
            set
            {
                this._idnumber = value;
                OnPropertyChanged("Idnumber");
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

        public virtual int NGender
        {
            get
            {
                return _nGender;
            }
            set
            {
                this._nGender = value;
                OnPropertyChanged("NGender");
            }
        }

        public virtual int NAge
        {
            get
            {
                return _nAge;
            }
            set
            {
                this._nAge = value;
                OnPropertyChanged("NAge");
            }
        }

        public virtual long DTm
        {
            get
            {
                return _dTm;
            }
            set
            {
                this._dTm = value;
                OnPropertyChanged("DTm");
            }
        }

        public virtual string ChannelID
        {
            get
            {
                return _channelID;
            }
            set
            {
                this._channelID = value;
                OnPropertyChanged("ChannelID");
            }
        }

        public virtual byte[] IdImg
        {
            get
            {
                return _IdImg;
            }
            set
            {
                this._IdImg = value;
                OnPropertyChanged("IdImg");
            }
        }

        public virtual byte[] Img
        {
            get
            {
                return _Img;
            }
            set
            {
                this._Img = value;
                OnPropertyChanged("Img");
            }
        }

        public static VisitorInfo Convert(VisitorInfoData oridata)
        {
            VisitorInfo target = new VisitorInfo();
            target.Idnumber = oridata.Idnumber;
            target.Name = oridata.Name;
            target.NGender = oridata.NGender;
            target.NAge = oridata.NAge;
            target.DTm = oridata.DTm;
            target.ChannelID = oridata.ChannelID;
            target.IdImg = oridata.IdImg;
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
