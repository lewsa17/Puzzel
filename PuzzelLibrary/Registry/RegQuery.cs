using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PuzzelLibrary.Registry
{
    class RegQuery : RegOpen
    {
        public void QueryKey(string HostName, RegistryHive mainCatalog, string subKey, string valueName, string value, RegistryValueKind valueKind)
        {
            try
            {
                RegOpenRemoteSubKey(HostName, mainCatalog, subKey).SetValue(valueName, value, valueKind);
            }
            catch (Exception e)
            {
                LogsCollector.Loger(e, value);
            }
            finally
            {
                if (valueName == "AllowRemoteRPC") { Form1.UpdateRichTextBox("Zezwalaj na zdalne Zdalne RPC - włączone"+Environment.NewLine); }
                else
                {
                    var names = RegOpenRemoteSubKey(HostName, mainCatalog, subKey).GetValueNames();
                    if (names.Contains(valueName))
                    {
                        System.Windows.Forms.MessageBox.Show("Zadanie ukończone pomyślnie");
                    }
                }
            }

        }
    }
}
