using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS22.IP.Change.Autorestart
{
    internal class PublicIP
    {
        private readonly HttpClient _client = new HttpClient();
        public async Task<string> GetPublicIP()
        {
            try
            {
                var response = await _client.GetAsync("https://icanhazip.com/");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception pokemon) 
            {
                Console.WriteLine(pokemon.Message);
                return "noresponse";
            } 
        }
    }
}
