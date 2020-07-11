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
    public partial class Environment : Form
    {
        public Environment(string hostName)
        {
            InitializeComponent();
            _hostName = hostName;
        }
        private string _hostName = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string variableName = textNameOfVariable.Text;
            string variableData = textValueOfVariable.Text;


            if (variableName.Length > 0)
            {
                if (new PuzzelLibrary.Registry.RegEnum().GetValueNames(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment").Contains(variableName))
                {
                    if (MessageBox.Show(new Form { }, "Wartość zmienna istnieje już w systemie, czy chcesz zastąpić?", "Wprowadzanie zmiennej", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        new PuzzelLibrary.Registry.RegQuery().QueryKey(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", variableName, variableData, Microsoft.Win32.RegistryValueKind.String);
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
