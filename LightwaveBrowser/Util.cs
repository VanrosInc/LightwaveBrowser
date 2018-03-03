using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LightwaveBrowser.Util
{
    public sealed class BrowserUtils
    {
        private static SearchProvider _provider = null;
        public static SearchProvider SearchProvider
        {
            get
            {
                if (_provider == null)
                {
                    return DefaultSearchProviders.Google();
                }
                return _provider;
            }
            set => _provider = value;
        }
        private static string _lwVersion = "0.0.0.25b";
        public static string LightwaveVersion => _lwVersion;
        private static UserAgent _agent = UserAgent.LightwaveWindowsUA;
        public static UserAgent UserAgent
        {
            get => _agent;
            set => _agent = value;
        }
        private static IO.Directory _installDir = new IO.Directory($@"{IO.Directory.ProgramFiles}\Vanros\Lightwave\{LightwaveVersion}");
        private static IO.Directory _dataDir = new IO.Directory($@"{IO.Directory.AppData.Path}\Lightwave Browser\Data");
        private static IO.Directory _logsDir = new IO.Directory($@"{_dataDir}\Logs");
        private static IO.Directory _extentionsDir = new IO.Directory($@"{_dataDir}\Extentions");
        private static IO.Directory _extentionConfigDir = new IO.Directory($@"{_extentionsDir}\Config");
        private static IO.Directory _themeDirectory = new IO.Directory($@"{_dataDir}\Themes");
        private static IO.Directory _syncData = new IO.Directory($@"{_dataDir}\SyncData");
        private static IO.Directory _downloads = new IO.Directory(IO.Directory.Downloads.Path);
        public static IO.Directory InstallDirectory => _installDir;
        public static IO.Directory DataDirectory => _dataDir;
        public static IO.Directory LogDirectory => _logsDir;
        public static IO.Directory ExtentionsDirectory => _extentionsDir;
        public static IO.Directory ExtentionConfigDirectory => _extentionConfigDir;
        public static IO.Directory ThemesDirectory => _themeDirectory;
        public static IO.Directory SyncDataDirectory => _syncData;
        public static IO.Directory DownloadsFolder
        {
            get => _downloads;
            set => _downloads = value;
        }

    }

    public sealed class DefaultSearchProviders
    {
        public static SearchProvider Google()
        {
            var provider = new SearchProvider();
            provider.Provider = "Google";
            provider.Source = new Uri("http://www.google.com");
            provider.SearchSource = new Uri($"{provider.Source}/search?q=");
            provider.Favicon = new Uri($"{provider.Source}/favicon.ico");
            return provider;
        }
        public static SearchProvider Yahoo()
        {
            var provider = new SearchProvider();
            provider.Provider = "Yahoo";
            provider.Source = new Uri("http://www.yahoo.com");
            provider.SearchSource = new Uri($"http://search.yahoo.com/search?p=");
            provider.Favicon = new Uri($"{provider.Source}/favicon.ico");
            return provider;
        }
        public static SearchProvider Bing()
        {
            var provider = new SearchProvider();
            provider.Provider = "Bing";
            provider.Source = new Uri("http://www.bing.com");
            provider.SearchSource = new Uri($"{provider.Source}/search?q=");
            provider.Favicon = new Uri($"{provider.Source}/favicon.ico");
            return provider;
        }
        public static SearchProvider Wikipedia()
        {
            var provider = new SearchProvider();
            provider.Provider = "Wikipedia";
            provider.Source = new Uri("http://en.wikipedia.org/");
            provider.SearchSource = new Uri($"http://en.wikipedia.org/wiki/");
            provider.Favicon = new Uri($"{provider.Source}/favicon.ico");
            return provider;
        }
    }

    public class SearchProvider
    {
        private string _providerName = "";
        private Uri _providerSource = null;
        private Uri _proverserSearchSource = null;
        private Uri _providerFavicon = null;

        public SearchProvider()
        {

        }
        
        public string Provider
        {
            get => _providerName;
            set => _providerName = value;
        }

        public Uri Source
        {
            get => _providerSource;
            set => _providerSource = value;
        }

        public Uri SearchSource
        {
            get => _proverserSearchSource;
            set => _proverserSearchSource = value;
        }

        public Uri Favicon
        {
            get => _providerFavicon;
            set => _providerFavicon = value;
        }
    }

    public struct UserAgent
    {
        private string _agent;
        private OSTypes _OS;
        public UserAgent(string agent, OSTypes os = OSTypes.UNSPECIFIED)
        {
            _agent = agent;
            _OS = os;
        }

        public string GetUserAgent()
        {
            return _agent;
        }

        public OSTypes GetOS()
        {
            return _OS;
        }

        public override string ToString()
        {
            return _agent;
        }

        #region WindowsUserAgents
        public static UserAgent Explorer11WindowsUA => new UserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko", OSTypes.WINDOWS);
        public static UserAgent EdgeWindowsUA => new UserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.10240", OSTypes.WINDOWS);
        public static UserAgent FirefoxWindowsUA => new UserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64; rv:46.0) Gecko/20100101 Firefox/46.0", OSTypes.WINDOWS);
        public static UserAgent ChromeWindowsUA => new UserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36", OSTypes.WINDOWS);
        public static UserAgent OperaWindowsUA => new UserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36 OPR/37.0.2178.31", OSTypes.WINDOWS);
        public static UserAgent LightwaveWindowsUA => new UserAgent($"Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 LWave/{BrowserUtils.LightwaveVersion}", OSTypes.WINDOWS);
        #endregion

        #region MacUserAgents
        public static UserAgent SafariUA => new UserAgent("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_3) AppleWebKit/537.75.14 (KHTML, like Gecko) Version/7.0.3 Safari/7046A194A", OSTypes.MAC);
        public static UserAgent OperaMacUA => new UserAgent("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36 OPR/37.0.2178.31", OSTypes.MAC);
        public static UserAgent FirefoxMacUA => new UserAgent("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.11; rv:46.0) Gecko/20100101 Firefox/46.0", OSTypes.MAC);
        public static UserAgent ChromeMacUA => new UserAgent("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36", OSTypes.MAC);
        public static UserAgent LightwaveMacUA => new UserAgent($"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 LWave/{BrowserUtils.LightwaveVersion}", OSTypes.MAC);
        #endregion

        #region LinuxUserAgents

        #endregion

        public enum OSTypes
        {
            WINDOWS = 1, LINUX = 2, MAC = 3, ANDROID = 4, IOS = 5, WINDOWS_PHONE = 6, XBOX = 7, OTHER = 8, UNSPECIFIED = 0
        }
    }

    public class Browser
    {
        private ChromiumWebBrowser _browser = null;

        public Browser(System.Windows.Forms.Form form)
        {
            _browser = new ChromiumWebBrowser("");
            _browser.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(_browser);
            _browser.AddressChanged += _browser_AddressChanged;
            _browser.FrameLoadStart += _browser_FrameLoadStart;
            _browser.FrameLoadEnd += _browser_FrameLoadEnd;
            _browser.LoadError += _browser_LoadError;
        }

        private void _browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _browser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            var browser = e.Browser;
            
            
        }
    }

    public interface IBrowserURL
    {
        string Name { get; set; }
        Guid ID();
        void Navigated(Browser browser);
    }

    public class LightwaveURL : IBrowserURL
    {
        private string _name;
        private Guid _id;

        string IBrowserURL.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public LightwaveURL(string name)
        {
            _name = name;
            _id = Guid.NewGuid();
        }

        public string Name()
        {
            return _name;
        }

        public Guid ID()
        {
            return ID();
        }

        public virtual void Navigated(Browser browser) {}
    }

    public sealed class LightwaveURLManager
    {
        private List<LightwaveURL> urls = new List<LightwaveURL>();
        private Browser browser = null;

        public LightwaveURLManager(Browser browser)
        {
            this.browser = browser;
            //Register URLS

        }


    }
}

namespace LightwaveBrowser.Util.TaskManagement
{
    public class JumpLists
    {
        private JumpLists()
        {
               
        }
    }
}