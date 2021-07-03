using Microsoft.Win32;

namespace NsTools.Os.ConfigsOS.Interfaces
{
    public interface IInitializing
    {
        bool Run(string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind);
        
    }
}