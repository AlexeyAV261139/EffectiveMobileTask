using EffectiveMobileTask;
using System.Net;

namespace IpSelector.WorkWithFiles
{
    public class LogsReader
    {
        public static async Task<List<LogData>> ReadAsync(string path)
        {
            List<LogData> logsData = new();
            using (StreamReader reader = new(path))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    logsData.Add(GetLogData(line));
                }
            }
            return logsData;
        }

        private static LogData GetLogData(string line)
        {
            var dates = line.Split(':');
            if (!IPAddress.TryParse(dates[0], out IPAddress? ipAddress) || ipAddress is null)
                throw new InvalidCastException("Invalid ip address value");
            if (!DateTime.TryParse(dates[1], out DateTime dateTime))
                throw new InvalidCastException("Invalid date value");
            return new LogData(ipAddress, dateTime);
        }
    }
}