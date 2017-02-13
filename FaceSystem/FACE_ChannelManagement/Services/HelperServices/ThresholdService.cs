using FACE_ChannelManagement.ViewModels;
using SING.Data.BaseTools;
using SING.Data.Logger;
using SING.Data.ScheduleProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_ChannelManagement.Services.HelperServices
{
    public class ThresholdService
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
                Logger.Error("ThresholdService:阈值启动查询异常", err);
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
            //try
            //{
            //    List<string> Threshold = new List<string>();
            //    for (int i = 1; i < 100; i++)
            //    {
            //        Threshold.Add(i + "");
            //    }

            //    int threshold = ScheduleGet.QueryThreshold();
            //    if (threshold == -1)
            //    {
            //        viewModel.SelectedThreshold = Convert.ToInt32(AppConfig.Instance.Threshold) - 1;
            //    }
            //    else
            //    {
            //        double trueThreshold = Math.Sqrt(threshold) * 10;
            //        trueThreshold = Math.Round(trueThreshold, 0, MidpointRounding.AwayFromZero);
            //        viewModel.SelectedThreshold = Convert.ToInt32(trueThreshold) - 1;
            //    }
            //    viewModel.Threshold = Threshold;
            //    viewModel.ThresholdCV = new ListCollectionView(viewModel.Threshold);
            //    viewModel.ThresholdCV.CurrentChanged += new EventHandler(ThresholdItemChanged);
            //}
            //catch (Exception err)
            //{
            //    Logger.Error("查询阈值异常", err);
            //}
        }

        public void ThresholdItemChanged(object sender, EventArgs e)
        {
            //ScheduleUpdate.SetCMPthreshold(Convert.ToInt32(viewModel.SelectedThreshold + 1));
        }
    }
}
