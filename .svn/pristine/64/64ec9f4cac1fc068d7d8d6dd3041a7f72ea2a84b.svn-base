using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class CResultCfgData : INotifyPropertyChanged
    {
        private int _retCode;
        private string _retInfo;
        private double _score;

        public virtual int RetCode
        {
            get
            {
                return _retCode;
            }
            set
            {
                this._retCode = value;
                OnPropertyChanged("RetCode");
            }
        }

        public virtual string RetInfo
        {
            get
            {
                return _retInfo;
            }
            set
            {
                this._retInfo = value;
                OnPropertyChanged("RetInfo");
            }
        }

        public virtual double Score
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
        public static CResultCfg Convert(CResultCfgData oridata)
        {
            CResultCfg target = new CResultCfg();
            target.RetCode = oridata.RetCode;
            target.RetInfo = oridata.RetInfo;
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
