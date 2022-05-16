using System;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace PuzzelLibrary.NetDiag
{
    public static class Ping
    {
        public static string Result;
        public static IPStatus Pinging(string HostName)
        {
            IPStatus iPStatus = IPStatus.Unknown;
            try
            {
                if (System.Net.Dns.GetHostAddresses(HostName) != null)
                {
                    PingReply reply = new System.Net.NetworkInformation.Ping().Send(HostName, 120, Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"), new PingOptions(64, true));
                    iPStatus = reply.Status;
                }
            }
            catch (SocketException SockEx)
            {
                Result = SockEx.Message;
            }
            catch (Exception e)
            {
                Debug.LogsCollector.GetLogs(e, HostName);
            }
            return iPStatus;
        }
    }
}
