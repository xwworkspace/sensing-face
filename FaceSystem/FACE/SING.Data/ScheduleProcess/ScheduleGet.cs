﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.BaseTools;
using SING.Data.Data;
using Thrift.Protocol;
using Thrift.Transport;

namespace SING.Data.ScheduleProcess
{
    public class ScheduleGet
    {
        public static bool Login(string host, string port)
        {
            //生成socket套接字；
            TSocket tsocket = new TSocket(host, int.Parse(port.Trim()));
            //设置连接超时为100；
            tsocket.Timeout = 100;
            //生成客户端对象
            TTransport transport = tsocket;
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            //连接服务器
            try
            {
                #region
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                #endregion
            }
            catch (Exception ex)
            {
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                Logger.Logger.Error("连接服务器错误", ex);
                return false;
            }
            //关闭连接
            transport.Close();
            return true;
        }

        public static string ValidtionUser(string host, string port, string UserName, string PassWord, string wid)
        {
            TSocket tsocket = new TSocket(host, int.Parse(port.Trim()));
            tsocket.Timeout = 5000;
            TTransport transport = tsocket;
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            Data.UserCfgData UserCfgData = new Data.UserCfgData();
            try
            {
                #region
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                UserCfg _UserCfg = _BusinessServerClient.UserLogin(UserName, PassWord, wid);
                if (_UserCfg != null)
                {
                    UserCfgData = UserCfgData.ConvertToData(_UserCfg);

                    return string.Format("UID={0};UTYPE={1};DIVINDEX={2};DIVORDER={3}", UserCfgData.Uid, UserCfgData.Utype, UserCfgData.Div_index, UserCfgData.Div_order);
                }
                transport.Close();

                #endregion
            }
            catch (Exception ex)
            {
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                System.Windows.MessageBox.Show("连接服务器失败");
                Logger.Logger.Error("连接服务器失败", ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static UserCfgData QueryUser(string UserName)
        {
            TSocket tsocket = new TSocket(AppConfig.Instance.LoginHost, AppConfig.Instance.Port);
            tsocket.Timeout = 100;
            TTransport transport = tsocket;
            TProtocol protocol = new TBinaryProtocol(transport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
            Data.UserCfgData _UserCfgData = new Data.UserCfgData();
            try
            {
                #region
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                try
                {
                    UserCfg _UserCfg = _BusinessServerClient.QueryUser(UserName);
                    _UserCfgData = Data.UserCfgData.ConvertToData(_UserCfg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("获取用户信息失败");
                    Logger.Logger.Error("获取用户信息失败", ex);
                }
                transport.Close();
                #endregion
            }
            catch (Exception ex)
            {
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                System.Windows.MessageBox.Show("连接服务器失败");
                Logger.Logger.Error("连接服务器失败", ex);
            }
            return _UserCfgData;
        }
    }
}
