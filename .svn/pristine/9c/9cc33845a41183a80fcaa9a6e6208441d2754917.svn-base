using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FACE_SnapAlignmentManagement.Models;
using FACE_SnapAlignmentManagement.ViewModels;
using SING.Data.Data;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;

namespace FACE_SnapAlignmentManagement.Services.ChannelService
{
    public class IniChannelService
    {
        private ViewModel viewModel;

        private BackgroundWorker Worker;

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //viewModel.Progress.IsBusyHanding = false;
        }
        public void DoWork(ViewModel _viewModel)
        {
            try
            {
                this.viewModel = _viewModel;

                //viewModel.Progress = new ProgressSattus();
                //viewModel.Progress.IsBusyHanding = true;

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
            //viewModel.Progress.ProgressValue = e.ProgressPercentage;
        }

        private void Search()
        {
            try
            {
                List<ChannelCfgViewData> ChannelList = new List<ChannelCfgViewData>();
               
                List<ChannelCfgData> list = ScheduleGet.QueryAllChannel();

                if (list != null && list.Count > 0)
                {
                    foreach (ChannelCfgData data in list)
                    {
                        ChannelCfgViewData viewData = new ChannelCfgViewData();
                        viewData.ChannelCfgData = data;
                        viewData.IsOpened = false;
                        ChannelList.Add(viewData);
                    }
                    viewModel.ChannelList = ChannelList;
                    viewModel.ChannelListCV = new ListCollectionView(viewModel.ChannelList);
                    viewModel.ChannelListCV.CurrentChanged += new EventHandler(viewModel.ChannelListItemChanged);
                }
            }
            catch (Exception err)
            {
                Logger.Error("查询通道异常", err);
            }
        }
    }
}
