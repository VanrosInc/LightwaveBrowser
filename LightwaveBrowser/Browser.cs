using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awesomium.Windows.Forms;

namespace LightwaveBrowser
{
    public partial class Browser : UserControl
    {
        public Browser()
        {
            InitializeComponent();
            ShowBookmarksBar = false;
            ShowNavButtons = true;
            ShowAddonButtons = false;
            BookmarkBar.RenderMode = ToolStripRenderMode.Professional;
            BookmarkBar.Renderer = new ToolStripProfessionalRenderer(new ToolstripColortable());
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            
        }

        [Category("Appearance"), Description("Shows or hides the bookmarks bar.")]
        public bool ShowBookmarksBar
        {
            get { return BookmarkBar.Visible; }
            set
            {
                if (value)
                {
                    BrowserBar.Height = 60;
                    BookmarkBar.Visible = true;
                }
                else
                {
                    BookmarkBar.Visible = false;
                    BrowserBar.Height = 30;
                }
            }
        }

        [Category("Appearance"), Description("Shows or hides the extention-specific buttons menu.")]
        public bool ShowAddonButtons
        {
            get { return AddonButtons.Visible; }
            set
            {
                if (DesignMode == true) AddonButtons.BackColor = Color.DarkGray;
                if (value)
                {
                    ControlBar.Dock = DockStyle.Fill;
                    AddonButtons.Dock = DockStyle.Right;
                    AddonButtons.Visible = true;
                }
                else
                {
                    AddonButtons.Visible = false;
                    ControlBar.Dock = DockStyle.Fill;
                }
            }
        }

        [Category("Appearance"), Description("Shows or hides the forward and back buttons.")]
        public bool ShowNavButtons
        {
            get { return NavBar.Visible; }
            set
            {
                if (value)
                {
                    ControlBar.Dock = DockStyle.Fill;
                    NavBar.Dock = DockStyle.Left;
                    NavBar.Visible = true;
                }
                else
                {
                    ControlBar.Dock = DockStyle.Fill;
                    NavBar.Visible = false;
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Uri url = new Uri(textBox1.Text);
                    WebControl.Source = url;
                    WebControl.Update();
                }
                catch
                {

                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (WebControl.CanGoBack())
            {
                Back.BackgroundImage = Properties.Resources.Navigete_Back_Normal;
                Back.Enabled = true;
            }
            else
            {
                Back.Enabled = false;
                Back.BackgroundImage = Properties.Resources.Navigete_Back_Disabled;
            }
            WebControl.GoBack();
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            if (WebControl.CanGoForward())
            {
                Forward.BackgroundImage = Properties.Resources.Navigete_Forward_Normal;
                Forward.Enabled = true;
            }
            else
            {
                Forward.Enabled = false;
                Forward.BackgroundImage = Properties.Resources.Navigete_Forward_Disabled;
            }
            WebControl.GoForward();
        }

        private bool _isReload = false;
        private void Reload_Click(object sender, EventArgs e)
        {
            
        }

        private void Awesomium_Windows_Forms_WebControl_LoadingFrameComplete(object sender, Awesomium.Core.FrameEventArgs e)
        {
            _isReload = true;
            textBox1.Text = WebControl.Source.ToString();
        }

        private void Awesomium_Windows_Forms_WebControl_LoadingFrame(object sender, Awesomium.Core.LoadingFrameEventArgs e)
        {
            _isReload = false;
            CheckNav();
        }

        public void UpdateReload()
        {
            if (_isReload)
            {
                Reload.BackgroundImage = Properties.Resources.refresh;
                toolTip1.Show("Reload", Reload);
            }
            else
            {
                Reload.BackgroundImage = Properties.Resources.stop;
                toolTip1.Show("Stop", Reload);
            }
        }

        private void CheckNav()
        {
            if (WebControl.CanGoBack())
            {
                Back.BackgroundImage = Properties.Resources.Navigete_Back_Normal;
                Back.Enabled = true;
            }
            else
            {
                Back.Enabled = false;
                Back.BackgroundImage = Properties.Resources.Navigete_Back_Disabled;
            }
            if (WebControl.CanGoForward())
            {
                Forward.BackgroundImage = Properties.Resources.Navigete_Forward_Normal;
                Forward.Enabled = true;
            }
            else
            {
                Forward.Enabled = false;
                Forward.BackgroundImage = Properties.Resources.Navigete_Forward_Disabled;
            }
        }

        private void BookmarkBar_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
