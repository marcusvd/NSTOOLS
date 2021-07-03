using System;
using Microsoft.Win32;
using NsTools.Os.ConfigsOS.Helpers;
using NsTools.Os.ConfigsOS.Interfaces;

namespace NsTools.Os.ConfigsOS.Implementation
{

    public class Initializing : IInitializing
    {
        public Initializing()
        {
        }

        public bool Run(string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind)
        {
            try
            {
                HelpersConfigsOS Helpers = new HelpersConfigsOS(baseRegistry,
                registryPath,
                propertyName,
                volumeName,
                registryValueKind);
                Helpers.WriteReg();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}