using FACE_ChannelManagement.ViewModels;
using SING.Data.Logger;
using System;
using System.ComponentModel;

namespace FACE_ChannelManagement.Services.ChannelServices
{
    public class InitChannelService
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
                Worker.RunWorkerCompleted += RunWorkerCompleted;
                Worker.ProgressChanged += ProgressChanged;
                Worker.RunWorkerAsync();
            }
            catch (Exception err)
            {
                Logger.Error("ChannelService:通道启动查询异常", err);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //viewModel.Progress.ProgressValue = e.ProgressPercentage;
        }

    }
}
