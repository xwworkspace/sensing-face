using FACE_ChannelManagement.Models;
using FACE_ChannelManagement.ViewModels;
using SING.Data.Data;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace FACE_ChannelManagement.Services.ChannelServices
{
    public class InitChannelService
    {
        private ViewModel viewModel;
        private BackgroundWorker Worker;//后台线程  查询并加载通道列表

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

                Worker = new BackgroundWorker();//新的线程  用来异步加载摄像头录像内容
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
            SearchChannel();
        }
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //viewModel.Progress.ProgressValue = e.ProgressPercentage;
        }

        /// <summary>
        /// 通道查询，并加载通道列表数据
        /// </summary>
        private void SearchChannel()
        {
            try
            {
                List<ChannelCfgViewData> ChannelList = new List<ChannelCfgViewData>();//前端视图Model

                List<ChannelCfgData> list = ScheduleGet.QueryAllChannel();//所有通道，及其详细信息

                if (list != null && list.Count > 0)
                {
                    foreach (ChannelCfgData data in list)
                    {
                        ChannelCfgViewData viewData = new ChannelCfgViewData();
                        viewData.ChannelCfgData = data;
                        viewData.IsOpened = false;
                        ChannelList.Add(viewData);
                    }
                    ChannelCfgViewData viewData1 = new ChannelCfgViewData();
                    viewData1.ChannelCfgData = new ChannelCfgData()
                    {
                        Name = "xiaowen test"
                    };
                    viewData1.IsOpened = false;
                    ChannelList.Add(viewData1);
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
