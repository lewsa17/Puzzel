using System.Drawing;
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
        }

        private void FindButton_Click(object sender, System.EventArgs e)
        {
            PuzzelLibrary.Debug.EventsCollector ec = new PuzzelLibrary.Debug.EventsCollector();
            var query = string.Format("*[System/TimeCreated/@SystemTime >= '{0}'] and *[System/TimeCreated/@SystemTime <= '{1}']",
                StartDateRangePicker.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ"), EndDateRangePicker.Value.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ"));
            TextLogView.Text = ec.QueryActiveLog("Security", query, StartDateRangePicker.Value);
        }
    }
}
