using EffectiveMobileTask;

namespace IpSelector.Interfaces
{
    public interface IFileReader
    {
        Task<List<LogData>> ReadFromFileAsync(string path);
    }
}