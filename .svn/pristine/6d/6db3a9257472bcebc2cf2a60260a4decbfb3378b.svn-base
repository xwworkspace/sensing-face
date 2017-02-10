using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public class RealtimeCmpInfoViewData: RealtimeCmpInfoData
    {
        private string _channelname;
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

        private string _reginfo;

        public string RegInfo
        {
            get { return _reginfo; }
            set
            {
                _reginfo = value;
                OnPropertyChanged("RegInfo");
            }
        }

    }
}
