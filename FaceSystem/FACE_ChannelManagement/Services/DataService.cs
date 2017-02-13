using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_ChannelManagement.ViewModels;
using FACE_ChannelManagement.Services.ChannelServices;
using FACE_ChannelManagement.Services.HelperServices;

namespace FACE_ChannelManagement.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        public void InitialChannel(ViewModel viewModel)
        {
            InitChannelService service = new InitChannelService();
            service.DoWork(viewModel);
        }

        public void InitThreshold(ViewModel viewModel)
        {
            ThresholdService thresholdService = new ThresholdService();
            thresholdService.DoWork(viewModel);
        }
    }
}
