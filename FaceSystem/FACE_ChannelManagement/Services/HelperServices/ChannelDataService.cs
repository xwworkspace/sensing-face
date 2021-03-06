﻿using FACE_ChannelManagement.Models;
using SING.Data.BaseTools;
using SING.Data.Logger;
using System;
using System.Windows;
using Thrift.Protocol;
using Thrift.Transport;

namespace FACE_ChannelManagement.Services.HelperServices
{
    public class ChannelDataService
    {
        /// <summary>
        /// 添加频道
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public int AddChannel(ChannelCfg cfg)
        {
            TTransport transport = new TSocket(AppConfig.Instance.IP, AppConfig.Instance.Port);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            int nSucess = -1;
            try
            {
                #region
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                nSucess = _BusinessServerClient.AddChannel(cfg);
                transport.Close();
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("AddChannel {0}", ex.Message));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                MessageBox.Show("网络异常，稍后重试！");
            }
            return nSucess;
        }



        /// <summary>
        /// 修改频道
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public int ModifyChannel(ChannelCfg cfg)
        {
            TTransport transport = new TSocket(AppConfig.Instance.IP, AppConfig.Instance.Port);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            int nSucess = -1;
            try
            {
                #region
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                nSucess = _BusinessServerClient.ModifyChannel(cfg);
                transport.Close();
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("ModifyChannel {0}", ex.Message));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                MessageBox.Show("网络异常，稍后重试！");
            }
            return nSucess;
        }

        /// <summary>
        /// 删除通道
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="ip_port"></param>
        /// <returns>
        ///   -1 出错 
        /// 非-1 成功
        /// </returns>
        public int DelChannel(string channelID, params object[] ip_port)
        {
            object ip, port;
            if (ip_port != null && ip_port.Length == 2)
            {
                ip = ip_port[0];
                port = ip_port[1];
            }
            else
            {
                ip = AppConfig.Instance.IP;
                port = AppConfig.Instance.Port;
            }

            TTransport transport = new TSocket(ip.ToString(), (int)port);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            int nSucess = -1;
            try
            {
                #region
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                nSucess = _BusinessServerClient.DelChannel(channelID);
                transport.Close();
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("DelChannel", ex));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                MessageBox.Show(string.Format("服务器地址出现问题，请联系管理员处理！\n错误信息：{0}\n", ex.Message));
            }
            return nSucess;
        }


        public ChannelCameraInfoViewData ConvertToViewData(ChannelCfg thriftData)
        {
            ChannelCameraInfoViewData channelInfoData = new ChannelCameraInfoViewData();
            channelInfoData.ChannelId = thriftData.TcChaneelID;
            channelInfoData.ChannelName = thriftData.Name;
            channelInfoData.Remark = thriftData.TcDescription;
            channelInfoData.CaptureAddr = thriftData.Addr;
            channelInfoData.CapturePort =
                thriftData.Port.ToString();
            channelInfoData.SelectedType = thriftData.CaptureCfg.NCaptureType;
            channelInfoData.VideoAddr = thriftData.CaptureCfg.TcAddr;
            channelInfoData.UID = thriftData.CaptureCfg.TcUID;
            channelInfoData.PSW = thriftData.CaptureCfg.TcPSW;
            channelInfoData.VideoPort =
                thriftData.CaptureCfg.NPort.ToString();
            channelInfoData.MinFace =
                thriftData.CatchFaceCfg.NMinFace.ToString();
            channelInfoData.MinQuality =
                thriftData.CatchFaceCfg.NMinQuality.ToString();
            channelInfoData.MinCapDistance =
                thriftData.CatchFaceCfg.NMinCapDistance.ToString();
            channelInfoData.MaxFaceSaveDistance = thriftData.CatchFaceCfg.NMaxFaceSaveDistance.ToString();

            channelInfoData.Yaw = thriftData.CatchFaceCfg.NYaw.ToString();
            channelInfoData.Pitch = thriftData.CatchFaceCfg.NPitch.ToString();
            channelInfoData.Yoll = thriftData.CatchFaceCfg.NYoll.ToString();

            return channelInfoData;
        }


        public ChannelCfg ConvertToChannelCfgData(ChannelCameraInfoViewData viewData)
        {
            ChannelCfg channelCfg = new ChannelCfg();

            channelCfg.TcChaneelID = viewData.ChannelId;
            channelCfg.Name = viewData.ChannelName;
            channelCfg.TcDescription = viewData.Remark;
            channelCfg.Addr = viewData.CaptureAddr;
            channelCfg.Port = Convert.ToInt32(viewData.CapturePort);
            channelCfg.CaptureCfg = new CaptureCfg();
            channelCfg.CaptureCfg.NCaptureType = viewData.SelectedType;
            channelCfg.CaptureCfg.TcAddr = viewData.VideoAddr;
            channelCfg.CaptureCfg.TcUID = viewData.UID;
            channelCfg.CaptureCfg.TcPSW = viewData.PSW;
            channelCfg.CaptureCfg.NPort = Convert.ToInt32(viewData.VideoPort);
            channelCfg.CatchFaceCfg = new CatchFaceCfg();
            channelCfg.CatchFaceCfg.NMinFace = Convert.ToInt32(viewData.MinFace);
            channelCfg.CatchFaceCfg.NMinQuality = Convert.ToInt32(viewData.MinQuality);
            channelCfg.CatchFaceCfg.NMinCapDistance = Convert.ToInt32(viewData.MinCapDistance);
            channelCfg.CatchFaceCfg.NMaxFaceSaveDistance = Convert.ToInt32(viewData.MaxFaceSaveDistance);
            channelCfg.CatchFaceCfg.NYaw = Convert.ToInt32(viewData.Yaw);
            channelCfg.CatchFaceCfg.NPitch = Convert.ToInt32(viewData.Pitch);
            channelCfg.CatchFaceCfg.NYoll = Convert.ToInt32(viewData.Yoll);

            return channelCfg;
        }

    }
}
