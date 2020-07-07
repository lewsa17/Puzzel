using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void button1_Click(object sender, EventArgs e)
        {
            string variableName = textBox1.Text;
            string variableData = textBox2.Text;


            if (variableName.Length > 0)
            {
                if (new PuzzelLibrary.Registry.RegEnum().GetValueNames(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment").Contains(variableName))
                {
                    using (Form owner = new Form { })
                    {
                        if (MessageBox.Show(owner, "Wartość zmienna istnieje już w systemie, czy chcesz zastąpić?", "Wprowadzanie zmiennej", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            new PuzzelLibrary.Registry.RegQuery().QueryKey(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", variableName, variableData, Microsoft.Win32.RegistryValueKind.String);
                    }
                }
                else new PuzzelLibrary.Registry.RegQuery().QueryKey(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", variableName, variableData, Microsoft.Win32.RegistryValueKind.String);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
