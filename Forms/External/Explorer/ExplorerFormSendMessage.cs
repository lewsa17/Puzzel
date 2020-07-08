﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Forms.External.Explorer
{
    public partial class ExplorerFormSendMessage : Form
    {
        private string hostName;
        private int selectedSessionID;
        public ExplorerFormSendMessage(string _hostName, int _selectedSessionID)
        {
            hostName = _hostName;
            selectedSessionID = _selectedSessionID;
            InitializeComponent();
        }
        private void SendMessage(object sender, EventArgs e)
        {
            var session = new PuzzelLibrary.Terminal.Explorer().FindSession(new PuzzelLibrary.Terminal.Explorer().GetRemoteServer(hostName), selectedSessionID);
                session.MessageBox(richTextBox1.Text, textBox1.Text);
                this.Close();
            
        }
    }
}