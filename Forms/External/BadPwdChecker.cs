using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Forms.External
{
    public partial class BadPwdChecker : Form
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
        public BadPwdChecker(string TitleName)
        {
            this.TitleName = TitleName;
            InitializeComponent();
            InitializeTip();
            LocationText.Text = TitleName;
        }
        public BadPwdChecker(string TitleName, string UserName)
        {
            this.TitleName = TitleName;
            this.UserName = UserName;
            InitializeComponent();
            InitializeTip();
            LocationText.ReadOnly = true;
            LocationText.Text = TitleName;
            GetLastBadPasswordAttempt();
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
                                StartDateRangePicker.Value = pd.lastBadPasswordAttempt.AddSeconds(-1);
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
            PuzzelLibrary.Debug.EventsCollector ec = new PuzzelLibrary.Debug.EventsCollector() { MaxCount = (int)LogCounter.Value };
            string dateFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
            var query = string.Format("*[System/TimeCreated/@SystemTime >= '{0}'] and *[System/TimeCreated/@SystemTime <= '{1}']",
                StartDateRangePicker.Value.ToUniversalTime().ToString(dateFormat), EndDateRangePicker.Value.ToString(dateFormat));
            var queryDomain = string.Format("*[System/TimeCreated/@SystemTime >= '{0}'] and *[System/TimeCreated/@SystemTime <= '{1}']",
                StartDateRangePicker.Value.ToUniversalTime().ToString(dateFormat), EndDateRangePicker.Value.ToUniversalTime().ToString(dateFormat));

            //Wyszukiwanie w lokalu / brak danych w polu
            if (string.IsNullOrEmpty(LocationText.Text))
                TextLogView.Text = ec.GetLocalLog("Security", query);

            //Wyszukiwanie w na kontrolerze domeny / zablokowane pole
            if (LocationText.ReadOnly)
            {
                ec.GetRemoteLog(DomainController, "Security", queryDomain);
            }

            //Wyszukiwanie na komputerze o nazwie podanej w polu
            if (!string.IsNullOrEmpty(LocationText.Text))
            {
                TextLogView.Text = ec.GetRemoteLog(LocationText.Text, "Security", query);
            }
        }
        private void InitializeTip()
        {
            ToolTip tp = new ToolTip();
            string LabelCounterText = "Nie polecam ustawiania wysokich liczb, może to skutkować zawieszeniem maszyny odpytywanej\n" +
                                      "Kontroler domeny jest w stanie wygenerować nawet do 50 wpisów na sekundę.";
            tp.SetToolTip(LogCounter, LabelCounterText);
            tp.SetToolTip(LogCounterLabel, LabelCounterText);
        }
    }
}
