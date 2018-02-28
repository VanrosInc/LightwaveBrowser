using EasyTabs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightwaveBrowser
{
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            AeroPeekEnabled = true;
            ExitOnLastTabClose = false;
            WindowState = FormWindowState.Normal;
            TabRenderer = new LightwaveTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            var TBTab = new TitleBarTab(this)
            {
                Content = new MainWindow
                {
                    Text = "New Tab",
                    WindowState = FormWindowState.Normal
                }
            };
            return TBTab;
        }
    }
}
