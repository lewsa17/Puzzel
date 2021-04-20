using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.PowerShell;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;

namespace PuzzelLibrary.Debug
{
    public class EventsCollector
    {
        private EventLogQuery CreateQuery(string logName, string queryString)
        {
            return new EventLogQuery(logName, PathType.LogName, queryString)
            {
                ReverseDirection = true,
                TolerateQueryErrors = true
            };
        }

        private EventLogInformation GetLogInformation(EventLogQuery eventLogQuery)
        {
            return eventLogQuery.Session.GetLogInformation("Security", PathType.LogName);
        }


        public string GetLocalLog(string logName, string queryString)
        {
            var eventsQuery = CreateQuery(logName, queryString);
            var evtInfo = GetLogInformation(eventsQuery);
            return DisplayEventAndLogInformation(new EventLogReader(eventsQuery));
        }

        public void QueryExternalFile(string logName, string queryString)
        {
            var eventsQuery = new EventLogQuery(logName, PathType.FilePath, queryString);

            try
            {
                var logReader = new EventLogReader(eventsQuery);
                DisplayEventAndLogInformation(logReader);
            }
            catch (EventLogNotFoundException e)
            {
                Debug.LogsCollector.GetLogs(e, logName);
            }
        }

        public string QueryRemoteComputer(string computerName, string logName, string queryString)
        {
            EventLogSession session = new EventLogSession(computerName);

            EventLogQuery query = CreateQuery(logName, queryString);
            query.Session = session;

            try
            {
                var logReader = new EventLogReader(query);
                return DisplayEventAndLogInformation(logReader);
            }

            catch (EventLogNotFoundException e)
            {
                Debug.LogsCollector.GetLogs(e, computerName);
            }
            return string.Empty;
        }

        public System.Security.SecureString GetPassword()
        {
            var password = new System.Security.SecureString();
            Console.WriteLine("Enter password: ");
            var nextKey = Console.ReadKey(true);

            while (nextKey.Key is ConsoleKey.Enter)

                if (nextKey.Key is ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {

                        password.RemoveAt(password.Length - 1);
                        Console.Write(nextKey.KeyChar);
                        Console.Write(" ");
                        Console.Write(nextKey.KeyChar);
                    }

                    else
                    {
                        password.AppendChar(nextKey.KeyChar);
                        Console.Write("*");
                    }
                }
            nextKey = Console.ReadKey(true);
            Console.WriteLine();

            password.MakeReadOnly();
            return password;
        }
        private string DisplayEventAndLogInformation(EventLogReader logReader)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                EventRecord eventInstance = logReader.ReadEvent();
                if (eventInstance == null) break;

                sb.Append("-----------------------------------------------------\n");
                sb.Append(string.Format("Event ID: {0}\n", eventInstance.Id));
                sb.Append(string.Format("Publisher: {0}\n", eventInstance.ProviderName));

                try
                {
                    sb.Append(string.Format("Description: {0}\n", eventInstance.FormatDescription()));
                }
                catch (EventLogException e)
                {

                    Debug.LogsCollector.GetLogs(e, logReader.ToString());
                }

                EventLogRecord logRecord = ((EventLogRecord)eventInstance);
                sb.Append(string.Format("Container Event Log: {0}\n", logRecord.ContainerLog));
            }
            return sb.ToString();
        }
    }
}