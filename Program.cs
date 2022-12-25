using FS22.IP.Change.Autorestart;

internal class Program
{
    public static async Task Main()
    {
        var server = new GameServer();
        var launcher = new ServerLauncher();
        var ip = new PublicIP();
        var killer = new ServerKiller();

        if (!await server.IsGameRunning())
        {
            Console.WriteLine("Game Not running!");

            //Just in case!
            await killer.KillServer();

            await launcher.LaunchServer();
        }

        string IP = await ip.GetPublicIP();
        if (IP == "noresponse") 
        {
            Console.WriteLine("Failed to get public IP, please check your internet connection.\nThis window will terminate in 10 seconds.");
            await Task.Delay(10000);
            return;
        }

        server.CurrentIP = IP;
        server.LastKnownIP = IP;

        while (true)
        {
            if (server.CurrentIP != server.LastKnownIP)
            {
                //Wait for the server to have fully saved the game
                Console.WriteLine("Public IP changed! Waiting 15.1 Minutes until restarting to allow the server to save the game!");
                await Task.Delay(906000);

                await killer.KillServer();

                server.LastKnownIP = server.CurrentIP;

                await launcher.LaunchServer();
            }

            string buffer = await ip.GetPublicIP();

            if (buffer == "noresponse")
            {
                Console.WriteLine("No response when fetching public ip, did we loose connection? Trying again in 5 minutes");
            }
            else
            {
                server.CurrentIP = buffer;
                Console.WriteLine($"Current Public IP: {server.CurrentIP} {DateTime.Now}");
            }

            //Wait 5 minutes to run this again
            await Task.Delay(300000);
        }
    }
}