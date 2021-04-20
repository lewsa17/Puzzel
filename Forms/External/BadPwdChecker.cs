using System;
using System.Windows.Forms;

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
        }

        private void FindButton_Click(object sender, System.EventArgs e)
        {
            PuzzelLibrary.Debug.EventsCollector ec = new PuzzelLibrary.Debug.EventsCollector() { MaxCount = (int)LogCounter.Value };
            string dateFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
            var query = string.Format("*[System/TimeCreated/@SystemTime >= '{0}'] and *[System/TimeCreated/@SystemTime <= '{1}']",
                StartDateRangePicker.Value.ToUniversalTime().ToString(dateFormat), EndDateRangePicker.Value.ToString(dateFormat));

            if (string.IsNullOrEmpty(LocationText.Text))
                TextLogView.Text = ec.GetLocalLog("Security", query);

            if (string.IsNullOrEmpty(LocationText.Text) && LocationText.ReadOnly)
            {
                var domainControllers = PuzzelLibrary.AD.Other.Domain.GetCurrentDomainControllers();
                string lastUseddomainControllers = string.Empty;
                DateTime lastBadPwd = DateTime.MinValue;
                var pd = new PuzzelLibrary.AD.User.Information.PasswordDetails();
                foreach (var domainController in domainControllers)
                {
                    pd.GetUserPasswordDetails(TitleName.Replace("Domain", ""), domainController);
                    if (lastBadPwd < pd.lastBadPasswordAttempt)
                    {
                        lastBadPwd = pd.lastBadPasswordAttempt;
                        lastUseddomainControllers = domainController;
                    }
                }
                ec.GetRemoteLog(lastUseddomainControllers, "Security", query);
            }

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
