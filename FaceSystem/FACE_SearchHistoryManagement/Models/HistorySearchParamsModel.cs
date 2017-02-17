using SING.Data.Data;
using System.Collections.Generic;
using System.Windows;

namespace FACE_SearchHistoryManagement.Models
{
    public class HistorySearchParamsModel
    {
        string _cameraName;
        string _startTime;
        string _endTime;
        ChannelCfgData _cameraData;
        List<ChannelCfgData> CameraDataList;

        Visibility _loadingAnimationVisiblity;
        CaptureRecordQueryValue captureRecordQueryValueOld;


        /// <summary>
        /// Channel Name
        /// </summary>
        public string CameraName
        {
            get { return _cameraName; }
            set { _cameraName = value; }
        }

        /// <summary>
        /// Start Datetime
        /// </summary>
        public string StartDatetime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /// <summary>
        /// End Datetime
        /// </summary>
        public string EndDatetime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        /// <summary>
        /// Channel Data for ComboBox seleteditem
        /// </summary>
        public ChannelCfgData CameraData
        {
            get { return _cameraData; }
            set { _cameraData = value; }
        }

        /// <summary>
        /// Channel Data List
        /// for Combobox
        /// </summary>
        public List<ChannelCfgData> CameraDataList1
        {
            get { return CameraDataList; }
            set { CameraDataList = value; }
        }

        public Visibility LoadingAnimationVisiblity
        {
            get
            {
                return _loadingAnimationVisiblity;
            }

            set
            {
                _loadingAnimationVisiblity = value;
            }
        }
    }
}
