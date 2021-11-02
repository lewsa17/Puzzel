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

        public string GetLocalLog(string logName, string queryString)
        {
            EventLogSession session = new();
            var eventsQuery = CreateQuery(logName, queryString);
            eventsQuery.Session = session;
            try
            {
                var evtReader = new EventLogReader(eventsQuery);

                if (evtReader.LogStatus[0].StatusCode == 5)
                    return "Wykonanie operacji wymaga podniesionych uprawnień";
                else if (evtReader.LogStatus[0].StatusCode == 0)
                    return GetEventAndLogInformation(evtReader);
            }
            catch (Exception e)
            {
                Debug.LogsCollector.GetLogs(e, "");
            }
            return string.Empty;
        }

        public void QueryExternalFile(string logName, string queryString)
        {
            var eventsQuery = new EventLogQuery(logName, PathType.FilePath, queryString);

            try
            {
                var logReader = new EventLogReader(eventsQuery);
                GetEventAndLogInformation(logReader);
            }
            catch (EventLogException e)
            {
                Debug.LogsCollector.GetLogs(e, logName);
            }
        }

        public string GetRemoteLog(string computerName, string logName, string queryString, object control)
        {
            EventLogSession session = new(computerName);

            EventLogQuery query = CreateQuery(logName, queryString);
            query.Session = session;

            try
            {
                var logReader = new EventLogReader(query);
                if (logReader.LogStatus[0].StatusCode == 0)
                {
                    if (computerName.Contains("motp", StringComparison.OrdinalIgnoreCase))
                        if (control is System.Windows.Forms.DataGridView)
                            DisplayEventAndLogInformation(logReader, (System.Windows.Forms.DataGridView)control);
                        else
                            return GetEventAndLogInformation(logReader);
                    else return DisplayEventSecurityLog(logReader);
                }
                else if (logReader.LogStatus[0].StatusCode == 5)
                    return "Wykonanie operacji wymaga podniesionych uprawnień";
            }

            catch (EventLogException e)
            {
                return string.Concat("Server:", computerName, " - ", e.Message);
            }
            catch (Exception e)
            {
                Debug.LogsCollector.GetLogs(e, computerName);
            }
            return string.Empty;
        }

        private string DisplayEventSecurityLog(EventLogReader logReader)
        {
            StringBuilder sb = new();
            int i = 0;
            logReader.BatchSize = 100;
            while (i < MaxCount)
            {
                try
                {
                   EventRecord eventInstance = logReader.ReadEvent();
                    if (eventInstance == null)
                        break;

                    EventParser ep = new(eventInstance);
                    sb.Append("-----------------------------------------------------\n");
                    sb.Append(string.Format("{0}\n\n", ep.Descriptions.Title));
                    sb.Append(string.Format("Event ID: {0}\t\t\t Record: {1}\n", ep.ID, eventInstance.RecordId));
                    sb.Append(string.Format("TimeCreated:\t\t\t {0}\n", ep.TimeCreated));
                    sb.Append(string.Format("Nazwa użytkownika:\t\t {0}\n", ep.Descriptions.TargetUserName));
                    if (!string.IsNullOrEmpty(ep.Descriptions.TargetUserSid))
                        sb.Append(string.Format("Identyfikator zabepieczeń:\t\t {0}\n", ep.Descriptions.TargetUserSid));
                    if (!string.IsNullOrEmpty(ep.Descriptions.TargetDomainName))
                        sb.Append(string.Format("Nazwa:\t\t\t\t {0}\n", ep.Descriptions.TargetDomainName));
                    if (!string.IsNullOrEmpty(ep.Descriptions.IpAddress))
                        sb.Append(string.Format("IP adres\t\t\t\t {0}\n", ep.Descriptions.IpAddress));
                    if (!string.IsNullOrEmpty(ep.Descriptions.NewPID))
                        sb.Append(string.Format("Identyfikator nowego procesu: \t {0}\n", ep.Descriptions.NewPID));
                    if (!string.IsNullOrEmpty(ep.Descriptions.NewProcessName))
                        sb.Append(string.Format("Nazwa nowego procesu: \t\t {0}\n", ep.Descriptions.NewProcessName));
                    if (!string.IsNullOrEmpty(ep.Descriptions.PID))
                        sb.Append(string.Format("Identyfikator procesu twórcy: \t {0}\n", ep.Descriptions.PID));
                    if (!string.IsNullOrEmpty(ep.Descriptions.ParentProcessName))
                        sb.Append(string.Format("Nazwa procesu twórcy: \t\t {0}\n", ep.Descriptions.ParentProcessName));
                    if (!string.IsNullOrEmpty(ep.Descriptions.CommandLine))
                        sb.Append(string.Format("Wiersz polecenia procesu: \t\t {0}\n", ep.Descriptions.CommandLine));
                    i++;
                }
                catch (EventLogException e)
                {
                    Debug.LogsCollector.GetLogs(e, logReader.ToString());
                }
            }
            if (sb.Length == 0) { sb.Append("Brak logów"); }
            return sb.ToString();
        }

        private string GetEventAndLogInformation(EventLogReader logReader)
        {
            StringBuilder sb = new();
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
        private void DisplayEventAndLogInformation(EventLogReader logReader, System.Windows.Forms.DataGridView dv)
        {
            int i = 0;
            dv.Columns.Clear();
            dv.Columns.AddRange(new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "TimeCreated", HeaderText = "TimeCreated", AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells},
                                new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "EventId", HeaderText = "EventId", AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells },
                                new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "ProviderName", HeaderText = "ProviderName", AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells },
                                new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "Description", HeaderText = "Description", AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill });
            while (i++ < MaxCount)
            {
                try
                {
                    EventRecord eventInstance = logReader.ReadEvent();
                    if (eventInstance == null) break;
                    dv.Rows.Add(eventInstance.TimeCreated, eventInstance.Id, eventInstance.ProviderName, eventInstance.FormatDescription());
                }
                catch (EventLogException e)
                {
                    Debug.LogsCollector.GetLogs(e, logReader.ToString());
                }
            }
            if (dv.Rows.Count == 0) { dv.Rows.Clear(); 
                dv.Rows.Add("Brak logów"); }
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
                public string NewPID { get => _newPID; }
                public string NewProcessName { get => _newProcessName; }
                public string PID { get => _PID; }
                public string CommandLine { get => _CommandLine; }
                public string ParentProcessName { get => _ParentProcessName; }

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
                    if (eventRecord.Id == 4688)
                    {
                        this._Title = "Utworzono nowy proces.";
                        this._newPID = eventRecord.Properties[4].Value.ToString();
                        this._newProcessName = eventRecord.Properties[5].Value.ToString();
                        this._PID = eventRecord.Properties[7].Value.ToString();
                        this._CommandLine = eventRecord.Properties[8].Value.ToString();
                        this._TargetUserSid = eventRecord.Properties[9].Value.ToString();
                        this._TargetUserName = eventRecord.Properties[10].Value.ToString();
                        this._TargetDomainName = eventRecord.Properties[11].Value.ToString();
                        this._ParentProcessName = eventRecord.Properties[13].Value.ToString();
                    }
                    if (eventRecord.Id == 4776)
                    {
                        this._Title = "Komputer próbował zweryfikować poświadczenia dla konta.";
                        this._TargetUserName = eventRecord.Properties[1].Value.ToString();
                        this._Workstation = eventRecord.Properties[2].Value.ToString();
                    }
                    if (eventRecord.Id == 4771)
                    {
                        this._Title = "Wstępne logowanie protokołem Kerberos nie udane.";
                        this._TargetUserSid = eventRecord.Properties[1].Value.ToString();
                        this._TargetUserName = eventRecord.Properties[0].Value.ToString();
                        this._IpAddress = eventRecord.Properties[6].Value.ToString();
                    }
                    if (eventRecord.Id == 4740)
                    {
                        this._Title = "Konto użytkownika zostało zablokowane.";
                        this._TargetUserSid = eventRecord.Properties[2].Value.ToString();
                        this._TargetUserName = eventRecord.Properties[0].Value.ToString();
                        this._TargetDomainName = eventRecord.Properties[1].Value.ToString();
                    }
                }
                private string _TargetUserSid;
                private string _TargetUserName;
                private string _TargetDomainName;
                private string _Workstation;
                private string _IpAddress;
                private string _Title;
                private string _newPID;
                private string _newProcessName;
                private string _PID;
                private string _CommandLine;
                private string _ParentProcessName;
            }
        }
    }
}