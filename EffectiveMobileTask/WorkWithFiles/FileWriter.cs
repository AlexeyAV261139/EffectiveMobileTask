using System.Net;

namespace IpSelector.WorkWithFiles
{
    public class FileWriter
    {
        public static async Task WriteToFileAsync(string path, Dictionary<IPAddress, int> addresses)
        {
            using (StreamWriter writer = new(path, false))
            {
                foreach (var address in addresses)
                {
                    await writer.WriteLineAsync($"{address.Key}:{address.Value}");
                }
            }
        }
    }
}
