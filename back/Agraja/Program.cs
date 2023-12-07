using Agraja.CrossCutting.Configuration;
using Agraja_API;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Agraja
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<StartUp>();


    }
    
}