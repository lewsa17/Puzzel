using System;
using System.Text;
using System.Net.NetworkInformation;

namespace Puzzel
{
    public static class Ping
    {
        public static IPStatus Pinging(string hostname)
        { IPStatus iPStatus = IPStatus.Unknown;
            try
            {
                PingReply reply = new System.Net.NetworkInformation.Ping().Send(hostname, 120, Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"), new PingOptions(64, true));
                iPStatus = reply.Status;
            }
            catch (Exception e)
            {
                Form1.Loger(e, hostname);
            }
            return iPStatus;
        }
    }
}
