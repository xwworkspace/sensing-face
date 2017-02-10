using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_SnapAlignmentManagement.ViewModels;

namespace FACE_SnapAlignmentManagement.Services
{
    public interface IDataService
    {
        void InitialChannel(ViewModel viewModel);

        void IniThreshold(ViewModel viewModel);

        void RealtimeCap(ViewModel viewModel);
        void RealtimeCmp(ViewModel viewModel);
    }
}
