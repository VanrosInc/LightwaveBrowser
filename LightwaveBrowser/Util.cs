using Awesomium.Windows.Forms;
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
    }
    //https://search.yahoo.com/search?p=yahoo - Yahoo
    //https://www.bing.com/search?q=bing - Bing

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

    public interface ILightwaveURL
    {
        string Name { get; }
        Guid ID { get; }
        void Action(WebControl webBrowser);
    }

    public abstract class NamedURL : ILightwaveURL
    {
        private bool isSubName = false;
        private string _name = "";
        private Guid _id = Guid.Empty;
        private NamedURL _parentName = null;
        private List<NamedURL> _subNames;

        public NamedURL(string name, NamedURL[] subNames = null)
        {
            _subNames = new List<NamedURL>(); 
            _name = name;
            isSubName = false;
            if (!(subNames == null))
            {
                AddSubNames(subNames);
            }
            _id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the name of this NamedURL. 
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Gets the unigue constructor-set ID of this NamedURL.
        /// </summary>
        public Guid ID => _id;

        /// <summary>
        /// Gets all registered sub-names of this NamedURL.
        /// </summary>
        public IReadOnlyList<NamedURL> SubNames()
        {
            return _subNames;
        }

        /// <summary>
        /// This function is run everytime the browser detects that this NamedURL is found in its URL bar.
        /// </summary>
        /// <param name="webBrowser">The Parent Web Browsers web browser control.</param>
        public abstract void Action(WebControl webBrowser);

        /// <summary>
        /// Adds a valid sub-name of NamedURL to this NamedURL.
        /// </summary>
        /// <param name="subNamedURL">The sub-name to add.</param>
        public void AddSubName(NamedURL subNamedURL)
        {
            subNamedURL._parentName = this;
            subNamedURL.isSubName = true;
            _subNames.Add(subNamedURL);
        }

        /// <summary>
        /// Adds an array of valid NamedURL sub-names to this NamedURL
        /// </summary>
        /// <param name="subNamedURLs">The sub-names to add.</param>
        public void AddSubNames(NamedURL[] subNamedURLs)
        {
            foreach (NamedURL subName in subNamedURLs)
                AddSubName(subName);
        }

        /// <summary>
        /// Removes a NamedURL sub-name from this NamedURL.
        /// </summary>
        /// <param name="subNamedURL">The sub-name to remove.</param>
        public void RemoveSubName(NamedURL subNamedURL)
        {
            _subNames.Add(subNamedURL);
        }

        /// <summary>
        /// Removes an array of NamedURL sub-names from this NamedURL.
        /// </summary>
        /// <param name="subNamedURLs">The sub-names to remove.</param>
        public void RemoveSubNames(NamedURL[] subNamedURLs)
        {
            foreach (NamedURL subName in subNamedURLs)
                AddSubName(subName);
        }

        /// <summary>
        /// Gets a valid NamedURL sub-name from this NamedURL.
        /// </summary>
        /// <param name="name">The name of the sub-name to get.</param>
        /// <returns>The NamedURL sub-name.</returns>
        public NamedURL GetSubName(string name)
        {
            NamedURL namedURL = null;
            foreach (NamedURL named in SubNames())
            {
                if (named.Name == name)
                {
                    namedURL = named;
                    break;
                }
            }
            return namedURL;
        }

        /// <summary>
        /// Gets a valid NamedURL sub-name from this NamedURL.
        /// </summary>
        /// <param name="ID">The unique ID of the sub-name to get.</param>
        /// <returns>The NamedURL sub-name.</returns>
        public NamedURL GetSubName(Guid ID)
        {
            NamedURL namedURL = null;
            foreach (NamedURL named in SubNames())
            {
                if (named.ID == ID)
                {
                    namedURL = named;
                    break;
                }
            }
            return namedURL;
        }

        public static NamedURL GetFinalNamedURL(NamedURL startingName, string[] subNames)
        {
            NamedURL r = startingName;
            for (int i = 0; i == subNames.Length; i++)
            {
                r = r.GetSubName(subNames[i]);
            }
            return r;
        }
    }

    public sealed class LightwaveURLManager
    {
        private WebControl _webControl = null;
        public List<NamedURL> lightwaveURLs = null;

        public LightwaveURLManager(WebControl webControl)
        {
            lightwaveURLs = new List<NamedURL>();
            _webControl = webControl;
            //TODO: Register internal URLs.
            AddNamedURLs(new NamedURL[]
            { new SettingsURL(), new BookmarkURL(), new HistoryURL(), new PluginURL(), new NewtabURL(), new FlagsURL()});
        }

        public void AddNamedURL(NamedURL namedURL)
        {
            lightwaveURLs.Add(namedURL);
        }

        public void AddNamedURLs(NamedURL[] namedURLs)
        {
            foreach (NamedURL namedURL in namedURLs)
            {
                AddNamedURL(namedURL);
            }
        }

        public void RemoveNamedURL(NamedURL namedURL)
        {
            lightwaveURLs.Remove(namedURL);
        }

        public void RemoveNamedURLs(NamedURL[] namedURLs)
        {
            foreach (NamedURL namedURL in namedURLs)
            {
                RemoveNamedURL(namedURL);
            }
        }

        public NamedURL GetNamedURL(string name)
        {
            NamedURL namedURL = null;
            foreach (NamedURL named in lightwaveURLs)
            {
                if (named.Name == name)
                {
                    namedURL = named;
                    break;
                }
            }
            return namedURL;
        }

        public NamedURL GetNamedURL(Guid ID)
        {
            NamedURL namedURL = null;
            foreach (NamedURL named in lightwaveURLs)
            {
                if (named.ID == ID)
                {
                    namedURL = named;
                    break;
                }
            }
            return namedURL;
        }

        public IReadOnlyList<NamedURL> GetLighwaveURLs()
        {
            return lightwaveURLs;
        }

        /// <summary>
        /// Navigates to the specified URL or searches for a value if it's not a URL.
        /// </summary>
        /// <param name="rawSource">The original non-parsed string.</param>
        public void Navigate(string rawSource)
        {
            try
            {
                if (!(Uri.TryCreate(rawSource, UriKind.RelativeOrAbsolute, out Uri url)) || Limited(url))
                {
                    System.Diagnostics.Debug.WriteLine($"Searching for: \"{url.OriginalString}\"...");
                    var searchUrl = new Uri($"{BrowserUtils.SearchProvider.SearchSource}{url.ToString()}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Attempting to navigate to: \"{url.ToString()}\"...");
                    if (url.ToString().StartsWith("lightwave://"))
                    {
                        System.Diagnostics.Debug.WriteLine("Navigating to a LightwaveURL...");
                        var u = url.ToString();
                        u = Regex.Replace(u, "lightwave://", "");
                        var x = u.Split('/');
                        var name = x[0];
                        System.Diagnostics.Debug.WriteLine($"Found: {name}.");
                        var subnames = x.Skip(1).ToArray();
                        System.Diagnostics.Debug.WriteLine("Checking LightwaveURL");
                        var named = NamedURL.GetFinalNamedURL(GetNamedURL(name), subnames);
                        if (named == null)
                        {
                            System.Diagnostics.Debug.WriteLine($"The webpage at \"{url.ToString()}\" may be down or it may have been moved to a new address!");
                            Console.WriteLine();
                            //TODO: Create error page.
                            
                        }
                        else
                        {
                            try
                            {
                                named.Action(_webControl);
                                System.Diagnostics.Debug.WriteLine($"Navigated to: \"{url.ToString()}\" successfully!");
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.ToString());
                                //TODO: Create error page.

                            }
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Navigating to: \"{url.ToString()}\"...");
                        _webControl.Source = url;
                        _webControl.Update();
                        System.Diagnostics.Debug.WriteLine("Navigation Complete!");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private bool Limited(Uri uri)
        {
            if (uri.IsAbsoluteUri == false)
            {
                if (!(uri.OriginalString.Contains(".")))
                    return true;
            }
            return false;
        }
    }

    public class SettingsURL : NamedURL
    {
        public SettingsURL() : base("settings") { }

        public override void Action(WebControl webBrowser)
        {
            //TODO: Implement settings.

        }
    }

    public class BookmarkURL : NamedURL
    {
        public BookmarkURL() : base("bookmaks") { }

        public override void Action(WebControl webBrowser)
        {
            //TODO: Implement bookmarks.

        }
    }

    public class HistoryURL : NamedURL
    {
        public HistoryURL() : base("history") { }

        public override void Action(WebControl webBrowser)
        {
            //TODO: Implement history.

        }
    }

    public class PluginURL : NamedURL
    {
        public PluginURL() : base("plugins") { }

        public override void Action(WebControl webBrowser)
        {
            //TODO: Implement plugins.

        }
    }

    public class NewtabURL : NamedURL
    {
        public NewtabURL() : base("newtab") { }

        public override void Action(WebControl webBrowser)
        {
            //TODO: Implement newtab.

            //TODO: Delete or comment debug code.
            webBrowser.Source = new Uri("http://www.google.com/");
            webBrowser.Update();
        }
    }

    public class FlagsURL : NamedURL
    {
        public FlagsURL() : base("flags") { }

        public override void Action(WebControl webBrowser)
        {
            //TODO: Implement flags.

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