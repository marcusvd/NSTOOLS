using NsTools.Useful.Processes.Installers;
using NsTools.Useful.Generics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NsTools.Apps.Installers
{
    class Office2013
    {
        private OfficeTools _tools;
        private InstUninst _installUninstall;
        private string _destination;
        private string _source;
        private string _proFile;
        private string _setupExe;
        private MsgsApps _msgsApps { get; set; }

        public Office2013()
        {
            _tools = new OfficeTools();
            _installUninstall = new InstUninst();
            _source = _tools.Paths("ZipFile");
            _proFile = _tools.Paths("UserProfile");
            _destination = _tools.Paths("Downloads");
            _setupExe = _tools.Paths("SetupExe");
            _msgsApps = new MsgsApps();
        }

        public async Task DownloadOff2013()
        {
            _msgsApps.WriteMsg("Baixando...");
            await _installUninstall.AppOnline("http://www.nostopti.com/tvirtual/toolbox/instalations/office2013.zip", _destination + @"\Office2013.zip");
            _msgsApps.CleanMsgs();
            _msgsApps.WriteMsg("Preparando a instalação...");
            ExtractOffice2013();
        }
        public void ExtractOffice2013()
        {
            Zip zip = new Zip(_source, _proFile);
            zip.Unzip();
        }

        public void InstallOffice2013()
        {
            InstUninst install = new InstUninst(_setupExe, " /AdminFile auto.msp");
            _msgsApps.WriteMsg("Instalando... Por favor, aguarde!");
            install.App();
        }

    }
}
