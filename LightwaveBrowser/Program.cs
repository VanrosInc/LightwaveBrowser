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
                AppContainer container = new AppContainer();
                container.Tabs.Add(new TitleBarTab(container)
                {
                    Content = new MainWindow
                    {
                        Text = "New Tab"
                    }
                });

                container.SelectedTabIndex = 0;

                TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
                applicationContext.MainForm.WindowState = FormWindowState.Normal;
                applicationContext.Start(container);
                Application.Run(applicationContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
