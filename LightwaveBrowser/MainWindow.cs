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
using CefSharp;
using CefSharp.WinForms;

namespace LightwaveBrowser
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //Load NavIcons.
            //BackBTN.BackgroundImage = back_disabled;
            //ForwardBTN.BackgroundImage = forward_disabled;
            //BookmarkBTN.BackgroundImage = bookmark_normal;
            //RefreshBTN.BackgroundImage = reload;
            //DownloadBTN.BackgroundImage = download_normal;
            //BackBTN.BackgroundImageLayout = ForwardBTN.BackgroundImageLayout = BookmarkBTN.BackgroundImageLayout = RefreshBTN.BackgroundImageLayout = DownloadBTN.BackgroundImageLayout = ImageLayout.Zoom;
            
        }

        private Util.LightwaveURLManager LightwaveURLManager;

        private static Size navButtonSize = new Size(150, 150);
        private Bitmap back_disabled = new Bitmap(Properties.Resources.Navigete_Back_Disabled, navButtonSize);
        private Bitmap back_enabled = new Bitmap(Properties.Resources.Navigete_Back_Normal, navButtonSize);
        private Bitmap forward_disabled = new Bitmap(Properties.Resources.Navigete_Forward_Disabled, navButtonSize);
        private Bitmap forward_enabled = new Bitmap(Properties.Resources.Navigete_Forward_Normal, navButtonSize);
        private Bitmap bookmark_normal = new Bitmap(Properties.Resources.bookmark, navButtonSize);
        private Bitmap bookmark_saved = new Bitmap(Properties.Resources.bookmark_saved, navButtonSize);
        private Bitmap reload = new Bitmap(Properties.Resources.refresh, navButtonSize);
        private Bitmap stop = new Bitmap(Properties.Resources.stop, navButtonSize);
        private Bitmap download_normal = new Bitmap(Properties.Resources.download_normal, navButtonSize);
        private Bitmap download_paused = new Bitmap(Properties.Resources.download_paused, navButtonSize);
        private Bitmap download_error = new Bitmap(Properties.Resources.download_error, navButtonSize);
        private Bitmap download_complete = new Bitmap(Properties.Resources.download_Complete, navButtonSize);

        private static Size toolstripButtonSize = new Size(300, 300);
        private Bitmap addBookmarksToBar = new Bitmap(Properties.Resources.bookmarkbar_add_bookmark, toolstripButtonSize);

        protected TitleBarTabs ParentTabs
        {
            get => (ParentForm as TitleBarTabs);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //LightwaveURLManager = new Util.LightwaveURLManager(browser);
            this.WindowState = FormWindowState.Normal;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //LightwaveURLManager.Navigate(textBox1.Text);
            }
        }
    }
}

/*
 *ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                Color.Transparent, 0, ButtonBorderStyle.None, //Left
                Color.Transparent, 0, ButtonBorderStyle.None, //Top
                Color.Black, 2, ButtonBorderStyle.Solid, //Right
                Color.White, 1, ButtonBorderStyle.Solid); //Bottom
 */
