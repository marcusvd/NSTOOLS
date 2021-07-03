using Microsoft.Win32;
using NsTools.Os.ConfigsOS.Helpers;
using NsTools.Os.ConfigsOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace NsTools.Os.ConfigsOS.Implementation
{


    public class Connectivity : IConnectivity
    {

        HelpersConfigsOS Helpers = new HelpersConfigsOS();
        public bool Firewall(bool onOff)
        {
            List<string> environment = new List<string>();
            environment.Add("Domain");
            environment.Add("Private");
            environment.Add("Public");
            if (onOff)
            {
                environment.ForEach((item) =>
                {
                    //Console.WriteLine("Set-NetFirewallProfile -Profile " + item + " -Enabled false" + "IF");
                    Helpers.Run("powershell", "Set-NetFirewallProfile -Profile " + item + " -Enabled true");
                });
            }
            else
            {
                environment.ForEach((item) =>
            {
                // Console.WriteLine("Set-NetFirewallProfile -Profile " + item + " -Enabled false" + "ELSE");
                Helpers.Run("powershell", "Set-NetFirewallProfile -Profile " + item + " -Enabled false");
            });
            }
            return true;
        }

        public string[] Ipv6Cia(bool onOff)
        {
            // Disable-NetAdapterBinding -Name $Adapters.Name -ComponentID $Protocol -ErrorAction SilentlyContinue
            return Helpers.HardwareQueryMany("SELECT * FROM Win32_NetworkAdapter WHERE NetEnabled = 'TRUE'", "SystemName").ToArray();

        }
        public string Tests()
        {
            // Disable-NetAdapterBinding -Name $Adapters.Name -ComponentID $Protocol -ErrorAction SilentlyContinue
            // return Helpers.HardwareQueryMany("SELECT * FROM Win32_NetworkAdapter WHERE NetEnabled = 'TRUE'", "SystemName").ToArray();
            return Helpers.HardwareQuerySingle("SELECT * FROM Win32_NetworkLoginProfile WHERE Persistent = 'TRUE'", "LocalName");
        }

        public bool RemoteConnection(string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind, string love)
        {

           try
            {
                HelpersConfigsOS Helpers = new HelpersConfigsOS(baseRegistry,
                registryPath,
                propertyName,
                volumeName,
                registryValueKind, love);
                
                Helpers.WriteReg("dword");
                return true;
            }
            catch (Exception)
            {
                return false;
            }

           
        }
    }
}