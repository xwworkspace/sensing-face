using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace SING.Data
{
    public class TClient
    {
        public static readonly TClient Instance;

        private static TTransport TranSport;
        private static readonly object lockObj = new object();
        public TClient()
        {
        }
        static TClient()
        {
            if (Instance == null)
            {
                lock (lockObj)
                {
                    if (Instance == null)
                        Instance = new TClient();
                }
            }
        }

        public BusinessServer.Client OpenClient(string host, int port)
        {
            TranSport = new TSocket(host, port);
            TProtocol Protocol = new TBinaryProtocol(TranSport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(Protocol);
            if (!TranSport.IsOpen) TranSport.Open();
            return _BusinessServerClient;
        }

        public BusinessServer.Client OpenClient(string host, int port, int timeout)
        {
            TSocket tsocket = new TSocket(host, port);
            tsocket.Timeout = timeout;
            TranSport = tsocket;
            TProtocol Protocol = new TBinaryProtocol(TranSport);
            BusinessServer.Client _BusinessServerClient = new BusinessServer.Client(Protocol);
            if (!TranSport.IsOpen) TranSport.Open();
            return _BusinessServerClient;
        }

        public void Close()
        {
            if (TranSport.IsOpen)
            {
                TranSport.Close();
            }
        }
    }
}
