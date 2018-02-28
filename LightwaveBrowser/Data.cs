using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LightwaveBrowser.Data
{
    public interface IBookmarkable
    {
        string Name { get; }
        BookmarkFolder Parent { get; set; }
        string Password { get; set; }
    }

    public class Bookmark : IBookmarkable
    {
        private string _name;
        private string _pass;
        private Uri _source;
        private Image _favicon;
        private BookmarkFolder _parent;
        private Guid _id;

        /// <summary>
        /// Creates a new instance of the Bookmark class.
        /// </summary>
        /// <param name="name">The name of the bookmark.</param>
        /// <param name="favicon">The favicon of the bookmark source.</param>
        /// <param name="source">The URI location of the bookmark.</param>
        /// <param name="password">The password of the bookmark to use to encrypt the bookmark file.</param>
        /// <param name="parent">The parent BookmarkFolder of the bookmark.</param>
        public Bookmark(string name, Image favicon, Uri source, string password = "", BookmarkFolder parent = null)
        {
            _name = name;
            _pass = password;
            _source = source;
            _favicon = favicon;
            _parent = parent;
            _id = Guid.NewGuid();
        }

        /// <summary>
        /// The name of the Bookmark.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The parent BookmarkFolder of the Bookmark.
        /// </summary>
        public BookmarkFolder Parent { get => _parent; set => _parent = value; }

        /// <summary>
        /// The password that is used to encrypt the Bookmarks' file.
        /// </summary>
        public string Password { get => _pass; set => _pass = value; }

        /// <summary>
        /// The URI source of the Bookmark.
        /// </summary>
        public Uri Source => _source;

        /// <summary>
        /// The favicon of the Bookmark.
        /// </summary>
        public Image Favicon { get => _favicon; set => _favicon = value; }

        /// <summary>
        /// The Unique ID of the Bookmark.
        /// </summary>
        public Guid ID => _id;
    }

    public class BookmarkFolder : IBookmarkable
    {
        private string _name;
        private string _pass;
        private Image _icon;
        private BookmarkFolder _parent;
        private List<IBookmarkable> _contents;
        private Guid _id;

        public BookmarkFolder(string name, Image icon, IBookmarkable[] contents, string password = "", BookmarkFolder parent = null)
        {
            _name = name;
            _pass = password;
            _icon = icon;
            _parent = parent;
            _contents = contents.ToList();
            _id = Guid.NewGuid();
        }

        /// <summary>
        /// The name of the BookmarkFolder.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The parent BookmarkFolder of the BookmarkFolder.
        /// </summary>
        public BookmarkFolder Parent { get => _parent; set => _parent = value; }

        /// <summary>
        /// The password that is used to encrypt the BookmarksFolder' file.
        /// </summary>
        public string Password { get => _pass; set => _pass = value; }

        /// <summary>
        /// The icon of the BookmarkFolder.
        /// </summary>
        public Image Icon { get => _icon; set => _icon = value; }

        /// <summary>
        /// The IBookmarkable contents of the BookmarkFolder.
        /// </summary>
        public IBookmarkable[] Contents { get => _contents.ToArray(); set => _contents = value.ToList(); }

        /// <summary>
        /// The contents of the BookmarkFolder.
        /// </summary>
        private List<IBookmarkable> Contents_ { get => _contents; set => _contents = value; }

        /// <summary>
        /// The ID of the BookmarkFolder.
        /// </summary>
        public Guid ID => _id;

        /// <summary>
        /// Adds a Bookmark to the BookmarkFolders' contents.
        /// </summary>
        /// <param name="bookmark">The Bookmark to add.</param>
        public void AddBookmark(Bookmark bookmark)
        {
            Contents_.Add(bookmark);
        }

        /// <summary>
        /// Adds a BookmarkFolder to the BookmarkFolders' contents.
        /// </summary>
        /// <param name="bookmarkFolder">The Bookmark to add.</param>
        public void AddBookmarkFolder(BookmarkFolder bookmarkFolder)
        {
            Contents_.Add(bookmarkFolder);
        }

        /// <summary>
        /// Adds an IBookmarkable to the BookmarkFolders' contents.
        /// </summary>
        /// <param name="bookmarkable">The IBookmarkable to add.</param>
        [Obsolete()]
        public void AddIBookmarkable(IBookmarkable bookmarkable)
        {
            Contents_.Add(bookmarkable);
        }

        /// <summary>
        /// Removes a Bookmark from a BookmarkFolders' contents.
        /// </summary>
        /// <param name="bookmark">The Bookmark to remove.</param>
        public void RemoveBookmark(Bookmark bookmark)
        {
            Contents_.Remove(bookmark);
        }

        /// <summary>
        /// Removes a BookmarkFolder from the BookmarkFolders' contents.
        /// </summary>
        /// <param name="bookmarkFolder">The BookmarkFolder to remove.</param>
        public void RemoveBookmarkFolder(BookmarkFolder bookmarkFolder)
        {
            Contents_.Remove(bookmarkFolder);
        }

        /// <summary>
        /// Removes an IBookmarkable from BookmarkFolders' contents.
        /// </summary>
        /// <param name="bookmarkable">The IBookmarkable to remove.</param>
        [Obsolete()]
        public void RemoveIBookmarkable(IBookmarkable bookmarkable)
        {
            Contents_.Remove(bookmarkable);
        }

        /// <summary>
        /// Gets an IReadOnlyList of Bookmarks from this BookmarkFolders' content list.
        /// </summary>
        /// <returns>An IReadOnlyList of Bookmarks.</returns>
        public IReadOnlyList<Bookmark> GetBookmarksFromContents()
        {
            var x = new List<Bookmark>();
            foreach (Bookmark b in Contents_)
            {
                x.Add(b);
            }
            return x;
        }

        /// <summary>
        /// Gets an IReadOnlyList of BookmarkFolders from this BookmarkFolders' content list.
        /// </summary>
        /// <returns>An IReadOnlyLi.st of BookmarkFolders.</returns>
        public IReadOnlyList<BookmarkFolder> GetBookmarkFoldersFromContents()
        {
            var x = new List<BookmarkFolder>();
            foreach (BookmarkFolder b in Contents_)
            {
                x.Add(b);
            }
            return x;
        }

        /// <summary>
        /// Gets an IReadOnlyList of IBookmarkable classes.
        /// </summary>
        /// <returns>Bookmarkable typed classes.</returns>
        [Obsolete()]
        public IReadOnlyList<IBookmarkable> GetBookmarkableFromContents()
        {
            return Contents_;
        }
    }

    public sealed class BookmarkManager
    {
        public List<IBookmarkable> bookmarks = null;
        public BookmarkManager INSTANCE = null;

        public BookmarkManager()
        {
            INSTANCE = this;
            bookmarks = new List<IBookmarkable>();
        }

        /// <summary>
        /// Adds a Bookmark to the internal bookmark registry.
        /// </summary>
        /// <param name="bookmark">The bookmark to add.</param>
        public void AddBookmark(Bookmark bookmark)
        {
            bookmarks.Add(bookmark);
        }

        /// <summary>
        /// Adds a BookmarkFolder to the internal bookmark registry.
        /// </summary>
        /// <param name="bookmarkFolder">The BookmarkFolder to add.</param>
        public void AddBookmark(BookmarkFolder bookmarkFolder)
        {
            bookmarks.Add(bookmarkFolder);
        }

        /// <summary>
        /// Adds an array of Bookmarks to the internal bookmark registry.
        /// </summary>
        /// <param name="bookmarks">The array of Bookmarks to add.</param>
        public void AddBookmarks(Bookmark[] bookmarks)
        {
            foreach (Bookmark b in bookmarks)
            {
                AddBookmark(b);
            }
        }

        /// <summary>
        /// Adds an array of BookmarkFolders to add to the internal bookmark registry.
        /// </summary>
        /// <param name="bookmarks">The array of BookmarkFolders to add.</param>
        public void AddBookmarks(BookmarkFolder[] bookmarks)
        {
            foreach (BookmarkFolder bf in bookmarks)
            {
                AddBookmark(bf);
            }
        }

        /// <summary>
        /// Removes a Bookmark from the internal bookmark registry.
        /// </summary>
        /// <param name="bookmark">The Bookmark to add.</param>
        public void RemoveBookmark(Bookmark bookmark)
        {
            bookmarks.Remove(bookmark);
        }

        /// <summary>
        /// Removes a BookmarkFolder from the internal bookmark registry.
        /// </summary>
        /// <param name="bookmarkFolder">The BookmarkFolder to add.</param>
        public void RemoveBookmark(BookmarkFolder bookmarkFolder)
        {
            bookmarks.Remove(bookmarkFolder);
        }

        /// <summary>
        /// Removes an array of Bookmarks from the internal bookmark registry.
        /// </summary>
        /// <param name="bookmarks">The array of Bookmarks to add.</param>
        public void RemoveBookmarks(Bookmark[] bookmarks)
        {
            foreach (Bookmark b in bookmarks)
            {
                RemoveBookmark(b);
            }
        }

        /// <summary>
        /// Removes an array of BookmarkFolders from the internal bookmark registry.
        /// </summary>
        /// <param name="bookmarks">The array of BookmarkFolders to add.</param>
        public void RemoveBookmarks(BookmarkFolder[] bookmarks)
        {
            foreach (BookmarkFolder bf in bookmarks)
            {
                RemoveBookmark(bf);
            }
        }

        /// <summary>
        /// Gets a Bookmark with the following name, or gets the first instance of the Bookmark with the following name.
        /// </summary>
        /// <param name="name">The name of Bookmark to get.</param>
        /// <returns>The instance of the Bookmark with the specified name.</returns>
        public Bookmark GetBookmark(string name)
        {
            Bookmark bookmark = null;
            foreach (Bookmark b in bookmarks)
            {
                if (b.Name == name)
                {
                    bookmark = b;
                    break;
                }
            }
            return bookmark;
        }

        /// <summary>
        /// Gets the Bookmark with the following ID.
        /// </summary>
        /// <param name="ID">The ID of the Bookmark to get.</param>
        /// <returns>The instance of the Bookmark with the specified ID.</returns>
        public Bookmark GetBookmark(Guid ID)
        {
            Bookmark bookmark = null;
            foreach (Bookmark b in bookmarks)
            {
                if (b.ID == ID)
                {
                    bookmark = b;
                    break;
                }
            }
            return bookmark;
        }

        /// <summary>
        /// Gets a BookmarkFolder with the following name, or gets the first instance of the BookmarkFolder with the following name.
        /// </summary>
        /// <param name="name">The name of the Bookmark to get.</param>
        /// <returns>The instance of the BookmarkFolder with the specified name.</returns>
        public BookmarkFolder GetBookmarkFolder(string name)
        {
            BookmarkFolder folder = null;
            foreach (BookmarkFolder bf in bookmarks)
            {
                if (bf.Name == name)
                {
                    folder = bf;
                    break;
                }
            }
            return folder;
        }

        /// <summary>
        /// Gets a BookmarkFolder with the following ID.
        /// </summary>
        /// <param name="ID">The ID of the Bookmark to get.</param>
        /// <returns>The instance of the BookmarkFolder with the specified ID.</returns>
        public BookmarkFolder GetBookmarkFolder(Guid ID)
        {
            BookmarkFolder folder = null;
            foreach (BookmarkFolder bf in bookmarks)
            {
                if (bf.ID == ID)
                {
                    folder = bf;
                    break;
                }
            }
            return folder;
        }

        /// <summary>
        /// Gets all Bookmarks from the internal bookmark registry as an IReadOnlyList.
        /// </summary>
        /// <returns>An IReadOnlyList of all Bookmarks from the internal bookmark registry.</returns>
        public IReadOnlyList<Bookmark> GetBookmarks()
        {
            return bookmarks as IReadOnlyList<Bookmark>;
        }

        /// <summary>
        /// Gets all BookmarkFolders from the internal bookmark registry as an IReadOnlyList.
        /// </summary>
        /// <returns>An IReadOnlyList of all BookmarkFolders from the internal bookmark registry.</returns>
        public IReadOnlyList<BookmarkFolder> GetBookmarkFolders()
        {
            return bookmarks as IReadOnlyList<BookmarkFolder>;
        }

        /// <summary>
        /// Gets all IBookmarkable type from the internal bookmark registry.
        /// </summary>
        /// <typeparam name="T">The class that extends apon IBookmarkable.</typeparam>
        /// <returns>An IReadOnlyList of IBookmarkable typed classes.</returns>
        [Obsolete()]
        public IReadOnlyList<T> GetBookmarkable<T>() where T: IBookmarkable
        {
            return bookmarks as IReadOnlyList<T>;
        }


    }
}
