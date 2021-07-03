using System;
using System.IO;
using System.Threading.Tasks;
using NsTools.Useful.Has;
using NsTools.Useful.Processes.Installers;
using NsTools.Useful.Generics;
using NsTools.Useful.Processes.Handle;

namespace NsTools.Apps.Installers
{
    class AnyDesk
    {
        private Exists _exists { get; set; }
        private InstUninst _installUninstall { get; set; }
        private string _userProfile { get; set; }
        private string _destination { get; set; }
        private MsgsApps _msgsApps { get; set; }
        private Handle _processHandle { get; set; }

        public AnyDesk()
        {
            _msgsApps = new MsgsApps();
            _userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _destination = Path.Combine(_userProfile, "Downloads\\");
        }

        private bool ExecutableExist()
        {

            _exists = new Exists(@"c:\", "AnyDeskMSI.exe");
            return _exists.SearchCheckFileExist();
        }
        private void Uninstall(string uninstallString)
        {

            _installUninstall = new InstUninst();
            _msgsApps.CleanMsgs();
            _msgsApps.WriteMsg("AnyDesk, foi encontrado e esta sendo " +
             "desinstalado. Por favor, aguarde!");
            _installUninstall.Uninstall("Msiexec", " /" + uninstallString);
        }
        private bool UninstallAction()
        {
            bool uninstalled = false;
            _installUninstall = new InstUninst();
            string uninstallString = _installUninstall.GetStringUninstallMsi("AnyDesk MSI", "LocalMachine", @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall", "DisplayName");
            string args = uninstallString.Substring(13, 39);
            string UninstallArgs = (args += " /qn");

            if (ExecutableExist())
            {
                _msgsApps.WriteMsg("Localizando alguma instalação do AnyDesk. Por favor, aguarde!");
                Uninstall(UninstallArgs);
                do
                {
                    _msgsApps.WriteMsg("Desistalando AnyDesk. Por favor, aguarde!");
                    _msgsApps.CleanMsgs();
                }
                while (ExecutableExist());
                uninstalled = true;
            }
            return uninstalled;
        }
        private async Task GetOnlineExecutableAndInstall()
        {
            _destination = Path.Combine(_userProfile, "Downloads\\");
            _installUninstall = new InstUninst();
            await _installUninstall.AppOnline("https://download.anydesk.com/AnyDesk-CM.msi", _destination + "AnyDesk-CM.msi");
            InstallNow();
        }
        private void InstallNow()
        {
            _installUninstall = new InstUninst(_destination + "AnyDesk-CM.msi", "/qn");
            _msgsApps.WriteMsg("Instalando, AnyDesk. Por favor, aguarde!");
            _installUninstall.App();
            _msgsApps.CleanMsgs();
            _installUninstall = new InstUninst(@"C:\Program Files (x86)\AnyDeskMSI\AnyDeskMSI.exe", "");
            _installUninstall.App();
            _msgsApps.WriteMsg("Instalado, Abra o ícone vermelho com o nome AnyDesk em sua área de trabalho. Por favor!");
        }
        private bool killProcess()
        {
            _processHandle = new Handle();
            return _processHandle.KillProcessByName("AnyDeskMSI");
        }


        public async Task AnyDeskFix()
        {



            if (UninstallAction())
            {
                await GetOnlineExecutableAndInstall();
            }
            else
            {
                await GetOnlineExecutableAndInstall();
            }
        }
    }
}
