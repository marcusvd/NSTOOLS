using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NsTools.Repairs.Basic
{
    class SystemEnginer
    {
        public string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public string _chromeProfile { get; set; }
        public string _fireFoxProfile { get; set; }


        public SystemEnginer()
        {
            _chromeProfile = Path.Combine(userProfile, @"AppData\Local\Google");
        }

        public void test()
        {
            Console.WriteLine(_chromeProfile);
        }






    }
}
