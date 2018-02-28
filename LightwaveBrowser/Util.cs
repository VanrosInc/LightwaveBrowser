using Awesomium.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LightwaveBrowser.Util
{
    public sealed class BrowserUtils
    {
        
    }

    public interface ILightwaveURL
    {
        string Name { get; }
        Guid ID { get; }
        void Action(WebControl webBrowser);
    }

    public abstract class NamedURL : ILightwaveURL
    {
        private string _name = "";
        private Guid _id = Guid.Empty;
        private List<NamedURL> _subNames;

        public NamedURL(string name, NamedURL[] subNames = null)
        {
            _subNames = new List<NamedURL>(); 
            _name = name;
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

        public void Navigate(string rawSource)
        {
            try
            {
                /*
                 * 
                 */
                if (!(Uri.TryCreate(rawSource, UriKind.RelativeOrAbsolute, out Uri url)) || Limited(url) || url.ToString().StartsWith("lightwave://"))
                {
                    Console.WriteLine("URI Source was not valid URI!");
                    if (rawSource.StartsWith("lightwave://"))
                    {
                        try
                        {
                            //Parse LightwaveURLs.
                            var lightwave = Regex.Split(rawSource, "lightwave://");
                            var names = Regex.Split(lightwave[0], "/");
                            var name = names[0];
                            var subnames = names.Skip(1).ToArray();
                            var n = GetNamedURL(name);
                            if (n == null)
                            {
                                Console.WriteLine("That is not a lightwaveURL!");
                                //TODO: Create error page for unknown LightwaveURLs.

                                return;
                            }
                            else
                            {
                                try
                                {
                                    if (subnames.Length != 0)
                                    {
                                        NamedURL currentName = n;
                                        for (int i = 0; i == subnames.Length; i++)
                                        {
                                            currentName = currentName.GetSubName(subnames[i]);
                                        }

                                        currentName.Action(_webControl);
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine($"One or more of the SubNames in the URL where invalid!");
                                    //TODO: Create error page for invalid SubName.

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                    }
                    else
                    {
                        //Search for query.
                        Console.WriteLine($"Searching for: \"{rawSource}\"");
                        _webControl.Source = (new Uri("http://www.google.com/search?q=" + $"{rawSource}"));
                        _webControl.Update();
                    }
                }
                else
                {
                    Console.WriteLine($"Attempting to navigate to: \"{url.ToString()}\"...");
                    _webControl.Source = url;
                    _webControl.Update();
                    Console.WriteLine($"Navigation to: \"{url.ToString()}\" complete!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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