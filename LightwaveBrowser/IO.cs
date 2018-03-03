using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LightwaveBrowser.IO
{
    public struct File
    {
        private FileInfo file;
        private Guid id;

        public File(string path)
        {
            id = Guid.NewGuid();
            file = new FileInfo(path);
        }

        public File(Directory dir, string fileName)
        {
            id = Guid.NewGuid();
            if (fileName.StartsWith("\\") || fileName.StartsWith("/"))
                file = new FileInfo($"{dir.Path}{fileName}");
            else
                file = new FileInfo($@"{dir.ToString()}\{fileName}");
        }

        internal File(FileInfo info)
        {
            id = Guid.NewGuid();
            file = info;
        }

        public string Path => file.FullName;
        public string Name => file.Name;
        public Guid ID => id;

        public bool Exists
        {
            get
            {
                if (file.Exists) return true;
                else return false;
            }
        }

        public Directory Parent => new Directory(file.Directory);

        public void Create()
        {
            if (!Exists)
                file.Create();
        }

        public void Delete()
        {
            if (Exists)
                file.Delete();
        }

        public void Write(string data, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(Path, false))
            {
                writer.Write(data);
                writer.Flush();
                writer.Close();
            }
        }

        public void WriteLine(string data, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(Path, false))
            {
                writer.WriteLine(data);
                writer.Flush();
                writer.Close();
            }
        }

        public void WriteObject(object obj)
        {
            var text = Serialization.BinarySerialization.Serialize(obj);
            WriteLine(Serialization.BinarySerialization.Serialize(obj));
        }

        public T ReadObject<T>()
        {
            return (T) Serialization.BinarySerialization.Deserialize<T>(Read());
        }

        public string Read()
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                var x = reader.ReadToEnd();
                reader.Close();
                return x;
            }
        }

        public void Encrypt()
        {
            Encryption.FileEncryption.EncryptFile(Path, Path);
        }

        public void Decrypt()
        {
            Encryption.FileEncryption.DecryptFile(Path, Path);
        }
    }

    public struct Directory
    {
        private DirectoryInfo directory;
        private Guid id;

        public Directory(string path)
        {
            id = Guid.NewGuid();
            directory = new DirectoryInfo(path);
        }

        internal Directory(DirectoryInfo info)
        {
            id = Guid.NewGuid();
            directory = info;
        }

        public string Path => directory.FullName;
        public string Name => directory.Name;
        public Guid ID => id;

        public bool Exists
        {
            get
            {
                if (directory.Exists) return true;
                else return false;
            }
        }

        public Directory Parent
        {
            get => new Directory(directory.Parent);
        }

        public void Create()
        {
            if (!(Exists))
                directory.Create();
        }

        public void Delete()
        {
            if (Exists)
                directory.Delete();
        }

        public Directory[] GetDirectories()
        {
            List<Directory> dx = new List<Directory>();
            var directories = directory.GetDirectories();
            foreach (DirectoryInfo d in directories)
            {
                dx.Add(new Directory(d));
            }
            return dx.ToArray();
        }

        public Directory[] GetDirectories(string filter, SearchOption searchOption = SearchOption.AllDirectories)
        {
            List<Directory> dx = new List<Directory>();
            var directories = directory.GetDirectories(filter, searchOption);
            foreach (DirectoryInfo d in directories)
            {
                dx.Add(new Directory(d));
            }
            return dx.ToArray();
        }

        public File[] GetFiles()
        {
            List<File> fx = new List<File>();
            var directories = directory.GetFiles();
            foreach (FileInfo f in directories)
            {
                fx.Add(new File(f));
            }
            return fx.ToArray();
        }

        public File[] GetFiles(string filter, SearchOption searchOption = SearchOption.AllDirectories)
        {
            List<File> fx = new List<File>();
            var directories = directory.GetFiles(filter, searchOption);
            foreach (FileInfo f in directories)
            {
                fx.Add(new File(f));
            }
            return fx.ToArray();
        }

        public void CreateSubDirectory(string name)
        {
            directory.CreateSubdirectory(name);
        }

        public void CreateSubDirectory(Directory dir)
        {
            directory.CreateSubdirectory(dir.Path);
        }

        public void Encrypt()
        {
            foreach (File f in GetFiles())
                f.Encrypt();
        }

        public void Decrypt()
        {
            foreach (File f in GetFiles())
                f.Decrypt();
        }

        public static Directory AppData => new Directory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        public static Directory LocalAppData => new Directory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        public static Directory ProgramFiles => new Directory(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
        public static Directory ProgramFilesX86 => new Directory(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
        public static Directory StartMenuFolder => new Directory(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
        public static Directory StartupFolder => new Directory(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        public static Directory Downloads => new Directory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");
    }
}
