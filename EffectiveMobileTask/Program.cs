using System.CommandLine;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EffectiveMobileTask
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var fileOption = new Option<FileInfo?>(
                name: "--file",
                description: "The file to read and display on the console.");

            var rootCommand = new RootCommand("Sample app for System.CommandLine");
            rootCommand.AddOption(fileOption);

            rootCommand.SetHandler((file) =>
            {
                ReadFile(file!);
            },
                fileOption);

            return await rootCommand.InvokeAsync(args);
        }

        static void ReadFile(FileInfo file)
        {
            File.ReadLines(file.FullName).ToList()
                .ForEach(line => Console.WriteLine(line));
        }




        public async Task<List<AccessLogData>> ReadFromFile(string path)
        {
            List<AccessLogData> logs = new();
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
                    logs.Add(new AccessLogData(ipAddress, dateTime).ipAddress.); 
                }
            }
            return logs;
        }

        public record AccessLogData(IPAddress ipAddress, DateTime dateTime)
        {         
            public IPAddress IpAddress {  get; init; } = ipAddress;

            public DateTime DateTime { get; init; } = dateTime;
        }


        public IEnumerable<CounterRequestsFromIp> GetNeededRequests(Options options)
        {

        }

        public class SelectorsOptions
        {
            public IPAddress AddressStart { get; set;}

            public 
        }

        public async Task WriteToFile(string path, List<CounterRequestsFromIp> counters)
        {
            using (StreamWriter writer = new(path, false))
            {
                foreach(var counter in counters)
                {
                    await writer.WriteLineAsync(counter.ToString());
                }
            }
        }

        public class CounterRequestsFromIp(IPAddress ipAddress)
        {
            public IPAddress IpAddress { get; private set; } = ipAddress;

            public int CountOfRequests {  get; set; }

            public override string ToString()
                => $"{IpAddress}:{CountOfRequests}";
        }


    }
}
