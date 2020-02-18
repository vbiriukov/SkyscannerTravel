using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SkyscannerTravel.Helpers
{
    public class FileHelper
    {
        public static async Task<R> GetData<R>(string folderName, string fileName) where R : new()
        {
            R response = new R();

            string path = Path.Combine(folderName, fileName);

            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    var reader = new StreamReader(fileStream, Encoding.UTF8);
                    string jsonString = await reader.ReadToEndAsync();
                    response = JsonConvert.DeserializeObject<R>(jsonString);

                    reader.Close();
                    fileStream.Close();
                }
            }

            return response;
        }

        public static async Task SaveData(string folderName, string fileName, object model)
        {

            string path = Path.Combine(folderName, fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            using (var reader = new StreamWriter(fileStream, Encoding.UTF8))
            {
                string data = JsonConvert.SerializeObject(model);
                await reader.WriteLineAsync(data);

                reader.Close();
                fileStream.Close();
            }
        }


        public static bool IsFileModifiedMoreThanDays(string file, int days)
        {
            days = days > 0 ? -days : days;
            DateTime dateTime = DateTime.Now.AddDays(days);

            if (!File.Exists(file))
            {
                return false;
            }

            DateTime lastWriteTime = File.GetLastWriteTime(file);
            return lastWriteTime > dateTime;
        }
    }
}
