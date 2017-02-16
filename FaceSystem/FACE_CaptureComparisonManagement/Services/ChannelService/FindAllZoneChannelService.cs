using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FACE_CaptureComparisonManagement.ViewModels;
using SING.Data.BaseTools;
using SING.Data.Data;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;

namespace FACE_CaptureComparisonManagement.Services.ChannelService
{
    public class FindAllZoneChannelService
    {
        private ViewModel viewModel;

        private BackgroundWorker Worker;

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
        public void DoWork(ViewModel _viewModel)
        {
            try
            {
                this.viewModel = _viewModel;

                Worker = new BackgroundWorker();
                Worker.WorkerReportsProgress = true;
                Worker.WorkerSupportsCancellation = true;
                Worker.DoWork += Do;
                Worker.RunWorkerCompleted += RunWorkerCompleted;
                Worker.ProgressChanged += ProgressChanged;
                Worker.RunWorkerAsync();
            }
            catch (Exception err)
            {
                Logger.Error("ChannelService:通道启动查询异常", err);
            }
        }
        private void Do(object sender, DoWorkEventArgs e)
        {
            Search();
        }
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void Search()
        {
            try
            {
                List<ZoneCfgViewData> ZoneCfgViewDatas = new List<ZoneCfgViewData>();

                ZoneCfgViewData _ZoneCfgViewData = ScheduleGet.QueryZone(AppConfig.Instance.UserInfo.UserInfo.Div_index);

                if (_ZoneCfgViewData != null)
                {
                    _ZoneCfgViewData.ZoneCfgViewDatas = FindChildZoneByDivIndex(_ZoneCfgViewData.Div_index);
                    _ZoneCfgViewData.ChannelCfgDatas = ScheduleGet.QueryAllChannel(_ZoneCfgViewData.Div_index);
                    ZoneCfgViewDatas.Add(_ZoneCfgViewData);

                    viewModel.ZoneChannelList = ZoneCfgViewDatas;
                    viewModel.ZoneChannelCV = new ListCollectionView(viewModel.ZoneChannelList);
                }
            }
            catch (Exception err)
            {
                Logger.Error("获取用户域通道异常：FindAllZoneChannelService", err);
            }
        }

        private static List<ZoneCfgViewData> FindChildZoneByDivIndex(string div_Index)
        {
            if (string.IsNullOrEmpty(div_Index)) return null;

            List<ZoneCfgViewData> ZoneCfgViewDatas = ScheduleGet.QueryListZone(null, div_Index, null, -1, -1);

            if (ZoneCfgViewDatas != null && ZoneCfgViewDatas.Count > 0)
            {
                for (int i = 0; i < ZoneCfgViewDatas.Count; i++)
                {
                    ZoneCfgViewData _ZoneCfgViewData = ZoneCfgViewDatas[i];
                    _ZoneCfgViewData.ZoneCfgViewDatas = FindChildZoneByDivIndex(_ZoneCfgViewData.Div_index);
                    _ZoneCfgViewData.ChannelCfgDatas = ScheduleGet.QueryAllChannel(_ZoneCfgViewData.Div_index);
                }
            }

            return ZoneCfgViewDatas;
        }
    }
}
