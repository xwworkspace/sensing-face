using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_SearchHistoryManagement.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
    }
}
