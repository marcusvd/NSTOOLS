using System;
using System.Management;
using System.Net;
namespace NsTools.NetWork.ClientServer
{
    public class RemoteCmd
    {
        private ConnectionOptions _connect;
        private ManagementScope _scope;
        private string _host;
        private string _username;
        private string _pwd;

        public RemoteCmd(string host, string username, string pwd)
        {
            _host = host;
            _username = username;
            _pwd = pwd;
            _connect = new ConnectionOptions();
            _connect.Username = _username;
            _connect.Password = _pwd;
            _scope = new ManagementScope($"\\\\{_host}\\root\\cimv2", _connect);
        }

        public void inf()
        {
            ObjectQuery query = new ObjectQuery(
           "SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(_scope, query);

            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                // Display the remote computer information
                Console.WriteLine("Computer Name : {0}",
                    m["csname"]);
                Console.WriteLine("Windows Directory : {0}",
                    m["WindowsDirectory"]);
                Console.WriteLine("Operating System: {0}",
                    m["Caption"]);
                Console.WriteLine("Version: {0}", m["Version"]);
                Console.WriteLine("Manufacturer : {0}",
                    m["Manufacturer"]);
            }
        }


    }

}
