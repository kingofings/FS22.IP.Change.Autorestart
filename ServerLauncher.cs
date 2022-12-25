using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace FS22.IP.Change.Autorestart;

internal class ServerLauncher
{
    public string? EpicGamesShortCut { get; set; }
    //public string? EpicGamesDedicatedServerShortCut { get; set; }

    public ServerLauncher()
    {
        dynamic? jsonFile = JsonConvert.DeserializeObject(File.ReadAllText("info.json"));
        if (jsonFile is not null)
        {
            EpicGamesShortCut = jsonFile["shortcut"];
            //EpicGamesDedicatedServerShortCut = jsonFile["shortcutserver"];
        }
    }

    public Task LaunchServer()
    {
        var p = new Process();
        var info = new ProcessStartInfo();

        info.FileName = EpicGamesShortCut;

        p.StartInfo = info;

        p.Start();

        var gameServer = new GameServer();

        return Task.CompletedTask;

        /*while (!await gameServer.IsGameRunning())
        {
            continue;
        }

        p = new Process();

        info = new ProcessStartInfo();
        info.FileName = EpicGamesDedicatedServerShortCut; 
        p.StartInfo = info;
        p.Start();*/
    }
}
