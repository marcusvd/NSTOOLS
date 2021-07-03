using System.Collections.Generic;
using Microsoft.Win32;

namespace NsTools.Os.ConfigsOS.Helpers
{
    public interface IHelpersConfigsOS
    {
        //run a application
        bool Run(string name, string args);

        //write register
        bool WriteReg();

        List<string> HardwareQueryMany(string strWmi, string property);
        string HardwareQuerySingle(string strWmi, string property);

        bool WriteReg(string DWord);
    }
}