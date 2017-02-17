using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using FACE_SearchHistoryManagement.Models;
using FACE_SearchHistoryManagement.Services.HistoryServices;

namespace FACE_SearchHistoryManagement.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        public List<MyCapFaceLogWithImg> QueryCapLog(CaptureRecordQueryValue captureRecordQueryValue, int pageSize)
        {
            return new ThriftService().QueryCapLog(captureRecordQueryValue, pageSize);
        }



        public List<MyCapFaceLogWithImg> QueryCapLogSXC(CaptureRecordQueryValue captureRecordQueryValue, List<string> channelList, int pageSize)
        {
            return new ThriftService().QueryCapLogSXC(captureRecordQueryValue, channelList, pageSize);
        }

        public List<SCountInfo> QueryCapRecordTotalCountH(CaptureRecordQueryValue captureRecordQueryValue)
        {
            return new ThriftService().QueryCapRecordTotalCountH(captureRecordQueryValue);
        }

        public List<SCountInfo> QueryCapRecordTotalCountHSXC(CaptureRecordQueryValue captureRecordQueryValue, List<string> channelName)
        {
            return new ThriftService().QueryCapRecordTotalCountHSXC(captureRecordQueryValue, channelName);
        }


        #region 查询图片数据
        public List<byte[]> QueryCapLogImageH(string ID, string day)
        {
            return new ThriftService().QueryCapLogImageH(ID, day);
        }

        public List<byte[]> QuerySenceImg(string ID, string day)
        {
            return new ThriftService().QuerySenceImg(ID, day);
        }
        #endregion
    }
}
