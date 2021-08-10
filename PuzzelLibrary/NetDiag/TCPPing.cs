using System;
using System.Net.Sockets;
using System.ComponentModel;

namespace PuzzelLibrary.NetDiag
{
    public class TCPPing
    {
        public enum Status : int
        {
            Success = 0,
            UnAvailableRPC = 1,
            HostUnknown = 2,
            Unknown = 3
        }
        public string Result;
        public Status TestConnection(string HostName, int Port)
        {
            Status status = Status.Success;
            try
            {
                using (TcpClient tcpClient = new TcpClient(HostName, Port) { SendTimeout = 1000, ReceiveTimeout = 1000 })
                { tcpClient.Close(); }

            }
            catch (SocketException ex)
            {
                status = Status.HostUnknown;
                Result = ex.Message;
            }
            catch (Win32Exception ex)
            {
                status = Status.UnAvailableRPC;
                Result = ex.Message;
            }
            catch (Exception ex)
            {
                status = Status.Unknown;
                Result = ex.Message;
            }
            return status;
        }
    }
}
