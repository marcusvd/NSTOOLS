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
using NsTools.Online;

namespace NsTools
{
    class Program
    {
        public static void Main()
        {
        // PowerSupply Psupply = new PowerSupply();
        // Initializing Init = new Initializing();
        // Connectivity Connect = new Connectivity();
            Download Downs
            = new Download("https://dl.google.com/tag/s/appguid%3D%7B8A69D345-D564-463C-AFF1-A69D9E530F96%7D%26iid%3D%7BD85AABE3-C608-87E7-D6EC-56D3AD533308%7D%26lang%3Den%26browser%3D4%26usagestats%3D0%26appname%3DGoogle%2520Chrome%26needsadmin%3Dtrue%26ap%3Dx64-stable-statsdef_0%26brand%3DGCEB/dl/chrome/install/GoogleChromeEnterpriseBundle64.zip", @"C:\Users\marcus\Downloads\chrome.zip");


            //Console.WriteLine(Connect.Ipv6Cia(false));


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


            //     Connect.RemoteConnection(true);

        }






    }


}
