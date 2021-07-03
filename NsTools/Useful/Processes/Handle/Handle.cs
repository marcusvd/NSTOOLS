using System.Diagnostics;
using System.Threading.Tasks;

namespace NsTools.Useful.Processes.Handle
{
    class Handle
    {
        private Process[] Processes { get; set; }
        private bool Killed { get; set; }
        public Handle()
        {

        }
        public bool KillProcessByName(string name)
        {
            Killed = false;
            Processes = Process.GetProcessesByName(name);
            foreach (Process p in Processes)
            {
                while (!p.HasExited)
                {
                    p.Kill();
                    Killed = true;
                } 
            }
            return Killed;
        }

        public bool Pro(string name)
        {
           
            Processes = Process.GetProcessesByName(name);
            foreach (Process p in Processes)
            {
                while (!p.HasExited)
                {
                    p.Kill();
                    Killed = true;
                }
            }
            return Killed;
        }

       /* public async Task<Process> tt()
        {
          return await KillProcessByName("");
        }*/


    }
}
