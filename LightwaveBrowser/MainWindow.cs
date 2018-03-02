using Awesomium.Windows.Forms;
using EasyTabs;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LightwaveBrowser
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Util.LightwaveURLManager LightwaveURLManager;

        protected TitleBarTabs ParentTabs
        {
            get => (ParentForm as TitleBarTabs);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //LightwaveURLManager = new Util.LightwaveURLManager(webControl1);
            this.WindowState = FormWindowState.Normal;
        }

        //public WebControl GetWebControl()
        //{
        //    //return webControl1;
        //}

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //LightwaveURLManager.Navigate(textBox1.Text);
            }
        }
    }
}
