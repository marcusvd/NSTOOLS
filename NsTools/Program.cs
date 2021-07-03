using System.Threading.Tasks;
using NsTools.Apps.Installers;
using NsTools.Apps;
using System;
using NsTools.Useful.Has;
using NsTools.NetWork;
using NsTools.Hardware.Basic;
using System.Net.NetworkInformation;
using System.Linq;
using NsTools.NetWork.GetConfigs;
using System.Management;
using System.Collections;
using NsTools.Repairs.Basic;
using System.IO;
using NsTools.Useful;
using NsTools.Useful.Generics;
using NsTools.Useful.Reg;
using Microsoft.Win32;
using NsTools.Os.Basic.Accounts;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;
using NsTools.NetWork.ClientServer;
using NsTools.Tests;
using NsTools.Tests.Logic;
using NsTools.Os.ConfigsOS.Implementation;

namespace NsTools
{
    class Program
    {



        public static void Main()
        {
            PowerSupply Psupply = new PowerSupply();
            Initializing Init = new Initializing();
            Connectivity Connect = new Connectivity();



            //  Init.Run("LocalMachine"
            //      , @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
            //      ,"Men to be Inicialized"
            //      , @"c:\windows\system32\calc.exe"
            //      , RegistryValueKind.String);

            //SET POWER PLAN TO HIGH
            // System.Console.WriteLine(Psupply.SetHighPerformace());

            //REGISTERING A EXECUTABLE TO RUN WHEN WINDOWS IS LOADING
            //  System.Console.WriteLine(Init.Run("LocalMachine"
            //      , @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
            //      , "Men to be Inicialized"
            //      , @"c:\windows\system32\calc.exe"
            //      , RegistryValueKind.String));

            //Connect.Firewall(false);

            //  foreach (string item in Connect.Ipv6Cia(true))
            //  {
            //   Console.WriteLine(item);
            //  }

            //Console.WriteLine(Connect.Tests());

            // NetworkConnection net = new NetworkConnection();

            //REGISTERING A EXECUTABLE TO RUN WHEN WINDOWS IS LOADING
            System.Console.WriteLine(Connect.RemoteConnection("LocalMachine"
                , @"SYSTEM\ControlSet001\Control\Terminal Server"
                , "fDenyTSConnections"
                , @"0"
                , RegistryValueKind.DWord, "love"));




        }






    }


}
