﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzel
{
    public partial class PodajNazweTerminala : Form
    {
        public PodajNazweTerminala()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Puzzel.Form1.terminalName = textBox1.Text;
            this.Close();
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Puzzel.Form1.terminalName = textBox1.Text;
                this.Close();
            }
        }
    }
}
