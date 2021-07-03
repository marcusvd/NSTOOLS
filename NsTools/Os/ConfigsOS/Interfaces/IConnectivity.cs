using Microsoft.Win32;

namespace NsTools.Os.ConfigsOS.Interfaces
{
    public interface IConnectivity
    {
         bool Firewall(bool onOff);
         string[] Ipv6Cia(bool onOff);
         bool RemoteConnection(string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind, string love);
         string Tests();
    }
}