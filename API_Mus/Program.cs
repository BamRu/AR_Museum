using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace API_Mus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            configureWebHostCallback += configureWebHost;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
		{
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

            return hostBuilder.ConfigureWebHostDefaults(configureWebHostCallback);
        }

        public static Action<IWebHostBuilder> configureWebHostCallback;


        public static void configureWebHost(IWebHostBuilder webHostBuilder)
		{
            webHostBuilder.UseStartup<Startup>();
		}
    }
}
