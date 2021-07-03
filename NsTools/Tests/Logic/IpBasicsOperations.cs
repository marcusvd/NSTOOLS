
using System.Collections.Generic;
using System.Management;
using NsTools.Tests.Helpers;
using NsTools.Tests.Interfaces;

namespace NsTools.Tests.Logic
{
    public class IpBasicsOperations : IIpBasicsOperations
    {
        private ManagementObjectSearcher _objSearch { get; set; }
        private List<string> _listReturn { get; set; }
        private PathsParamsArgs _pathsParamsArgs { get; set; }

        public IpBasicsOperations()
        {
            _pathsParamsArgs = new PathsParamsArgs();
            _listReturn = new List<string>();
        }

        public string[] GetIp(string param, string property)
        {
            _objSearch = new ManagementObjectSearcher(new ObjectQuery(param));
            ManagementObjectCollection queryCollection = _objSearch.Get();
            foreach (var qwe in queryCollection)
            {
                PropertyData data1 = qwe.Properties[property];
                string[] T = (string[])data1.Value;
                foreach (string item in T)
                {

                    _listReturn.Add(item);
                }
                break;
            }
            return _listReturn.ToArray();
        }
    }
}
