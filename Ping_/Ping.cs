using System;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Puzzel
{
    public static class Ping
    {
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
            catch (System.Net.Sockets.SocketException socex)
            {
                Form1.UpdateRichTextBox("Wystąpił błąd podczas wykonywania żądania Ping\n" + socex.Message + ": " + HostName+"\n");
            }
            catch (Exception e)
            {
                LogsCollector.Loger(e, HostName);
            }
            return iPStatus;
        }

        public enum TCPPingStatus
        {
            Unknown,
            Success,
            HostUnknown
        }
        
        public static TCPPingStatus TCPPing(string HostName, int Port)
        {
            TCPPingStatus status = TCPPingStatus.Success;
            try
            {
                TcpClient tcpClient = new TcpClient(HostName, Port);
            }
            catch (SocketException)
            {
                status = TCPPingStatus.HostUnknown;
            }
            catch(Exception)
            {
                status = TCPPingStatus.Unknown;
            }
            return status;
        }
    }
}
