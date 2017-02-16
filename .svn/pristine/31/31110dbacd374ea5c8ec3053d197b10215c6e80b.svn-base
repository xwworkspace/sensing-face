using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FACE_CaptureComparisonManagement.ViewModels;
using SING.Data.Data;
using SING.Data.Logger;

namespace FACE_CaptureComparisonManagement.Services.HelpService
{
    public class RealtimeCmpService
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
                Logger.Error("RealtimeCmpService:启动实时比对数据查询异常", err);
            }
        }

        private void Do(object sender, DoWorkEventArgs e)
        {
            MonitorAction();
        }
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void MonitorAction()
        {
            try
            {
                #region
                while (true)
                {
                    if (viewModel.ResetServerRealtimeCapInfo.WaitOne()) //设置监听等待
                    {
                        try
                        {
                            viewModel.RealTimeCmpListView.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                if (viewModel.ListRealtimeCmpInfoViewData == null) viewModel.ListRealtimeCmpInfoViewData = new List<RealtimeCmpInfoViewData>();
                                if (viewModel.CurrentRealtimeCmpInfoViewData == null) return;

                                viewModel.ComImageCount++;
                                viewModel.ListRealtimeCmpInfoViewData.Insert(0, viewModel.CurrentRealtimeCmpInfoViewData);

                                if (viewModel.ListRealtimeCmpInfoViewData.Count > 100)
                                {
                                    viewModel.ListRealtimeCmpInfoViewData.RemoveRange(9, 90);
                                }
                                if (viewModel.ListRealtimeCmpInfoViewData != null && viewModel.ListRealtimeCmpInfoViewData.Count > 0)
                                {
                                    viewModel.RealtimeCmpInfoViewDataCV = new ListCollectionView(viewModel.ListRealtimeCmpInfoViewData);
                                }
                            }));
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("实时比对异常：RealtimeCmpService", ex);
                            return;
                        }
                        viewModel.ResetServerRealtimeCapInfo.Reset();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Error("实时比对异常：RealtimeCmpService", ex);
            }
        }
    }
}
