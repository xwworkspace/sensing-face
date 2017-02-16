using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.BaseTools;
using SING.Data.Data;
using SING.Data.ScheduleProcess;

namespace SING.Data.Help
{
    public class BasicData
    {
        private static List<STypeInfoData> _defFaceObjType;

        public static List<STypeInfoData> DefFaceObjType
        {
            get
            {
                if (null == _defFaceObjType)
                {
                    try
                    {
                        _defFaceObjType = ScheduleGet.QueryDefFaceObjTypeH(-1);
                    }
                    catch (Exception ex)
                    {
                        _defFaceObjType = null;
                    }
                }
                return _defFaceObjType;
            }
            set { _defFaceObjType = value; }
        }

        private static List<ZoneCfgViewData> _ZoneCfgViewDatas;
        public static List<ZoneCfgViewData> ZoneCfgViewDatas
        {
            get
            {
                if (null == _ZoneCfgViewDatas)
                {
                    try
                    {
                        _ZoneCfgViewDatas = ZoneCfgViewData.FindAll();
                    }
                    catch (Exception ex)
                    {
                        _ZoneCfgViewDatas = null;
                    }

                }
                return _ZoneCfgViewDatas;
            }
        }
    }
}
