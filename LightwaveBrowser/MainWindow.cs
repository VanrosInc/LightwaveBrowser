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

        protected TitleBarTabs ParentTabs
        {
            get => (ParentForm as TitleBarTabs);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Normal;
        }
        
        private void browser1_Load(object sender, EventArgs e)
        {

        }

        private void Awesomium_Windows_Forms_WebControl_ShowCreatedWebView(object sender, Awesomium.Core.ShowCreatedWebViewEventArgs e)
        {

        }

        private void Awesomium_Windows_Forms_WebControl_LoadingFrameComplete(object sender, Awesomium.Core.FrameEventArgs e)
        {

        }

        private void Awesomium_Windows_Forms_WebControl_LoadingFrame(object sender, Awesomium.Core.LoadingFrameEventArgs e)
        {

        }

        private void SocialTitle_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
