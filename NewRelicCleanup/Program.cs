using System.Threading;
using NewRelicCleanup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NewRelicCleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("You must supply the api key");
                Environment.Exit(-1);
            }

            string apikey = args[0];
            
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.newrelic.com/");
                client.DefaultRequestHeaders.Add("x-api-key", apikey);
                
                HttpResponseMessage response = client.GetAsync("v2/servers.json").Result;
                
                if (response.IsSuccessStatusCode)
                {
                    var serverList = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
                    var notRespondingServers = serverList.servers.Where(s => !s.reporting).ToList();

                    foreach (var svr in notRespondingServers)
                    {
                        Console.WriteLine("Deleting " + svr.host + " - last reported at " + svr.last_reported_at);
                        

                        var deleteResponse = client.DeleteAsync(string.Format("v2/servers/{0}.json", svr.id)).Result;
                        Console.WriteLine(deleteResponse.Content.ReadAsStringAsync().Result);
                        Thread.Sleep(500);
                        

                    }

                    Console.WriteLine("Number of servers deleted" + notRespondingServers.Count);
                    
                }
                else
                {
                    Console.WriteLine("Check your api key!");
                }
                Console.ReadLine();
            }
        }
    }
}
