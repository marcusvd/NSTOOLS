
using System.Collections.Generic;

namespace NsTools.NetWork.GetConfigs
{
    public class BasicNetWorkInformation
    {
        private Ip _ip { get; set; }

        public BasicNetWorkInformation()
        {
          _ip = new Ip();
        }
        //Get IP address of  network adapter active
        public List<string> ShowIp()
        {
            return _ip.GetIP();
        }

        public List<string> ShowDefaulGatway()
        {
            return _ip.GetDefaultGatway();
        }
        public List<string> Domain()
        {
            return _ip.Domain();
        }
        public List<string> Dns()
        {
            return _ip.Dns();
        }

        public string AssDhcpServer()
        {
            return _ip.ActDhcpServer();
        }
        public string AssActiveAdapterName()
        {
            return _ip.ActActiveAdapterName();
        }
        public string AssMac()
        {
            return _ip.Mac();
        }

        public bool AssDhcpEnabled()
        {
            return _ip.ActDhcpEnabled();
        }
        public override string ToString()
        {
            return "IP: " + ShowIp() +
                   " GATWAY: " + ShowDefaulGatway();
              
        }






    }
}
