using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using FACE_CaptureComparisonManagement.ViewModels;
using SING.Data.Data;
using SING.Data.Logger;

namespace FACE_CaptureComparisonManagement.Services.HelpService
{
    public class RealtimeCapService
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
                Logger.Error("RealtimeCapService:启动实时抓拍数据查询异常", err);
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
                            if (viewModel.ListCapFaceLogWithImgData == null) viewModel.ListCapFaceLogWithImgData = new List<CapFaceLogWithImgData>();
                            if (viewModel.CurrentCapFaceLogWithImgData == null) continue;

                            viewModel.ListCapFaceLogWithImgData.Insert(0, viewModel.CurrentCapFaceLogWithImgData);

                            if (viewModel.ListCapFaceLogWithImgData.Count > 100)
                            {
                                viewModel.ListCapFaceLogWithImgData.RemoveRange(9, 90);
                            }
                            if (viewModel.ListCapFaceLogWithImgData != null && viewModel.ListCapFaceLogWithImgData.Count > 0)
                            {
                                viewModel.CapFaceLogWithImgDataCV = new ListCollectionView(viewModel.ListCapFaceLogWithImgData);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("实时抓拍异常：RealtimeCapService", ex);
                            return;
                        }
                        viewModel.ResetServerRealtimeCapInfo.Reset();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Error("实时抓拍异常：RealtimeCapService", ex);
            }
        }
    }
}
