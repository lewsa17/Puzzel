using System;
using System.Windows.Forms;

namespace Forms.External
{
    public partial class BadPwdChecker : Form
    {
        private static string _TitleName;
        public BadPwdChecker(string TitleName)
        {
            _TitleName = TitleName;
            InitializeComponent();
            if (TitleName.Contains("Domain"))
            {
                LocationText.ReadOnly = true;
                LocationText.Text = "DomainHub";
            }
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
                    pd.GetUserPasswordDetails(_TitleName.Replace("Domain", ""), domainController);
                    if (lastBadPwd < pd.lastBadPasswordAttempt)
                    {
                        lastBadPwd = pd.lastBadPasswordAttempt;
                        lastUseddomainControllers = domainController;
                    }
                }
                ec.QueryRemoteComputer(lastUseddomainControllers, "Security", query);
            }

            if (!string.IsNullOrEmpty(LocationText.Text))
            {
                TextLogView.Text = ec.QueryRemoteComputer("localhost", "Security", query);
            }
        }
    }
}
