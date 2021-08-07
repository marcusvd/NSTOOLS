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
        public bool Ipv6Cia(bool onOff)
        {
            string NetAdapterName = Helpers.HardwareQuerySingle("SELECT * FROM Win32_NetworkAdapter WHERE NetEnabled = 'TRUE'", "NetConnectionID");
            List<string> protocols = new List<string>();
            protocols.Add("ms_tcpip6");
            protocols.Add("ms_rspndr");
            protocols.Add("ms_lltdio");
            protocols.Add("ms_lldp");

            protocols.ForEach((item) =>
                 {
                     if (onOff)
                     {
                         Helpers.Run("powershell", "Enable-NetAdapterBinding -Name " + GetActiveNetAdapterName() + " -ComponentID " + item);
                     }
                     else
                     {
                         Helpers.Run("powershell", "Disable-NetAdapterBinding -Name " + GetActiveNetAdapterName() + " -ComponentID " + item);
                     }
                 });
            return true;
        }
        public string GetActiveNetAdapterName()
        {
            return Helpers.HardwareQuerySingle
            ("SELECT * FROM Win32_NetworkAdapter WHERE NetEnabled = 'TRUE'", "NetConnectionID");
        }
        public bool RemoteConnection(bool onOff)
        {
            if (onOff)
            {

                try
                {
                    //Enable diasable rdp
                    HelpersConfigsOS OnOff = new HelpersConfigsOS("LocalMachine"
                    , @"SYSTEM\ControlSet001\Control\Terminal Server"
                    , "fDenyTSConnections"
                    , @"0"
                    , RegistryValueKind.DWord, "love");

                    //Enable Cript
                    HelpersConfigsOS Cript = new HelpersConfigsOS("LocalMachine"
                    , @"SYSTEM\ControlSet001\Control\Terminal Server\WinStations\RDP-Tcp"
                    , "UserAuthentication"
                    , @"0"
                    , RegistryValueKind.DWord, "love");

                    OnOff.WriteReg("dword");
                    Cript.WriteReg("dword");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }


            }
            else
            {
                try
                {
                    //Enable diasable rdp
                    HelpersConfigsOS OnOff = new HelpersConfigsOS("LocalMachine"
                    , @"SYSTEM\ControlSet001\Control\Terminal Server"
                    , "fDenyTSConnections"
                    , @"1"
                    , RegistryValueKind.DWord, "love");

                    //Enable Cript
                    HelpersConfigsOS Cript = new HelpersConfigsOS("LocalMachine"
                    , @"SYSTEM\ControlSet001\Control\Terminal Server\WinStations\RDP-Tcp"
                    , "UserAuthentication"
                    , @"1"
                    , RegistryValueKind.DWord, "love");

                    OnOff.WriteReg("dword");
                    Cript.WriteReg("dword");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
    }
}