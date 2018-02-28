using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LightwaveBrowser.Serialization
{
    public static class BinarySerialization
    {
        /// <summary>
        /// Serializes an Object into a binary-based string.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The object serialized to a binary-based string.</returns>
        public static string Serialize(object obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Flush();
                stream.Position = 0;
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        /// <summary>
        /// Deserializes a binary-based string into an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type the binary-based string will be converted to.</typeparam>
        /// <param name="data">The binary-based string that will be coverted to the specified object type.</param>
        /// <returns>The object type that was created from the binary-based string.</returns>
        public static T Deserialize<T>(string data)
        {
            byte[] b = Convert.FromBase64String(data);
            using (var stream = new MemoryStream(b))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
    public static class FileSerializer
    {
        /// <summary>
        /// Serializes a string to a file at the specified path.
        /// </summary>
        /// <param name="path">The path to serialize the string to.</param>
        /// <param name="data">The string that will be serialized to the file.</param>
        public static void Write(string path, string data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(data);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Deserializes a string from a file then returns it.
        /// </summary>
        /// <param name="path">The path to deserialize.</param>
        /// <returns>The string that was taken from the file.</returns>
        public static string Read(string path)
        {
            string output = "";
            StreamReader reader = new StreamReader(path);
            output = reader.ReadToEnd();
            reader.Close();
            return output;
        }
    }
}
