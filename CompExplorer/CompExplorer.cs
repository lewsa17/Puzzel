using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassia;

namespace Puzzel.CompExplorer
{
    class CompExplorer
    {
        
        private ITerminalServer GetRemoteComputerInfo(string hostName)
        {
            TerminalServicesManager terminalServicesManager = new TerminalServicesManager();
            return terminalServicesManager.GetRemoteServer(hostName);
        }

        private IEnumerable<ITerminalServicesSession> GetRemoteComputerSession(string hostName)
        {
            var server = GetRemoteComputerInfo(hostName);
            server.Open();
            var sessions = server.GetSessions();

            var sesion = from x in sessions
                         where x.UserName != ""
                         select x;
            return sesion;
        }

       public IEnumerable<ITerminalServicesSession> ActiveUserInfo(string hostName)
       {
            return GetRemoteComputerSession(hostName);
       }
    }
}
