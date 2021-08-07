using Microsoft.Win32;

namespace NsTools.Os.ConfigsOS.Interfaces
{
    public interface IConnectivity
    {
         bool Firewall(bool onOff);
         bool Ipv6Cia(bool onOff);
         bool RemoteConnection(bool onOff);
         string GetActiveNetAdapterName();
    }
}