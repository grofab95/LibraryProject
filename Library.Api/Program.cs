using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Library.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {                    
                    webBuilder.UseUrls("http://192.168.0.15:4000/");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
