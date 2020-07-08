using System;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ComponentModel;

namespace PuzzelLibrary.Ping
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
                //Form1.ReplaceRichTextBox("");
                //Form1.UpdateRichTextBox("Wystąpił błąd podczas wykonywania żądania Ping\n" + socex.Message + ": " + HostName+"\n");
            }
            catch (Exception e)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(e, HostName);
            }
            return iPStatus;
        }

        public enum TCPPingStatus : int
        {
            Unknown = 3,
            HostUnknown = 2,
            UnAvailableRPC = 1,
            Success = 0
        }
        
        public static TCPPingStatus TCPPing(string HostName, int Port)
        {
            TCPPingStatus status = TCPPingStatus.Success;
            try
            {
                using (TcpClient tcpClient = new TcpClient(HostName, Port))
                {
                    tcpClient.ReceiveTimeout = 1000;
                }
            }
            catch (SocketException)
            {
                status = TCPPingStatus.HostUnknown;
            }
            catch (Win32Exception)
            {
                status = TCPPingStatus.UnAvailableRPC;
            }
            catch (Exception)
            {
                status = TCPPingStatus.Unknown;
            }
            return status;
        }
    }
}
