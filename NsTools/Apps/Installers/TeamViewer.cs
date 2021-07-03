using NsTools.Useful.Has;
using NsTools.Useful.Processes.Installers;
using System;
using System.IO;
using System.Threading.Tasks;
using NsTools.Useful.Generics;
namespace NsTools.Apps.Installers
{
    class TeamViewer
    {
        private Exists _exists { get; set; }
        private InstUninst _installUninstall { get; set; }
        private string _userProfile { get; set; }
        private string _destination { get; set; }
        private MsgsApps _msgsApps { get; set; }
        public TeamViewer()
        {
            _msgsApps = new MsgsApps();
            _userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _destination = Path.Combine(_userProfile, "Downloads\\");
        }

        private bool ExecutableExist()
        {

            _exists = new Exists(@"c:\", "TeamViewer.exe");
            return _exists.SearchCheckFileExist();
        }
        private void Uninstall(string uninstallString)
        {
            _installUninstall = new InstUninst();
            _msgsApps.CleanMsgs();
            _msgsApps.WriteMsg("Team Viewer, foi encontrado e esta sendo " +
             "desinstalado. Por favor, aguarde!");
            _installUninstall.Uninstall(uninstallString, "/S");
        }
        private bool UninstallAction()
        {
            bool uninstalled = false;
            _installUninstall = new InstUninst();
            string uninstallString = _installUninstall.GetStringUninstallExe("TeamViewer", "LocalMachine", @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall", "UninstallString");

            if (ExecutableExist())
            {
                _msgsApps.WriteMsg("Localizando alguma instalação do Team Viewer. Por favor, aguarde!");
                Uninstall(uninstallString);

                do
                {
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
            await _installUninstall.AppOnline("https://dl.teamviewer.com/download/version_15x/TeamViewer_Setup.exe", _destination + "TVInstall.exe");
            InstallNow();

        }
        private void InstallNow()
        {
            _installUninstall = new InstUninst(_destination + "\\TVInstall.exe", "/S");
            _msgsApps.WriteMsg("Instalando, Team Viewer. Por favor, aguarde!");
            _installUninstall.App();
            _msgsApps.CleanMsgs();
            _installUninstall = new InstUninst(@"C:\Program Files (x86)\TeamViewer\TeamViewer.exe", "");
            _installUninstall.App();
            _msgsApps.WriteMsg("Instalado, Abra o ícone azul com o nome TeamViewer em sua área de trabalho. Por favor!");

            Console.ReadKey();
        }
        public async Task TeamViewerFix()
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
