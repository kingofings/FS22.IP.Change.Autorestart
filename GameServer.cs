using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS22.IP.Change.Autorestart;

internal class GameServer
{
    public string? CurrentIP { get; set; }
    public string? LastKnownIP { get; set; }

    public Task<bool> IsGameRunning()
    {
        var p = Process.GetProcessesByName("FarmingSimulator2022Game");

        if (p.Length == 0)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
    public Task<bool> IsDedicatedServerRunning()
    {
        var p = Process.GetProcessesByName("dedicatedServer");

        if (p.Length == 0)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
}
