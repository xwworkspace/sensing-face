using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public class STypeInfoData : INotifyPropertyChanged
    {
        private int _type;
        private string _description;

        public int Type
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

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                this._description = value;
                OnPropertyChanged("Description");
            }
        }

        public static STypeInfo Convert(STypeInfoData oridata)
        {
            STypeInfo target = new STypeInfo();
            target.Type = oridata.Type;
            target.Description = oridata.Description;
            return target;
        }
        public static STypeInfoData ConvertToData(STypeInfo oridata)
        {
            STypeInfoData target = new STypeInfoData();
            target.Type = oridata.Type;
            target.Description = oridata.Description;
            return target;
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
