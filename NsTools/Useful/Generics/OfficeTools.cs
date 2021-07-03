using System;
using System.Collections.Generic;
using System.Text;

namespace NsTools.Useful.Generics
{
    public class OfficeTools
    {
        private string  _profile { get; set; }
        private string  _downloadPath { get; set; }
        private string  _setupOfficePathExtracted { get; set; }
        private string _zipOffice2013 { get; set; }
        private string _SetupExeOffice2013 { get; set; }

        public OfficeTools()
        {
            //User profile path below
            _profile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //Download path
            _downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            //where will extracted below
            _setupOfficePathExtracted = _profile + @"\Office2013";
            //zip to be extracted below
            _zipOffice2013 = _downloadPath + @"\Office2013.zip";
            //Install executable below
            _SetupExeOffice2013 = _setupOfficePathExtracted + @"\setup.exe";

        }
        public string Paths(string path)
        {
            switch (path)
            {
                case "UserProfile":
                    return _profile;
                case "Downloads":
                    return _downloadPath;
                case "Office2013ExtractedPath":
                    return _setupOfficePathExtracted;
                case "ZipFile":
                    return _zipOffice2013;
                case "SetupExe":
                    return _SetupExeOffice2013;
            }
            return "Inexistente";
        }          

    }
    
}

   

        
       
