using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS22.IP.Change.Autorestart
{
    internal class ServerKiller
    {
        public Task KillServer()
        {
            foreach (var p in Process.GetProcessesByName("FarmingSimulator2022Game"))
            {
                p.Kill();
            }
            return Task.CompletedTask;
        }
    }
}
