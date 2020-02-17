using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SkyscannerTravel.Helpers
{
    public class FileHelper
    {
        public static async Task<R> GetData<R>(string path) where R : new()
        {
            R response = new R();
            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    var reader = new StreamReader(fileStream, Encoding.UTF8);
                    string jsonString = await reader.ReadToEndAsync();
                    response = JsonConvert.DeserializeObject<R>(jsonString);
                }
            }

            return response;
        }

        public static async Task SaveData(string path, object model)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            using (var reader = new StreamWriter(fileStream, Encoding.UTF8))
            {
                string data = JsonConvert.SerializeObject(model);
                await reader.WriteLineAsync(data);

            }
        }
    }
}
