using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_SnapAlignmentManagement.ViewModels;
using FACE_SnapAlignmentManagement.Services.ChannelService;
using FACE_SnapAlignmentManagement.Services.HelpService;

namespace FACE_SnapAlignmentManagement.Services
{
    [Export(typeof(IDataService))]
    public class DataService: IDataService
    {
        public void InitialChannel(ViewModel viewModel)
        {
            IniChannelService service = new IniChannelService();
            service.DoWork(viewModel);
        }

        public void IniThreshold(ViewModel viewModel)
        {
            ThresholdService thresholdService = new ThresholdService();
            thresholdService.DoWork(viewModel);
        }

        public void RealtimeCap(ViewModel viewModel)
        {
            RealtimeCapService realtimeCapService = new RealtimeCapService();
            realtimeCapService.DoWork(viewModel);
        }

        public void RealtimeCmp(ViewModel viewModel)
        {
            RealtimeCmpService realtimeCmpService = new RealtimeCmpService();
            realtimeCmpService.DoWork(viewModel);
        }
    }
}
