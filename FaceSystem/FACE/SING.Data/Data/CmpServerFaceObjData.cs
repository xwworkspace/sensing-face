using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Data
{
    [Serializable]
    public partial class CmpServerFaceObjData : INotifyPropertyChanged
    {
        private string _faceObjID;
        private List<FaceTemplateData> _ft;

        public virtual string FaceObjID
        {
            get
            {
                return _faceObjID;
            }
            set
            {
                this._faceObjID = value;
                OnPropertyChanged("FaceObjID");
            }
        }

        public virtual List<FaceTemplateData> Ft
        {
            get
            {
                return _ft;
            }
            set
            {
                this._ft = value;
                OnPropertyChanged("Ft");
            }
        }

        public static CmpServerFaceObj Convert(CmpServerFaceObjData oridata)
        {
            CmpServerFaceObj target = new CmpServerFaceObj();
            target.FaceObjID = oridata.FaceObjID;
            //target.Ft = oridata.Ft.Cast<FaceTemplate>().ToList();
            //target.Ft = oridata.Ft.OfType<FaceTemplate>().ToList();
            target.Ft = oridata.Ft.ConvertAll<FaceTemplate>(p => FaceTemplateData.Convert(p));
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
