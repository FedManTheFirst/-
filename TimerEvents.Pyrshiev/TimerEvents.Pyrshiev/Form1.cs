﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerEvents.Pyrshiev
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer t;
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer t;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();

        }
        void t_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;

            if (progressBar1.Value >= 100) t.Stop();
        }


    }
}
