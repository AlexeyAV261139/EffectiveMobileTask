using IpSelector.Interfaces;
using System.Net;

namespace EffectiveMobileTask
{
    public class LogAnalyzer
    {        
        public Dictionary<IPAddress, int> GetCountRequestsFromIpAddresses(
            List<LogData> data,
            SelectorsOptions options)
        {
            Dictionary<IPAddress, int> addresses = new();
            foreach (var line in data)
            {
                if (options.CheckForCompliance(line))
                {
                    if (!addresses.ContainsKey(line.IpAddress))
                        addresses.Add(line.IpAddress, 0);
                    addresses[line.IpAddress]++;
                }
            }
            return addresses;
        }
    }
}
