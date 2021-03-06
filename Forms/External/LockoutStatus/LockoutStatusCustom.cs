﻿using System;
using System.Windows.Forms;

namespace Forms.External
{
    public partial class LockoutStatusCustom : Form
    {
        public LockoutStatusCustom()
        {
            InitializeComponent();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            LockoutStatus.Username = textUserName.Text;
            LockoutStatus.domainAddress = textDomainName.Text;
            Close();
        }
        private void LockoutStatusCustoma_Load(object sender, EventArgs e)
        {
            if (LockoutStatus.Username.Length > 1)
                this.textUserName.Text = LockoutStatus.Username;
            this.textDomainName.Text = PuzzelLibrary.AD.Other.Domain.GetDomainName;
        }
        private void EnterKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LockoutStatus.Username = textUserName.Text;
                LockoutStatus.domainAddress = textDomainName.Text;
                Close();
            }
        }
    }
}
