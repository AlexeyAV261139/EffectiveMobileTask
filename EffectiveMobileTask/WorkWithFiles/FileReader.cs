using EffectiveMobileTask;
using IpSelector.Interfaces;
using System.Net;

namespace IpSelector.WorkWithFiles
{
    public class FileReader : IFileReader
    {
        public async Task<List<LogData>> ReadFromFileAsync(string path)
        {
            List<LogData> logsData = new();
            using (StreamReader reader = new(path))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var dates = line.Split(':');
                    if (!IPAddress.TryParse(dates[0], out IPAddress? ipAddress) || ipAddress is null)
                        throw new InvalidCastException("Invalid ip address value");
                    if (!DateTime.TryParse(dates[1], out DateTime dateTime))
                        throw new InvalidCastException("Invalid date value");
                    logsData.Add(new LogData(ipAddress, dateTime));
                }
            }
            return logsData;
        }
    }
}