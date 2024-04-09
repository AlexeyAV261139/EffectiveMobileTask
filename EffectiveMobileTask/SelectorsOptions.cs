using System.Net;

namespace EffectiveMobileTask
{
    public class SelectorsOptions(
            DateOnly dateLowerBound,
            DateOnly dateUpperBound,
            IPAddress? addressLowerBound = null,
            IPAddress? addressUpperBound = null)
    {
        public DateOnly DateLowerBound { get; set; } = dateLowerBound;

        public DateOnly DateUpperBound { get; set; } = dateUpperBound;

        public IPAddress? AddressLowerBound { get; set; } = addressLowerBound;

        public IPAddress? AddressUpperBound { get; set; } = addressUpperBound;

        public bool CheckForCompliance(LogData data)
        {
            bool dateCheck = CheckDateBound(data.DateTime);
            bool addressCheck = AddressLowerBound is null ?
                true :
                CheckAddressBound(data.IpAddress);

            return dateCheck && addressCheck;

            bool CheckDateBound(DateTime dateTime)
            {
                bool dateLower = DateOnly.FromDateTime(dateTime) >= DateLowerBound;
                bool dateUpper = DateOnly.FromDateTime(dateTime) <= DateUpperBound;
                return dateLower && dateUpper;
            }

            bool CheckAddressBound(IPAddress ip)
            {
                var address = ip.GetAddressBytes();
                var lowerAddress = AddressLowerBound.GetAddressBytes();
                var upperAddress = AddressUpperBound?.GetAddressBytes();
                for (var i = 0; i < 4; i++)
                {
                    if (address[i] < lowerAddress[i])
                        return false;
                    if (upperAddress is not null && address[i] > upperAddress[i])
                        return false;
                }
                return true;
            }
        }
    }
}
