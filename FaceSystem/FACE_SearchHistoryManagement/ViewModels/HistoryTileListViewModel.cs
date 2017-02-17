using FACE_SearchHistoryManagement.Models;
using FACE_SearchHistoryManagement.Utilities;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using SING.Data.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace FACE_SearchHistoryManagement.ViewModels
{
    /// <summary>
    /// HistoryTileListViewModel
    /// </summary>
    public partial class ViewModel : NotificationObject
    {
        void InitHistoryTileListViewModel()
        {
            SearchBtnCommand = new DelegateCommand<object>(SearchBtnCommandFunc);

            _historySearchParamsModel = new CaptureRecordQueryViewModel();
            getHistoryDataDelegate = GetHistoryData;

        }

        #region Command
        public ICommand SearchBtnCommand { get; private set; }
        #endregion

        #region CommandFunc

        public void SearchBtnCommandFunc(object obj)
        {
            HistorySearchParamsModel.captureRecordQueryValueOld.ChannelValue = HistorySearchParamsModel.SelectedChannel == 0 ? "" : HistorySearchParamsModel.ChannelId[HistorySearchParamsModel.SelectedChannel - 1];
            IntiQueryTime();
            if (HistorySearchParamsModel.captureRecordQueryValueOld.StartDayValue == -1 || (HistorySearchParamsModel.captureRecordQueryValueOld.EndDayValue - HistorySearchParamsModel.captureRecordQueryValueOld.StartDayValue > 60 * 60 * 24 * 7))
            {
                MessageBox.Show("起始时间不能为空且起始和终止时间相差不能超过七天!");
                return;
            }
            getHistoryDataDelegate.BeginInvoke(1, 80, null, null);
        }

        #endregion

        #region ThriftService

        #endregion

        #region View Properties

        CaptureRecordQueryViewModel _historySearchParamsModel;
        string currDay = string.Empty;

        public CaptureRecordQueryViewModel HistorySearchParamsModel
        {
            get { return _historySearchParamsModel; }

            set
            {
                _historySearchParamsModel = value;
                RaisePropertyChanged("HistorySearchParamsModel");
            }
        }


        MyCapFaceLogWithImg _historySnapSelectedItem;

        /// <summary>
        /// 一条历史记录
        /// </summary>
        public MyCapFaceLogWithImg HistorySnapSelectedItem
        {
            get
            {
                //当前选中项
                Action act = () =>
                {
                    Thread threadQuery = new Thread(new ParameterizedThreadStart(ThreadQueuenViewSnapHistory));
                    threadQuery.SetApartmentState(ApartmentState.STA);
                    threadQuery.Start(_historySnapSelectedItem);
                };
                act();

                return _historySnapSelectedItem;
            }
            set
            {
                _historySnapSelectedItem = value;
                RaisePropertyChanged("HistorySnapSelectedItem");
            }
        }

        //抓拍记录结果
        private List<MyCapFaceLogWithImg> _historySnapItemSource;

        /// <summary>
        /// 历史记录数据源 list
        /// </summary>
        public List<MyCapFaceLogWithImg> HistorySnapItemSource
        {
            get { return _historySnapItemSource; }
            set
            {
                _historySnapItemSource = value;
                RaisePropertyChanged("HistorySnapItemSource");
            }
        }


        #endregion

        #region Variable for this

        Action<int, int> getHistoryDataDelegate;


        #region old

        #endregion

        #endregion

        #region CommonFunc

        /// <summary>
        /// 初始化时间
        /// </summary>
        private void IntiQueryTime()
        {
            //开始时间
            long longdtPkCompRecordStarTime = -1;
            if (HistorySearchParamsModel.StartDay != string.Empty)
            {
                string strCompRecordStarTime = HistorySearchParamsModel.StartDay;
                DateTime dt1 = Convert.ToDateTime(strCompRecordStarTime);
                TimeSpan dt1Span = new TimeSpan(dt1.Ticks);

                DateTime dt2 = new DateTime(1970, 1, 1);
                TimeSpan dt2Span = new TimeSpan(dt2.Ticks);

                longdtPkCompRecordStarTime = Convert.ToInt64(dt1Span.TotalSeconds - dt2Span.TotalSeconds);
                if (HistorySearchParamsModel.SelectedStartHour != -1)
                {
                    longdtPkCompRecordStarTime = longdtPkCompRecordStarTime + int.Parse(HistorySearchParamsModel.SelectedStartHour.ToString()) * 60 * 60 + 1 * 60;
                }
            }
            HistorySearchParamsModel.captureRecordQueryValueOld.StartDayValue = longdtPkCompRecordStarTime;
            //结束时间
            long longdtPkCompRecordEndTime = -1;
            if (HistorySearchParamsModel.EndDay != string.Empty)
            {
                string strCompRecordEndTime = HistorySearchParamsModel.EndDay;
                DateTime dt1 = Convert.ToDateTime(strCompRecordEndTime);
                TimeSpan dt1Span = new TimeSpan(dt1.Ticks);

                DateTime dt2 = new DateTime(1970, 1, 1);
                TimeSpan dt2Span = new TimeSpan(dt2.Ticks);

                longdtPkCompRecordEndTime = Convert.ToInt64(dt1Span.TotalSeconds - dt2Span.TotalSeconds);
                if (HistorySearchParamsModel.SelectedEndHour != -1)
                {
                    longdtPkCompRecordEndTime = longdtPkCompRecordEndTime + int.Parse(HistorySearchParamsModel.SelectedEndHour.ToString()) * 60 * 60 + 1 * 60 + 3660;
                }
            }
            else
            {
                string strCompRecordEndTime = System.DateTime.Now.ToString();
                DateTime dt1 = Convert.ToDateTime(strCompRecordEndTime);
                TimeSpan dt1Span = new TimeSpan(dt1.Ticks);

                DateTime dt2 = new DateTime(1970, 1, 1);
                TimeSpan dt2Span = new TimeSpan(dt2.Ticks);
                longdtPkCompRecordEndTime = Convert.ToInt64(dt1Span.TotalSeconds - dt2Span.TotalSeconds);
            }
            HistorySearchParamsModel.captureRecordQueryValueOld.EndDayValue = longdtPkCompRecordEndTime;
        }

        /// <summary>
        /// GetHistoryData
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        void GetHistoryData(int pageIndex, int pageSize)
        {
            try
            {
                List<int> pageSplit = new List<int>();
                int curpage = 0;
                int index = 0;
                //HistorySearchParamsModel.LoadingVisiblity = Visibility.Visible;//程序加载期间使用的动画，原程序雷达动画
                List<MyCapFaceLogWithImg> listMyCapFaceLogWithImg = new List<MyCapFaceLogWithImg>();
                List<SCountInfo> queryCount = new List<SCountInfo>();
                if (UserData.ClientType != "1")
                {
                    queryCount = _dataService.QueryCapRecordTotalCountH(HistorySearchParamsModel.captureRecordQueryValueOld);
                }
                else
                {
                    if (HistorySearchParamsModel.captureRecordQueryValueOld.ChannelValue != "")
                    {
                        List<string> channelTemp = new List<string>();
                        channelTemp.Add(HistorySearchParamsModel.captureRecordQueryValueOld.ChannelValue);
                        queryCount = _dataService.QueryCapRecordTotalCountHSXC(HistorySearchParamsModel.captureRecordQueryValueOld, channelTemp);
                    }
                    else
                    {
                        queryCount = _dataService.QueryCapRecordTotalCountHSXC(HistorySearchParamsModel.captureRecordQueryValueOld, HistorySearchParamsModel.ChannelId);
                    }
                }

                if (queryCount.Count <= 0)
                {
                    return;
                }
                HistorySearchParamsModel.MaxCount = queryCount[0].Count;
                for (int no = queryCount[0].Dayarr.Count - 1; no >= 0; no--)
                {
                    var dayary = queryCount[0].Dayarr[no];
                    curpage += dayary.Count % pageSize != 0 ? dayary.Count / pageSize + 1 : dayary.Count / pageSize;
                    pageSplit.Add(curpage);
                }
                HistorySearchParamsModel.MaxPage = curpage;
                //根据页数判断是属于哪一天
                foreach (var dayPage in pageSplit)
                {
                    if (pageIndex <= dayPage)
                    {
                        index = pageSplit.IndexOf(dayPage);
                        //修改当前的时间 和 最大的结果数量
                        currDay = queryCount[0].Dayarr[queryCount[0].Dayarr.Count - 1 - index].Daystr;
                        DateTime dt1 = Convert.ToDateTime(queryCount[0].Dayarr[queryCount[0].Dayarr.Count - 1 - index].Daystr.Insert(6, "/").Insert(4, "/"));
                        TimeSpan dt1Span = new TimeSpan(dt1.Ticks);
                        DateTime dt2 = new DateTime(1970, 1, 1);
                        TimeSpan dt2Span = new TimeSpan(dt2.Ticks);
                        long longdtPkCompRecordStarTime = Convert.ToInt64(dt1Span.TotalSeconds - dt2Span.TotalSeconds);
                        if (longdtPkCompRecordStarTime > HistorySearchParamsModel.captureRecordQueryValueOld.StartDayValue)
                        {
                            HistorySearchParamsModel.captureRecordQueryValueOld.StartDayValue = longdtPkCompRecordStarTime;
                        }
                        if (pageIndex != HistorySearchParamsModel.MaxPage)
                        {
                            long longdtPkCompRecordEndTime = Convert.ToInt64(dt1Span.TotalSeconds - dt2Span.TotalSeconds) + 24 * 60 * 60;
                            var todayEndtime = Convert.ToInt64(new TimeSpan(dt1.AddDays(1).Ticks).TotalSeconds - dt2Span.TotalSeconds);
                            if (longdtPkCompRecordEndTime > todayEndtime)
                            {
                                longdtPkCompRecordEndTime = todayEndtime;
                            }
                            HistorySearchParamsModel.captureRecordQueryValueOld.EndDayValue = longdtPkCompRecordEndTime;
                        }
                        HistorySearchParamsModel.captureRecordQueryValueOld.MaxCount = queryCount[0].Dayarr[queryCount[0].Dayarr.Count - 1 - index].Count;
                        break;
                    }
                }
                if (pageIndex > 1)
                {
                    int pageTem = 0;
                    if (index == 0)
                    {
                        pageTem = 0;
                    }
                    else
                    {
                        pageTem = pageSplit[index - 1];
                    }
                    HistorySearchParamsModel.captureRecordQueryValueOld.StartRowValue = HistorySearchParamsModel.captureRecordQueryValueOld.MaxCount - ((pageIndex - pageTem) * pageSize);
                    if (HistorySearchParamsModel.captureRecordQueryValueOld.StartRowValue < 0)
                    {
                        HistorySearchParamsModel.captureRecordQueryValueOld.StartRowValue = 0;
                    }
                }
                else
                {
                    HistorySearchParamsModel.captureRecordQueryValueOld.StartRowValue = HistorySearchParamsModel.captureRecordQueryValueOld.MaxCount - (pageSize);
                    if (HistorySearchParamsModel.captureRecordQueryValueOld.StartRowValue < 0)
                    {
                        HistorySearchParamsModel.captureRecordQueryValueOld.StartRowValue = 0;
                    }
                }
                HistorySearchParamsModel.CurrPage = pageIndex;
                int countTem = 0;
                for (int n = 0; n <= index; n++)
                {
                    var dayary = queryCount[0].Dayarr[queryCount[0].Dayarr.Count - 1 - n].Count;
                    countTem += dayary;
                }
                HistorySearchParamsModel.captureRecordQueryValueOld.MaxCount = countTem;

                if (UserData.ClientType != "1")
                {
                    HistorySnapItemSource = _dataService.QueryCapLog(HistorySearchParamsModel.captureRecordQueryValueOld, pageSize);
                }
                else
                {
                    if (HistorySearchParamsModel.captureRecordQueryValueOld.ChannelValue != "")
                    {
                        List<string> channelTemp = new List<string>();
                        channelTemp.Add(HistorySearchParamsModel.captureRecordQueryValueOld.ChannelValue);
                        HistorySnapItemSource = _dataService.QueryCapLogSXC(HistorySearchParamsModel.captureRecordQueryValueOld, channelTemp, pageSize);
                    }
                    else
                    {
                        HistorySnapItemSource = _dataService.QueryCapLogSXC(HistorySearchParamsModel.captureRecordQueryValueOld, HistorySearchParamsModel.ChannelId, pageSize);
                    }
                }
                //HistorySearchParamsModel.LoadingVisiblity = Visibility.Hidden;
                /*
                 --kelvin 更新页面ListView数据
                 */
                //System.Windows.Threading.Dispatcher.BeginInvoke(
                //                new Action(() =>
                //                {
                //                    if (listViewCaptureRecord.Items.Count > 0)
                //                    {
                //                        listViewCaptureRecord.ScrollIntoView(listViewCaptureRecord.Items[0]);
                //                    }
                //                }));

                RaisePropertyChanged("HistorySearchParamsModel");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.Info(string.Format("GetCaptureRecord", ex));
            }
            //finally
            //{
            //    HistorySearchParamsModel.LoadingVisiblity = Visibility.Hidden;
            //}
        }

        #endregion
    }
}
