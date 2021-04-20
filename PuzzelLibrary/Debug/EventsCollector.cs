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
        public string QueryActiveLog(string logName, string queryString, DateTime? time)
        {
            StringBuilder sb = new StringBuilder();
            var eventsQuery = new EventLogQuery(logName, PathType.LogName, queryString) { ReverseDirection = true, TolerateQueryErrors = true };
            var eventinformation = eventsQuery.Session.GetLogInformation("Security", PathType.LogName);
            var eventCount = eventinformation.OldestRecordNumber;
            using (var logReader = new EventLogReader(eventsQuery))
            {
                long? i = 0;
                long? max = eventinformation.RecordCount + eventCount;
                while (max >= eventCount)
                {
                    var record1 = logReader.ReadEvent();
                    if (record1 == null) break;
                    if (record1.TimeCreated >= time)
                    {
                        i = record1.RecordId;
                        if (i <= max && i >= eventCount)
                        {
                            var record = record1.Properties;
                            sb.Append("-------------------\n");
                            sb.Append(record1.TimeCreated.Value.ToString("o"));
                            foreach (var rec in record)
                            {
                                sb.Append("name: " + rec.Value.ToString() + "\t");
                            }
                            sb.Append("-------------------\n");
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public void QueryExternalFile(string queryString, string eventLogLocation)
        {
            var eventsQuery = new EventLogQuery(eventLogLocation, PathType.FilePath, queryString);

            try
            {
                var logReader = new EventLogReader(eventsQuery);
                DisplayEventAndLogInformation(logReader);
            }
            catch (EventLogNotFoundException e)
            {
                Debug.LogsCollector.GetLogs(e, eventLogLocation);
            }
        }



        public void QueryRemoteComputer(string computerName, string domain, string userName, string queryString)
        {
            System.Security.SecureString pw = GetPassword();

            EventLogSession session = new EventLogSession("RemoteComputerName");

            EventLogQuery query = new EventLogQuery("Application", PathType.LogName, queryString);
            query.Session = session;

            try
            {

                var logReader = new EventLogReader(query);
                DisplayEventAndLogInformation(logReader);
            }

            catch (EventLogNotFoundException e)
            {
                Debug.LogsCollector.GetLogs(e, computerName + "," + domain + "," + userName);
            }
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
        private void DisplayEventAndLogInformation(EventLogReader logReader)
        {

            EventRecord eventInstance = logReader.ReadEvent();
            while (eventInstance != null)
            {

                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Event ID: {0}", eventInstance.Id);
                Console.WriteLine("Publisher: {0}", eventInstance.ProviderName);

                try
                {
                    Console.WriteLine("Description: {0}", eventInstance.FormatDescription());
                }
                catch (EventLogException e)
                {

                    Debug.LogsCollector.GetLogs(e, logReader.ToString());
                }

                eventInstance = logReader.ReadEvent();

                EventLogRecord logRecord = ((EventLogRecord)eventInstance);
                Console.WriteLine("Container Event Log: {0}", logRecord.ContainerLog);
            }

        }
    }
}