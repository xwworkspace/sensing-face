using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Events
{
    public class CallForCloseOrActiveDocumentParameters
    {
        public String CompmentGuid { get; set; }

        public string ProductPrimaryName { get; set; }

        public string ProductSecondaryName { get; set; }

        public string SeasonsData { get; set; }

        public string SchedulePhase { get; set; }


        private string _editorType = string.Empty;
        public string EditorType
        {
            get { return _editorType; }
            set { _editorType = value; }
        }

        public string AfterCloseActive { get; set; }

    }
    public class CallForOpenDocumentParameters
    {
        public string TargetSofaContainer { get; set; }
        public string ProductPrimaryName { get; set; }
        public string ProductSecondaryName { get; set; }

        public virtual string SeasonsData { get; set; }

        private string _invokeComponent = string.Empty;
        public string InvokeComponent
        {
            get { return _invokeComponent; }
            set { _invokeComponent = value; }
        }

        private bool _isNewComponent = false;
        public bool IsNewComponent
        {
            get { return _isNewComponent; }
            set
            {
                _isNewComponent = value;
            }
        }

        private string _queryString;
        public string QueryString
        {
            get { return _queryString; }
            set
            {
                _queryString = value;
            }
        }
    }
}
