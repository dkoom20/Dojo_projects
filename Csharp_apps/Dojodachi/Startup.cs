using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Dojodachi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder App, ILoggerFactory LoggerFactory)
        {
            LoggerFactory.AddConsole();
            App.UseDeveloperExceptionPage();
            App.UseSession();
            App.UseStaticFiles();

            App.UseMvc();
        }
    }
}