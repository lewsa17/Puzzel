using System;
using System.Text;
using System.Net.NetworkInformation;

namespace Puzzel
{
    public static class Ping
    {
        public static void Pinging(string hostname)
        {
            try
            {
                PingReply reply = new System.Net.NetworkInformation.Ping().Send(hostname, 120, Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"), new PingOptions(64, true));

                if (reply.Status == IPStatus.Success)
                {
                    Puzzel.Form1.PingStatus = 0;
                }
                else
                {
                    Puzzel.Form1.PingStatus = 1;
                }
            }

            catch (Exception)
            {
                Puzzel.Form1.PingStatus = 1;
                //if (ex is SocketException || ex is PingException)
                //ReplaceRichTextBox("niewidoczny na sieci lub inny błąd");
            }
        }
    }
}
