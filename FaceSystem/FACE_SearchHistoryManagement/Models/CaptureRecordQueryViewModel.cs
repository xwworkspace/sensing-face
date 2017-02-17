using System.Collections.Generic;
using System.Windows;

namespace FACE_SearchHistoryManagement.Models
{
    public class CaptureRecordQueryViewModel
    {
        //通道      
        private int selectedChannel;
        public int SelectedChannel
        {
            get { return selectedChannel; }
            set
            {
                selectedChannel = value;
            }
        }
        private List<string> channel;
        public List<string> Channel
        {
            get { return channel; }
            set
            {
                channel = value;
            }
        }

        public List<string> ChannelId;
        //开始日期
        private string startDay;
        public string StartDay
        {
            get { return startDay; }
            set
            {
                startDay = value;
            }
        }

        //开始时辰
        private int selectedStartHour;
        public int SelectedStartHour
        {
            get { return selectedStartHour; }
            set
            {
                selectedStartHour = value;
            }
        }
        private List<string> startHour;
        public List<string> StartHour
        {
            get { return startHour; }
            set
            {
                startHour = value;
            }
        }


        private List<string> startMinutes;
        /// <summary>
        /// 开始分钟
        /// </summary>
        public List<string> StartMinutes
        {
            get { return startMinutes; }
            set
            {
                startMinutes = value;
            }
        }

        //结束日期
        private string endDay;
        public string EndDay
        {
            get { return endDay; }
            set
            {
                endDay = value;
            }
        }

        //结束时辰
        private int selectedEndHour;
        public int SelectedEndHour
        {
            get { return selectedEndHour; }
            set
            {
                selectedEndHour = value;
            }
        }
        private List<string> endHour;
        public List<string> EndHour
        {
            get { return endHour; }
            set
            {
                endHour = value;
            }
        }

        private List<string> endMinutes;
        /// <summary>
        /// 结束分钟
        /// </summary>
        public List<string> EndMinutes
        {
            get { return endMinutes; }
            set
            {
                endMinutes = value;
            }
        }

        //loading动画显示
        private Visibility loadingVisiblity;
        public Visibility LoadingVisiblity
        {
            get { return loadingVisiblity; }
            set
            {
                loadingVisiblity = value;
            }
        }

        //查询结果总数量
        private int maxCount;
        public int MaxCount
        {
            get { return maxCount; }
            set
            {
                maxCount = value;
            }
        }

        //当前页码
        private int currPage;
        public int CurrPage
        {
            get { return currPage; }
            set
            {
                currPage = value;
            }
        }

        //总的页码数
        private int maxPage;
        public int MaxPage
        {
            get { return maxPage; }
            set
            {
                maxPage = value;
            }
        }


        //查询时条件值
        public CaptureRecordQueryValue captureRecordQueryValueOld;

        #region 初始化和命令的执行和执行条件
        public CaptureRecordQueryViewModel()
        {
            //初始化条件的初值
            captureRecordQueryValueOld = new CaptureRecordQueryValue();

            //初始化通道
            Channel = new List<string>();
            ChannelId = new List<string>();
            RefreshChannelList();

            SelectedChannel = 0;

            //初始化开始日期
            StartDay = System.DateTime.Today.ToShortDateString();

            //初始化结束日期
            EndDay = "";

            //初始化开始时辰和结束时辰和选择时间
            StartHour = new List<string>();
            EndHour = new List<string>();
            for (int i = 0; i <= 23; i++)
            {
                StartHour.Add(i + ":00");
                EndHour.Add(i + 1 + ":00");
            }
            SelectedEndHour = 23;
            SelectedStartHour = 0;
            //初始化开始和结束分钟
            StartMinutes = new List<string>();
            EndMinutes = new List<string>();
            for (int i = 0; i <= 59; i++)
            {
                StartMinutes.Add(i + "");
                EndMinutes.Add(i + 1 + "");
            }

            //初始化loading图片 Hidden Visible
            LoadingVisiblity = Visibility.Hidden;

            //初始化当前页
            CurrPage = 0;
            //初始化最大页
            MaxPage = 0;
            //初始化最大查询数
            MaxCount = 0;
        }

        internal void RefreshChannelList()
        {
            //var ChannelTemp = new List<string>();
            //var ChannelIdTemp = new List<string>();
            //foreach (MyChannelCfg mcc in thirft.QueryAllChannel())
            //{
            //    if (UserData.ClientType == "1")
            //    {
            //        if (mcc.Name.Contains(UserData.ClientRegionName))
            //        {
            //            ChannelTemp.Add(mcc.Name);
            //            ChannelIdTemp.Add(mcc.TcChaneelID);
            //        }
            //    }
            //    else
            //    {
            //        ChannelTemp.Add(mcc.Name);
            //        ChannelIdTemp.Add(mcc.TcChaneelID);
            //    }
            //}
            //ChannelTemp.Insert(0, "全部");
            //Channel = ChannelTemp;
            //ChannelId = ChannelIdTemp;
        }


        #endregion
    }
}
