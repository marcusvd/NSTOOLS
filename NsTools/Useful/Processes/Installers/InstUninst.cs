using NsTools.Online;
using NsTools.Useful.Has;
using NsTools.Useful.Processes.Interfaces;
using System.Threading.Tasks;

namespace NsTools.Useful.Processes.Installers
{
    public class InstUninst : IInvoke
    {
        private Download Online { get; set; }
        private Invoke Invoke { get; set; }
        private Installed installedX64LM { get; set; }

        public InstUninst()
        {

        }

        public InstUninst(string path, string args)
        {
            Invoke = new Invoke(path, args);
        }
        public void App()
        {
             Invoke.RunWaitForExitArgs();
        }

        

        public void Uninstall(string path, string args)
        {
            Invoke = new Invoke(path, args);
            //Invoke.InvokeProc();
            Invoke.RunWaitForExitArgs();
        }

        public async Task AppOnline(string urlToDown, string downFileTarget)
        {
            Online = new Download(urlToDown, downFileTarget);
            await Online.GetThis();
        }
        public string GetStringUninstallExe(string name, string registryHive, string regKey, string propertyName)
        {
            installedX64LM = new Installed(registryHive, regKey, propertyName);
            return installedX64LM.SearchUninstallStringExe(name);
        }
        public string GetStringUninstallMsi(string name, string registryHive, string regKey, string propertyName)
        {
            installedX64LM = new Installed(registryHive, regKey, propertyName);
            return installedX64LM.SearchUninstallStringExeMsi(name);
        }

        public void RunWaitForExitArgs(string fName, string args)
        {
          
        }

        public void RunWaitForExitArgs()
        {
            throw new System.NotImplementedException();
        }
    }
}
