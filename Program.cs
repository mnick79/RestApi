using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryDesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi
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
                    webBuilder.UseStartup<Startup>();
                });
    //    public static IHostBuilder CreateHostWithAutofactBuilder(string[] args) =>
    //Host.CreateDefaultBuilder(args)
    //    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    //    .ConfigureWebHostDefaults(webHostBuilder =>
    //    {
    //        webHostBuilder.UseStartup<StartupWithAutofac>();
    //    });
    }
}
