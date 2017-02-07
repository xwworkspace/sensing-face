using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class ChannelStateData : INotifyPropertyChanged
    {
        private string _ChannelID;
        private int _state;

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

        public virtual int State
        {
            get
            {
                return _state;
            }
            set
            { 
                this._state = value;
                OnPropertyChanged("State");
            }
        }
        public static ChannelState Convert(ChannelStateData oridata)
        {
            ChannelState target = new ChannelState();
            target.ChannelID = oridata.ChannelID;
            target.State = oridata.State;
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
