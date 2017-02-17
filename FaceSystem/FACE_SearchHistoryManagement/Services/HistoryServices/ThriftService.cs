using FACE_SearchHistoryManagement.Models;
using SING.Data.BaseTools;
using SING.Data.Data;
using SING.Data.Logger;
using System;
using System.Collections.Generic;
using System.Windows;
using Thrift.Protocol;
using Thrift.Transport;

namespace FACE_SearchHistoryManagement.Services.HistoryServices
{
    public class ThriftService
    {
        #region 查询历史数据

        //loginIp,loginPort
        readonly string loginIp = AppConfig.Instance.LoginHost;
        readonly int loginPort = Convert.ToInt32(AppConfig.Instance.LoginPort);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="captureRecordQueryValue"></param>
        /// <returns></returns>
        public List<SCountInfo> QueryCapRecordTotalCountH(CaptureRecordQueryValue captureRecordQueryValue)
        {
            TTransport transport = new TSocket(loginIp, loginPort, 5000);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            List<SCountInfo> recordsCount = new List<SCountInfo>();
            try
            {
                #region
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                //得到总数
                recordsCount = _BusinessServerClient.QueryCapRecordTotalCountH(captureRecordQueryValue.ChannelValue, captureRecordQueryValue.StartDayValue, captureRecordQueryValue.EndDayValue);
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("threadQueryCap", ex));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                MessageBox.Show("网络异常，稍后重试！");

                return null;
            }
            return recordsCount;
        }


        /// <summary>
        /// 查询比对记录数(筛选)
        /// </summary>
        /// <param name="captureRecordQueryValue"></param>
        /// <returns></returns>
        public List<SCountInfo> QueryCapRecordTotalCountHSXC(CaptureRecordQueryValue captureRecordQueryValue, List<string> channelName)
        {
            TTransport transport = new TSocket(loginIp, loginPort, 5000);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            List<SCountInfo> recordsCount = new List<SCountInfo>();
            try
            {
                #region
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                //得到总数
                recordsCount = _BusinessServerClient.QueryCapRecordTotalCountHSXC(channelName, captureRecordQueryValue.StartDayValue, captureRecordQueryValue.EndDayValue);
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("threadQueryCap", ex));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                MessageBox.Show("网络异常，稍后重试！");

                return null;
            }
            return recordsCount;
        }



        /// <summary>
        /// 抓拍记录数据
        /// </summary>
        /// <param name="captureRecordQueryValue"></param>
        /// <returns></returns>
        public List<MyCapFaceLogWithImg> QueryCapLog(CaptureRecordQueryValue captureRecordQueryValue, int pageSize)
        {
            List<CapFaceLog> listCapFaceLog = new List<CapFaceLog>();
            List<MyCapFaceLogWithImg> listMyCapFaceLogWithImg = new List<MyCapFaceLogWithImg>();
            //声明客户端内容
            TTransport transport = new TSocket(loginIp, loginPort);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            try
            {
                //获得查询数据 
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                listCapFaceLog = _BusinessServerClient.QueryCapLog(captureRecordQueryValue.ChannelValue, captureRecordQueryValue.StartDayValue, captureRecordQueryValue.EndDayValue, captureRecordQueryValue.StartRowValue, pageSize);


                for (int i = listCapFaceLog.Count - 1; i >= 0; i--)
                {
                    MyCapFaceLogWithImg _MyCapFaceLogWithImg = new MyCapFaceLogWithImg();
                    _MyCapFaceLogWithImg.Id = captureRecordQueryValue.MaxCount - captureRecordQueryValue.StartRowValue - i;
                    _MyCapFaceLogWithImg.ID = listCapFaceLog[i].ID;// 获得抓拍id
                    _MyCapFaceLogWithImg.ChannelID = listCapFaceLog[i].ChannelID;// 获得通道id

                    //获得通道名称 
                    foreach (ChannelCfgData mcc in QueryAllChannel())
                    {
                        if (listCapFaceLog[i].ChannelID == mcc.TcChaneelID)
                        {
                            _MyCapFaceLogWithImg.ChannelName = mcc.Name;
                        }
                    }

                    long longTime = listCapFaceLog[i].Time;
                    DateTime time = new DateTime(1970, 1, 1);
                    time = time.AddSeconds(longTime);
                    _MyCapFaceLogWithImg.Time = time.ToString("yyyy/MM/dd HH:mm:ss"); ;// 获得抓拍时间

                    listMyCapFaceLogWithImg.Add(_MyCapFaceLogWithImg);
                }

                transport.Close();
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("QueryCapLog", ex));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                //MyMessage.showYes("网络异常，稍后重试");
                MessageBox.Show("网络异常，稍后重试");
                return null;
            }
            return listMyCapFaceLogWithImg;
        }


        /// <summary>
        /// 查询抓拍记录(筛选)
        /// </summary>
        /// <param name="captureRecordQueryValue"></param>
        /// <param name="pflag"></param>
        /// <returns></returns>
        public List<MyCapFaceLogWithImg> QueryCapLogSXC(CaptureRecordQueryValue captureRecordQueryValue, List<string> channelList, int pageSize)
        {
            List<CapFaceLog> listCapFaceLog = new List<CapFaceLog>();
            List<MyCapFaceLogWithImg> listMyCapFaceLogWithImg = new List<MyCapFaceLogWithImg>();
            //声明客户端内容
            TTransport transport = new TSocket(loginIp, loginPort);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            try
            {
                //获得查询数据 
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                listCapFaceLog = _BusinessServerClient.QueryCapLogSXC(channelList, captureRecordQueryValue.StartDayValue, captureRecordQueryValue.EndDayValue, captureRecordQueryValue.StartRowValue, pageSize);

                for (int i = listCapFaceLog.Count - 1; i >= 0; i--)
                {
                    MyCapFaceLogWithImg _MyCapFaceLogWithImg = new MyCapFaceLogWithImg();
                    _MyCapFaceLogWithImg.Id = captureRecordQueryValue.MaxCount - captureRecordQueryValue.StartRowValue - i;
                    _MyCapFaceLogWithImg.ID = listCapFaceLog[i].ID;// 获得抓拍id
                    _MyCapFaceLogWithImg.ChannelID = listCapFaceLog[i].ChannelID;// 获得通道id

                    //获得通道名称 
                    foreach (ChannelCfgData mcc in QueryAllChannel())
                    {
                        if (listCapFaceLog[i].ChannelID == mcc.TcChaneelID)
                        {
                            _MyCapFaceLogWithImg.ChannelName = mcc.Name;
                        }
                    }

                    long longTime = listCapFaceLog[i].Time;
                    DateTime time = new DateTime(1970, 1, 1);
                    time = time.AddSeconds(longTime);
                    _MyCapFaceLogWithImg.Time = time.ToString("yyyy/MM/dd HH:mm:ss"); ;// 获得抓拍时间

                    listMyCapFaceLogWithImg.Add(_MyCapFaceLogWithImg);
                }

                transport.Close();
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("QueryCapLog", ex));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                MessageBox.Show("网络异常，稍后重试");
                return null;
            }
            return listMyCapFaceLogWithImg;
        }


        /// <summary>
        /// 获取所有频道
        /// </summary>
        /// <returns></returns>
        List<ChannelCfgData> QueryAllChannel()
        {
            List<ChannelCfgData> myListChannelCfg = new List<ChannelCfgData>();
            List<ChannelCfg> ListChannelCfg = new List<ChannelCfg>();
            TTransport transport = new TSocket(loginIp, loginPort);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            try
            {
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                ListChannelCfg = _BusinessServerClient.QueryAllChannel();
                transport.Close();
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("QueryAllChannel", ex));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                //MyMessage.showYes("网络异常，稍后重试");         
            }
            //todo(暂时不需要) 包装返回类 使其返回需要的类
            foreach (ChannelCfg cc in ListChannelCfg)
            {
                myListChannelCfg.Add(ChannelCfgData.ConvertToData(cc));
            }


            return myListChannelCfg;
        }
        #endregion


        #region 查询图片数据

        public List<byte[]> QueryCapLogImageH(string ID, string day)
        {
            TTransport transport = new TSocket(loginIp, loginPort);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            List<byte[]> listImageBytes = new List<byte[]>();
            try
            {
                #region
                //打开连接
                if (!transport.IsOpen)
                {
                    transport.Open();

                }
                //调用接口获得抓拍照片
                listImageBytes = _BusinessServerClient.QueryCapLogImageH(ID, day);
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("QueryCapLogImage", ex));
                if (transport.IsOpen)
                {
                    transport.Close();
                }

                MessageBox.Show("网络异常，稍后重试！");
                return null;
            }
            return listImageBytes;
        }


        public List<byte[]> QuerySenceImg(string ID, string day)
        {
            TTransport transport = new TSocket(loginIp, loginPort);
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            List<byte[]> listImageBytes = new List<byte[]>();
            try
            {
                #region
                //打开连接
                if (!transport.IsOpen)
                {
                    transport.Open();

                }
                //调用接口获得抓拍照片
                listImageBytes = _BusinessServerClient.QuerySenceImg(ID, day);
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("QuerySenceImg", ex));
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                //MyMessage.showYes("网络异常，稍后重试");
                MessageBox.Show("网络异常，稍后重试！");
                return null;
            }
            return listImageBytes;
        }

        #endregion
    }
}
