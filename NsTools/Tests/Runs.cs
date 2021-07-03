
using NsTools.Tests.Interfaces;
namespace NsTools.Tests
{

    public class Runs
    {
        private IIpBasicsOperations _iipBasicsOperations;
        public Runs(IIpBasicsOperations iipBasicsOperations)
        {
            _iipBasicsOperations = iipBasicsOperations;
        }

        /*public string[] GetIp()
        {
            return _iipBasicsOperations.GetIp(string param, string property);
        }*/
        public string[] GetDns()
        {
            return _iipBasicsOperations.GetIp("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'", "DNSServerSearchOrder");
        }

    }
}
