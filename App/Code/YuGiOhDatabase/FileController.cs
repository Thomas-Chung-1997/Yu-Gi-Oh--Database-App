using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOhDatabase
{
    static class FileController
    {
        private static string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string folderName = "/Yu-Gi-Oh!Database";

        // Creates folder for App's data. If folder exists, it will not change anything.
        private static void CreateFolder()
        {
            Directory.CreateDirectory(myDocumentsPath + folderName);
        }

        // Write database to txt file in JSON format.
        public static void WriteCollection(Dictionary<int ,int> collection, string name = "Collection")
        {
            WriteDataToFile<Dictionary<int, int>>(collection, "Collection");
        }

        // Read database from txt file, convert JSON to Card Model object for use.
        public static Dictionary<int,int> ReadCollection(string name = "collection")
        {
            var collection = ReadDataFromFile<Dictionary<int, int>>(name);

            return (collection == null) ? new Dictionary<int, int>() : collection;
        }

        // Write database to txt file in JSON format.
        public static void WriteDatabase(CardCollection data)
        {
            WriteDataToFile<CardCollection>(data, "Database");
        }

        // Read database from txt file, convert JSON to Card Model object for use.
        public static CardCollection ReadDatabase()
        {
            return ReadDataFromFile<CardCollection>("Cards");
        }

        // Write version to txt file in JSON format.
        public static void WriteVersion(VersionModel data)
        {
            WriteDataToFile<VersionModel>(data, "Version");
        }

        // Read version from txt file, convert JSON to Version Model object for use.
        public static VersionModel ReadVersion()
        {
            return ReadDataFromFile<VersionModel>("Version");
        }

        // Generic write to file method. Take specified data and write to file.
        private static void WriteDataToFile<T>(T data, string fileName)
        {
            Trace.WriteLine($"Saving [{fileName}]...");

            string content = JsonConvert.SerializeObject(data, Formatting.Indented);

            CreateFolder();

            try
            {
                using (StreamWriter sw = File.CreateText(myDocumentsPath + folderName + "/" + fileName))
                {
                    sw.WriteLine(content);
                }

                Trace.WriteLine($"[{fileName}] saved successfully.");
            }
            catch(Exception ex)
            {
                Trace.WriteLine($"Was unable to save [{fileName}] to file.");
            }
        }
        
        // Generic read file method. Will take a name and read from that file, convert JSON to specified object and return.
        private static T ReadDataFromFile<T>(string fileName)
        {
            Trace.WriteLine($"Reading [{fileName}]...");

            if (File.Exists(myDocumentsPath + folderName + "/" + fileName))
            {
                try
                {
                    using (StreamReader text = File.OpenText(myDocumentsPath + folderName + "/" + fileName))
                    {
                        using (JsonTextReader reader = new JsonTextReader(text))
                        {
                            var content = JToken.ReadFrom(reader).ToObject<T>();

                            Trace.WriteLine($"[{fileName}] found.");

                            return content;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"[{fileName}] is corrupted : " + ex.Message);

                    return default(T);
                }
            }
            else
            {
                Trace.WriteLine($"[{fileName}] was not found on system.");

                return default(T);
            }
        }
    }
}
