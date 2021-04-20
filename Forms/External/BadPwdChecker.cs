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
            var query = string.Format("*[System/TimeCreated/@SystemTime <= \"{0}\"]", EndDateRangePicker.Value.ToUniversalTime().AddHours(2).ToString("o"));
            TextLogView.Text = ec.QueryActiveLog("Security", query, StartDateRangePicker.Value.ToUniversalTime().AddHours(2));


        }
    }
}
