using System.Net;

namespace EffectiveMobileTask
{
    public class CounterRequestsFromIp(IPAddress ipAddress)
    {
        public IPAddress IpAddress { get; private set; } = ipAddress;

        public int CountOfRequests { get; set; }

        public override string ToString()
            => $"{IpAddress}:{CountOfRequests}";
    }
}
