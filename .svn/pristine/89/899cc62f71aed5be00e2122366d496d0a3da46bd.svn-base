using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class ClientCfgData : INotifyPropertyChanged
    {
        private string _client_IP;
        private string _client_Port;
        private int _client_op;
        private string _cam_IP;
        private int _cam_Port;
        private string _channel_addr;
        private int _channel_port;

        public virtual string Client_IP
        {
            get
            {
                return _client_IP;
            }
            set
            {
                this._client_IP = value;
                OnPropertyChanged("Client_IP");
            }
        }

        public virtual string Client_Port
        {
            get
            {
                return _client_Port;
            }
            set
            {
                this._client_Port = value;
                OnPropertyChanged("Client_Port");
            }
        }

        public virtual int Client_op
        {
            get
            {
                return _client_op;
            }
            set
            {
                this._client_op = value;
                OnPropertyChanged("Client_op");
            }
        }

        public virtual string Cam_IP
        {
            get
            {
                return _cam_IP;
            }
            set
            {
                this._cam_IP = value;
                OnPropertyChanged("Cam_IP");
            }
        }

        public virtual int Cam_Port
        {
            get
            {
                return _cam_Port;
            }
            set
            {
                this._cam_Port = value;
                OnPropertyChanged("Cam_Port");
            }
        }

        public virtual string Channel_addr
        {
            get
            {
                return _channel_addr;
            }
            set
            {
                this._channel_addr = value;
                OnPropertyChanged("Channel_addr");
            }
        }

        public virtual int Channel_port
        {
            get
            {
                return _channel_port;
            }
            set
            {
                this._channel_port = value;
                OnPropertyChanged("Channel_port");
            }
        }

        public static ClientCfg Convert(ClientCfgData oridata)
        {
            ClientCfg target = new ClientCfg();
            target.Client_IP = oridata.Client_IP;
            target.Client_Port = oridata.Client_Port;
            target.Client_op = oridata.Client_op;
            target.Cam_IP = oridata.Cam_IP;
            target.Cam_Port = oridata.Cam_Port;
            target.Channel_addr = oridata.Channel_addr;
            target.Channel_port = oridata.Channel_port;
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
