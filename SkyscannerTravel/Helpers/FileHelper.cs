using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SkyscannerTravel.Helpers
{
    public class FileHelper
    {
        private static object _lockerRead = new object();
        private static object _lockerWrite = new object();

        private static R GetData<R>(string folderName, string fileName) where R : new()
        {
            R response = new R();

            string path = Path.Combine(folderName, fileName);

            if (File.Exists(path))
            {
                lock (_lockerRead)
                {
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        var reader = new StreamReader(fileStream, Encoding.UTF8);
                        string jsonString = reader.ReadToEnd();
                        response = JsonConvert.DeserializeObject<R>(jsonString);

                        reader.Close();
                        fileStream.Close();
                    }
                }
            }

            return response;
        }

        public static async Task<R> GetDataAsync<R>(string folderName, string fileName) where R : new()
        {
            return await Task.Run(() => GetData<R>(folderName, fileName));
        }

        private static void SaveData(string folderName, string fileName, object model)
        {
            string path = Path.Combine(folderName, fileName);

            lock (_lockerWrite)
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                using (var reader = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    string data = JsonConvert.SerializeObject(model);
                    reader.WriteLine(data);

                    reader.Close();
                    fileStream.Close();
                }
            }
        }


        public static Task SaveDataAsync(string folderName, string fileName, object model)
        {
            return Task.Run(() => SaveData(folderName, fileName, model));
        }

        //public static bool IsFileModifiedMoreThanDays(string file, int days)
        //{
        //    days = days > 0 ? -days : days;
        //    DateTime dateTime = DateTime.Now.AddDays(days);

        //    if (!File.Exists(file))
        //    {
        //        return false;
        //    }

        //    DateTime lastWriteTime = File.GetLastWriteTime(file);
        //    return lastWriteTime > dateTime;
        //}
    }
}
