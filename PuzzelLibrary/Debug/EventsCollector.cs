using System;
using System.Text;
using System.Diagnostics.Eventing.Reader;

namespace PuzzelLibrary.Debug
{
    public class EventsCollector
    {
        public EventsCollector()
        {
        }
        private int _maxCount;
        public int MaxCount
        {
            get => _maxCount;
            set
            {
                if (value > 100)
                    _maxCount = 100;
                else _maxCount = value;
            }
        }
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

        public string GetRemoteLog(string computerName, string logName, string queryString)
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

        public string GetSecurityControllerLog(string computerName, string logName, string queryString)
        {
            EventLogSession session = new EventLogSession(computerName);

            EventLogQuery query = CreateQuery(logName, queryString);
            query.Session = session;

            try
            {
                var logReader = new EventLogReader(query);
                return DisplayEventSecurityLog(logReader);
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

        private string DisplayEventSecurityLog(EventLogReader logReader)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i++ < MaxCount)
            {
                try
                {
                    EventRecord eventInstance = logReader.ReadEvent();
                    if (eventInstance == null)
                        break;

                    EventParser ep = new EventParser(eventInstance);
                    sb.Append("-----------------------------------------------------\n");
                    sb.Append(string.Format("{0}\n\n", ep.Descriptions.Title));
                    sb.Append(string.Format("Event ID: {0}\t\t Record: {1}\n", ep.ID, eventInstance.RecordId));
                    sb.Append(string.Format("TimeCreated:\t\t {0}\n", ep.TimeCreated));
                    sb.Append(string.Format("Nazwa użytkownika:\t {0}\n", ep.Descriptions.TargetUserName));
                    sb.Append(string.Format("Identyfikator zabepieczeń:\t {0}\n", ep.Descriptions.TargetUserSid));
                    sb.Append(string.Format("Nazwa:\t\t\t {0}\n", ep.Descriptions.TargetDomainName));
                    sb.Append(string.Format("IP adres\t\t\t {0}\n", ep.Descriptions.IpAddress));
                    sb.Append(string.Format("Nazwa komputera \t {0}\n", ep.Descriptions.Workstation));
                }
                catch (EventLogException e)
                {
                    Debug.LogsCollector.GetLogs(e, logReader.ToString());
                }
            }
            if (sb.Length == 0) { sb.Append("Brak logów"); }
            return sb.ToString();
        }

        private string DisplayEventAndLogInformation(EventLogReader logReader)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i++ < MaxCount)
            {
                try
                {
                    EventRecord eventInstance = logReader.ReadEvent();
                    if (eventInstance == null) break;

                    sb.Append("-----------------------------------------------------\n");
                    sb.Append(string.Format("TimeCreated: {0}\n", eventInstance.TimeCreated));
                    sb.Append(string.Format("Event ID: {0}\n", eventInstance.Id));
                    sb.Append(string.Format("Publisher: {0}\n", eventInstance.ProviderName));
                    sb.Append(string.Format("Description: {0}\n", eventInstance.FormatDescription()));
                }
                catch (EventLogException e)
                {
                    Debug.LogsCollector.GetLogs(e, logReader.ToString());
                }
            }
            if (sb.Length == 0) { sb.Append("Brak logów"); }
            return sb.ToString();
        }

        public class EventParser
        {
            private int _ID;
            private DateTime? _TimeCreated;

            public int ID { get => _ID; }
            public DateTime? TimeCreated { get => _TimeCreated; }

            public EventDescriptions Descriptions;
            public EventParser(EventRecord eventRecord)
            {
                _ID = eventRecord.Id;
                _TimeCreated = eventRecord.TimeCreated;
                Descriptions = new EventDescriptions(eventRecord);
            }

            public class EventDescriptions
            {
                public string IpAddress { get => _IpAddress; }
                public string TargetDomainName { get => _TargetDomainName; }
                public string TargetUserName { get => _TargetUserName; }
                public string TargetUserSid { get => _TargetUserSid; }
                public string Title { get => _Title; }
                public string Workstation { get => _Workstation; }

                public EventDescriptions(EventRecord eventRecord)
                {
                    if (eventRecord.Id == 4624)
                    {
                        this._Title = "Konto zostało zalogowane poprawnie.";
                        this._TargetUserSid = eventRecord.Properties[4].Value.ToString();
                        this._TargetUserName = eventRecord.Properties[5].Value.ToString();
                        this._TargetDomainName = eventRecord.Properties[6].Value.ToString();
                        this._Workstation = eventRecord.Properties[11].Value.ToString();
                        this._IpAddress = eventRecord.Properties[18].Value.ToString();
                    }

                    if (eventRecord.Id == 4776)
                    {
                        this._Title = "Komputer próbował zweryfikować poświadczenia dla konta.";
                        this._TargetUserSid = string.Empty;
                        this._TargetUserName = eventRecord.Properties[1].Value.ToString();
                        this._TargetDomainName = string.Empty;
                        this._Workstation = eventRecord.Properties[2].Value.ToString();
                        this._IpAddress = string.Empty;
                    }
                    if (eventRecord.Id == 4771)
                    {
                        this._Title = "Wstępne logowanie protokołem Kerberos nie udane.";
                        this._TargetUserSid = eventRecord.Properties[1].Value.ToString();
                        this._TargetUserName = eventRecord.Properties[0].Value.ToString();
                        this._TargetDomainName = string.Empty;
                        this._Workstation = string.Empty;
                        this._IpAddress = eventRecord.Properties[6].ToString();
                    }
                    if (eventRecord.Id == 4740)
                    {
                        this._Title = "Konto użytkownika zostało zablokowane.";
                        this._TargetUserSid = eventRecord.Properties[2].Value.ToString();
                        this._TargetUserName = eventRecord.Properties[0].Value.ToString();
                        this._TargetDomainName = eventRecord.Properties[1].Value.ToString();
                        this._Workstation = string.Empty;
                        this._IpAddress = string.Empty;
                    }
                }
                private string _TargetUserSid;
                private string _TargetUserName;
                private string _TargetDomainName;
                private string _Workstation;
                private string _IpAddress;
                private string _Title;
            }
        }
    }
}