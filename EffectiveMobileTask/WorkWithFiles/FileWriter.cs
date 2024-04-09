using EffectiveMobileTask;
using IpSelector.Interfaces;

namespace IpSelector.WorkWithFiles
{
    public class FileWriter : IFileWriter
    {
        public async Task WriteToFileAsync(string path, List<CounterRequestsFromIp> counters)
        {
            using (StreamWriter writer = new(path, false))
            {
                foreach (var counter in counters)
                {
                    await writer.WriteLineAsync(counter.ToString());
                }
            }
        }
    }
}
