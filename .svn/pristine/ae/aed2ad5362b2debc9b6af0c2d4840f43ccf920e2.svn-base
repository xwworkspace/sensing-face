using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using SING.Data.BaseTools;
using SING.Data.Data;
using Thrift.Server;
using Thrift.Transport;

namespace SING.Data.ScheduleProcess
{

    public partial class ScheduleUIServer
    {
        private static TThreadPoolServer server;

        public static void ServiceProcessor()
        {
            FaceServer _FaceServer = new FaceServer();
            TServerSocket serverTransport = new TServerSocket(AppConfig.Instance.StartPortInt, 0, false);
            UIServer.Processor processor = new UIServer.Processor(_FaceServer);
            server = new TThreadPoolServer(processor, serverTransport);
            server.Serve();
        }
    }

    public class FaceServer : UIServer.Iface
    {
        private CapFaceLogWithImgData _CurrentCapFaceLogWidthImgData;
        private RealtimeCmpInfoViewData _CurrentRealtimeCmpInfoViewData;
        private static IEventAggregator _eventAggregator;
        public int UpdateRealtimeCap(RealtimeCapInfo info, string channelname)
        {
            try
            {
                if (_CurrentCapFaceLogWidthImgData != null) _CurrentCapFaceLogWidthImgData = null;
                _CurrentCapFaceLogWidthImgData = new CapFaceLogWithImgData();

                _CurrentCapFaceLogWidthImgData.ID = info.Id;
                _CurrentCapFaceLogWidthImgData.ChannelID = info.Channel;
                _CurrentCapFaceLogWidthImgData.ChannelName = channelname;

                _CurrentCapFaceLogWidthImgData.Time = info.Time;
                _CurrentCapFaceLogWidthImgData.Img = info.Image;


                _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                _eventAggregator.GetEvent<RealtimeCaptureEvent>().Publish(_CurrentCapFaceLogWidthImgData);
                info = null;
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("UpdateRealtimeCap", ex);
                return -1;
            }
        }

        public int UpdateRealtimeCmp(RealtimeCmpInfo info, string channelname)
        {
            try
            {
                if (_CurrentRealtimeCmpInfoViewData != null) _CurrentRealtimeCmpInfoViewData = null;
                _CurrentRealtimeCmpInfoViewData = new RealtimeCmpInfoViewData();

                _CurrentRealtimeCmpInfoViewData.CapID = info.CapID;
                _CurrentRealtimeCmpInfoViewData.ObjID = info.ObjID;
                if (String.IsNullOrEmpty(info.CapID) || String.IsNullOrEmpty(info.ObjID))
                {
                    Logger.Logger.Info("抓拍照片ID为空");
                }
                long _longtime = info.Time;
                DateTime s = new DateTime(1970, 1, 1);
                s = s.AddSeconds(_longtime);

                _CurrentRealtimeCmpInfoViewData.CapImg = info.CapImg;
                _CurrentRealtimeCmpInfoViewData.ObjImg = info.ObjImg;
                //获得主照片这侧信息
                StringBuilder strRegster = new StringBuilder();
                //注册名称
                strRegster.Append(info.Name + "\r\n");
                //获得通道名称
                string ChannelName = channelname;
                _CurrentRealtimeCmpInfoViewData.ChannelName = channelname;
                strRegster.Append(ChannelName.Replace("##", "").Replace("@", "") + "\r\n");
                //抓拍时间
                int nIndexS = s.ToString().IndexOf(" ");
                strRegster.Append(s.ToString().Substring(0, nIndexS) + "\r\n");
                int nIndexS1 = s.ToString().Length - nIndexS;
                strRegster.Append(s.ToString().Substring(nIndexS + 1, nIndexS1 - 1) + "\r\n");
                //注册类型
                string type = "";
                //foreach (var basicinfo in BasicInfo.DefFaceObjType)
                //{
                //    if (basicinfo.Type == info.Type)
                //    {
                //        type = basicinfo.Description; // 类型  
                //    }
                //}
                strRegster.Append(info.Type + "\r\n");
                _CurrentRealtimeCmpInfoViewData.Type = info.Type;
                //相似度。
                strRegster.Append(info.Score + "\r\n");
                _CurrentRealtimeCmpInfoViewData.RegInfo = strRegster.ToString();

                _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                _eventAggregator.GetEvent<RealtimeCmpInfoEvent>().Publish(_CurrentRealtimeCmpInfoViewData);

                info = null;
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("UpdateRealtimeCap", ex);
                return -1;
            }
        }
    }
    public class RealtimeCaptureEvent : CompositePresentationEvent<CapFaceLogWithImgData>
    {
    }
    public class RealtimeCmpInfoEvent : CompositePresentationEvent<RealtimeCmpInfoViewData>
    {
    }
}
