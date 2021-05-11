﻿using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Forms.External
{
    public partial class EventLogCollector : Form
    {
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        private string _titleName;
        public string TitleName
        {
            get => _titleName;
            set => _titleName = value;
        }

        public string[] MotpSevers { get; set; }

        public EventLogCollector(string TitleName)
        {
            InitializeComponent();
            InitializeTip();
            this.TitleName = LocationText.Text = TitleName;
        }

        public EventLogCollector(string TitleName, string UserName)
        {
            InitializeComponent();
            InitializeTip();
            LocationText.Enabled = false;
            this.TitleName = LocationText.Text = TitleName;
            this.UserName = UserName;
            GetLastBadPasswordAttempt();
        }

        public EventLogCollector(string[] motpServers)
        {
            MotpSevers = motpServers;
            InitializeComponent();
            InitializeTip();
            LocationText.DropDownStyle = ComboBoxStyle.DropDownList;
            LocationText.Items.AddRange(motpServers);
            if (LocationText.Items.Count > 0)
                LocationText.SelectedIndex = 0;
        }

        private string DomainController { get; set; }
        private void GetLastBadPasswordAttempt()
        {
            string[] DomainControllers = null;
            Task.Run(() => DomainControllers = PuzzelLibrary.AD.Other.Domain.GetCurrentDomainControllers()).ContinueWith(nextTask => {
                DateTime lastBadPwd = DateTime.MinValue;
                var pd = new PuzzelLibrary.AD.User.Information.PasswordDetails();
                foreach (var domainController in DomainControllers)
                {
                    Task.Run(() =>
                    {
                        pd.GetUserPasswordDetails(UserName, domainController);
                        if (lastBadPwd < pd.lastBadPasswordAttempt)
                        {
                            lastBadPwd = pd.lastBadPasswordAttempt;
                            DomainController = domainController;
                            StartDateRangePicker.Invoke(new MethodInvoker(() =>
                            {
                                StartDateRangePicker.Value = pd.lastBadPasswordAttempt;
                            }));
                            EndDateRangePicker.Invoke(new MethodInvoker(() =>
                            {
                                EndDateRangePicker.Value = pd.lastBadPasswordAttempt.AddSeconds(+1);
                            }));
                        }
                    });
                }
            });
        }

        private void FindButton_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PuzzelLibrary.Debug.EventsCollector ec = new PuzzelLibrary.Debug.EventsCollector() { MaxCount = (int)LogCounter.Value };
            string dateFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
            var query = string.Format("*[System/TimeCreated/@SystemTime >= '{0}'] and *[System/TimeCreated/@SystemTime <= '{1}']",
                StartDateRangePicker.Value.ToUniversalTime().ToString(dateFormat), EndDateRangePicker.Value.ToString(dateFormat));
            var MotpQuery = string.Format("*[System/TimeCreated/@SystemTime >= '{0}'] and *[System/TimeCreated/@SystemTime <= '{1}']",
                StartDateRangePicker.Value.ToUniversalTime().ToString(dateFormat), EndDateRangePicker.Value.ToUniversalTime().ToString(dateFormat));
            var queryController = string.Format(
                "<QueryList>" +
                "  <Query Id='0' Path='Security'>" +
                "    <Select Path='Security'>*[System[(EventID=4624 or EventID=4740 or EventID=4771 or EventID=4776) and TimeCreated[@SystemTime&gt;='{0}' and @SystemTime&lt;='{1}']]]</Select>" +
                "  </Query>" +
                "</QueryList>"
                , StartDateRangePicker.Value.ToUniversalTime().ToString(dateFormat), EndDateRangePicker.Value.ToUniversalTime().ToString(dateFormat));

            //Wyszukiwanie w lokalu / brak danych w polu
            if (string.IsNullOrEmpty(LocationText.Text))
                TextLogView.Text = ec.GetLocalLog("Security", query);

            //Wyszukiwanie w na kontrolerze domeny / zablokowane pole
            if (!LocationText.Enabled)
            {
                if (PuzzelLibrary.NetDiag.Ping.TCPPing(DomainController, 135) == PuzzelLibrary.NetDiag.Ping.TCPPingStatus.Success)
                    TextLogView.Text = ec.GetSecurityLog(DomainController, "Security", queryController);
                else TextLogView.Text = "Brak połączenia z kontrolerem domeny, serwer RPC jest niedostępny";
            }
            else if (PuzzelLibrary.NetDiag.Ping.TCPPing(LocationText.Text, 135) == PuzzelLibrary.NetDiag.Ping.TCPPingStatus.Success)
            {
                //Wyszukiwanie na serwerzer motp
                if (LocationText.Text.Contains("motp", StringComparison.OrdinalIgnoreCase))
                    TextLogView.Text = ec.GetRemoteLog(LocationText.Text, PuzzelLibrary.Settings.Values.MotpLogName, MotpQuery);

                //Wyszukiwanie na komputerze o nazwie podanej w polu
                else if (!string.IsNullOrEmpty(LocationText.Text))
                {
                    TextLogView.Text = ec.GetSecurityLog(LocationText.Text, "Security", query);
                }
            }
            else TextLogView.Text = string.Format("Brak połączenia z {0}, serwer RPC jest niedostępny", LocationText.Text);
            this.Cursor = Cursors.Default;
        }
        private void InitializeTip()
        {
            ToolTip tp = new ToolTip();
            string LabelCounterText = "Nie polecam ustawiania wysokich liczb, może to skutkować zawieszeniem maszyny odpytywanej\n" +
                                      "Kontroler domeny jest w stanie wygenerować nawet kilkadziesiąt wpisów na sekundę.";
            tp.SetToolTip(LogCounter, LabelCounterText);
            tp.SetToolTip(LogCounterLabel, LabelCounterText);
        }
        private void SearchData(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                Additional.SearchingMainForm wyszukiwarka = new Additional.SearchingMainForm(TextLogView);
                wyszukiwarka.Show();
            }
        }
        private void ChangedValue(object sender, EventArgs e)
        {
            if (LocationText.Text.Contains("Domain"))
            {
                if (sender == EndDateRangePicker)
                    StartDateRangePicker.Value = EndDateRangePicker.Value.AddSeconds(-1);
                if (sender == StartDateRangePicker)
                    EndDateRangePicker.Value = StartDateRangePicker.Value.AddSeconds(+1);
            }
        }
    }
}
