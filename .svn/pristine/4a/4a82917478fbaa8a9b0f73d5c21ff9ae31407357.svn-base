using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.BaseTools;
using SING.Data.ScheduleProcess;

namespace SING.Data.Data
{
    [Serializable]
    public class ZoneCfgViewData: ZoneCfgData
    {
        private List<ZoneCfgViewData> _ZoneCfgViewDatas;

        public List<ZoneCfgViewData> ZoneCfgViewDatas
        {
            get
            {
                return _ZoneCfgViewDatas;
            }
            set
            {
                this._ZoneCfgViewDatas = value;
                OnPropertyChanged("ZoneCfgViewDatas");
            }
        }

        private List<ChannelCfgData> _ChannelCfgDatas;

        public List<ChannelCfgData> ChannelCfgDatas
        {
            get
            {
                return _ChannelCfgDatas;
            }
            set
            {
                this._ChannelCfgDatas = value;
                OnPropertyChanged("ChannelCfgDatas");
            }
        }

        public static ZoneCfgViewData ConvertToViewData(ZoneCfg oridata)
        {
            ZoneCfgViewData target = new ZoneCfgViewData();
            target.Div_index = oridata.Div_index;
            target.Div_name = oridata.Div_name;
            target.Div_parent = oridata.Div_parent;
            target.Div_parents = oridata.Div_parents;
            target.Div_order = oridata.Div_order;
            target.Div_orderidx = oridata.Div_orderidx;
            target.Div_memo = oridata.Div_memo;
            return target;
        }

        public static List<ZoneCfgViewData> FindAll()
        {
            List<ZoneCfgViewData> list = new List<ZoneCfgViewData>();
            ZoneCfgViewData _ZoneCfgViewData = ScheduleGet.QueryZone(AppConfig.Instance.UserInfo.UserInfo.Div_index);

            if (_ZoneCfgViewData != null)
            {
                _ZoneCfgViewData.ZoneCfgViewDatas = FindChildZoneByDivIndex(_ZoneCfgViewData.Div_index);
                _ZoneCfgViewData.ChannelCfgDatas = ScheduleGet.QueryAllChannel(_ZoneCfgViewData.Div_index);
            }
            list.Add(_ZoneCfgViewData);
            return list;
        }

        private static List<ZoneCfgViewData> FindChildZoneByDivIndex(string div_Index)
        {
            if (string.IsNullOrEmpty(div_Index)) return null;

            List<ZoneCfgViewData> ZoneCfgViewDatas = ScheduleGet.QueryListZone(null, div_Index, null, -1, -1);

            if (ZoneCfgViewDatas != null && ZoneCfgViewDatas.Count > 0)
            {
                for (int i = 0; i < ZoneCfgViewDatas.Count; i++)
                {
                    ZoneCfgViewData _ZoneCfgViewData = ZoneCfgViewDatas[i];
                    _ZoneCfgViewData.ZoneCfgViewDatas = FindChildZoneByDivIndex(_ZoneCfgViewData.Div_index);
                    _ZoneCfgViewData.ChannelCfgDatas = ScheduleGet.QueryAllChannel(_ZoneCfgViewData.Div_index);
                }
            }

            return ZoneCfgViewDatas;
        }
    }
}
