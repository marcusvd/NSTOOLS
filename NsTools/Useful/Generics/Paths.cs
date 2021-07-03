using System;
using System.Collections.Generic;
using System.Text;

namespace NsTools.Useful.Generics
{
    public class Paths
    {

        public string UserProfile(string path)
        {
            string _userProfile = (Environment.OSVersion.Platform == PlatformID.Unix ||
             Environment.OSVersion.Platform == PlatformID.MacOSX)
             ? Environment.GetEnvironmentVariable("HOME")
             : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            return path.Replace("~", _userProfile);
        }



    }
}
