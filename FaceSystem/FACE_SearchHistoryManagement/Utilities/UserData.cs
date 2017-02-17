using SING.Data.BaseTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_SearchHistoryManagement.Utilities
{
    public class UserData
    {
        public static readonly AppConfig AppConfig = AppConfig.Instance;

        public static readonly string ClientType = "0";

        public static readonly int ClientRegion = -1;

        public static readonly string ClientRegionName = "";
    }
    

    public enum ClientType
    {
        Filter = 0,
        Receive = 1
    }
}
