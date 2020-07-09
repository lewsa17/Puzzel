using System;
using System.Linq;
using PuzzelLibrary.Registry;
using System.Windows.Forms;

namespace Forms.External.QuickFix
{
    public partial class EnvironmentVariable : Form
    {
        public EnvironmentVariable(string hostName)
        {
            InitializeComponent();
            _hostName = hostName;
        }
        private string _hostName = null;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Nie przekazuj literałów jako zlokalizowanych parametrów", Justification = "<Oczekujące>")]
        private void BtnInputVar_Click(object sender, EventArgs e)
        {
            string variableName = TextBoxNameVar.Text;
            string variableData = TextBoxValueVar.Text;


            if (variableName.Length > 0)
            {
                if (new RegEnum().GetValueNames(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment").Contains(variableName))
                {
                    using (Form owner = new Form { })
                    {
                        if (MessageBox.Show(owner, "Wartość zmienna istnieje już w systemie, czy chcesz zastąpić?", "Wprowadzanie zmiennej", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            new RegQuery().QueryKey(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", variableName, variableData, Microsoft.Win32.RegistryValueKind.String);
                    }
                }
                else new RegQuery().QueryKey(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", variableName, variableData, Microsoft.Win32.RegistryValueKind.String);
            }
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
