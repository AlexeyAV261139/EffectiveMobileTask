using EffectiveMobileTask;

namespace IpSelector.Interfaces
{
    public interface IFileWriter
    {
        Task WriteToFileAsync(string path, List<CounterRequestsFromIp> counters);
    }
}