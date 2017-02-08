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
    public class ScheduleUpdate
    {
        /// <summary>
        /// 设置新的域值
        /// </summary>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static int SetCMPthreshold(int threshold)
        {
            TTransport transport = new TSocket(AppConfig.Instance.LoginHost, AppConfig.Instance.Port);
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
                nSucess = _BusinessServerClient.SetCMPthreshold(threshold);
                transport.Close();
                #endregion
            }
            catch (Exception ex)
            {
                if (transport.IsOpen)
                {
                    transport.Close();
                }
                System.Windows.MessageBox.Show("设置域值失败，稍后重试！");
                Logger.Logger.Error("修改阈值方法异常：SetCMPthreshold", ex);
                return nSucess;
            }
            return nSucess;
        }
    }
}
