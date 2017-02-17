using FACE_SearchHistoryManagement.Models;
using System.Collections.Generic;

namespace FACE_SearchHistoryManagement.Services
{
    public interface IDataService
    {
        List<SCountInfo> QueryCapRecordTotalCountH(CaptureRecordQueryValue captureRecordQueryValue);

        List<SCountInfo> QueryCapRecordTotalCountHSXC(CaptureRecordQueryValue captureRecordQueryValue, List<string> channelName);

        List<MyCapFaceLogWithImg> QueryCapLog(CaptureRecordQueryValue captureRecordQueryValue, int pageSize);

        List<MyCapFaceLogWithImg> QueryCapLogSXC(CaptureRecordQueryValue captureRecordQueryValue, List<string> channelList, int pageSize);


        #region 查询图片数据
        List<byte[]> QueryCapLogImageH(string ID, string day);

        List<byte[]> QuerySenceImg(string ID, string day);
        #endregion
    }
}
