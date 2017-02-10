using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.BaseTools;
using Thrift.Protocol;
using Thrift.Transport;

namespace SING.Data.ScheduleProcess
{
    public class ScheduleHeartBeat
    {
        public static int HearBeat()
        {
            TSocket tsocket = new TSocket(AppConfig.Instance.LoginHost, AppConfig.Instance.Port);
            //4.设置连接超时为100；
            tsocket.Timeout = 100;
            //5.生成客户端对象
            TTransport transport = tsocket;
            TProtocol protocol = new TBinaryProtocol(transport);
          
            int nSuccess = -1;
            try
            {
                if (!transport.IsOpen)
                {
                    transport.Open();
                }
                if (string.IsNullOrEmpty(AppConfig.Instance.UserInfo.UserInfo.Div_index) ||
                    string.IsNullOrEmpty(AppConfig.Instance.UserInfo.UserInfo.Uid))
                {
                    BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(protocol);
                    nSuccess = _BusinessServerClient.HearBeat();
                }
                else
                {
                    BusinessServerNet.Client _BusinessServerClient = new BusinessServerNet.Client(protocol);
                    nSuccess = _BusinessServerClient.HearBeat(AppConfig.Instance.UserInfo.UserInfo.Div_index, AppConfig.Instance.UserInfo.UserInfo.Uid);
                }

                transport.Close();
            }
            catch (Exception ex)
            {
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                System.Windows.MessageBox.Show("心跳失败，稍后重试！");
                Logger.Logger.Error("心跳连接服务器异常", ex);
                return nSuccess;
            }
            return nSuccess;
        }
    }
}
