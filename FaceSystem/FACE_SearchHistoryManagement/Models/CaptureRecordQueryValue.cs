namespace FACE_SearchHistoryManagement.Models
{
    public class CaptureRecordQueryValue
    {
        /// <summary>
        /// 选择的通道
        /// </summary>
        public string ChannelValue { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public long StartDayValue { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public long EndDayValue { get; set; }
        ///// <summary>
        ///// 每页现实的行数
        ///// </summary>
        //public int PageRowValue { get; set; }
        /// <summary>
        /// 从第几行开始获取
        /// </summary>
        public int StartRowValue { get; set; }

        public int MaxCount { get; set; }
    }
}
