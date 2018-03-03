using CefSharp;
using CefSharp.WinForms;
using EasyTabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightwaveBrowser
{
    partial class Program
    {
        private static Thread t;

        [STAThread]
        static void Main(string[] args)
        {
            t = new Thread(new Program().Start);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //AppContainer container = new AppContainer();
                //container.Tabs.Add(new TitleBarTab(container)
                //{
                //    Content = new MainWindow
                //    {
                //        Text = "New Tab"
                //    }
                //});

                //container.SelectedTabIndex = 0;

                //TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
                //applicationContext.Start(container);
                //Application.Run(applicationContext);
                Application.Run(new MainWindow());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void initBrowser()
        {
            CreateFolders();
            CefSettings settings = new CefSettings();
            settings.UserAgent = Util.BrowserUtils.UserAgent.GetUserAgent();
            if (Util.BrowserUtils.LogDirectory.Exists)
                settings.LogFile = Util.BrowserUtils.LogDirectory.Path;
            settings.ResourcesDirPath = Util.BrowserUtils.DataDirectory.Path;
            Cef.Initialize(settings);
        }

        private static void CreateFolders()
        {
            Util.BrowserUtils.DataDirectory.Create();
            Util.BrowserUtils.LogDirectory.Create();
            Util.BrowserUtils.ExtentionsDirectory.Create();
            Util.BrowserUtils.ExtentionConfigDirectory.Create();
            Util.BrowserUtils.SyncDataDirectory.Create();
            Util.BrowserUtils.ThemesDirectory.Create();
        }
    }
}
