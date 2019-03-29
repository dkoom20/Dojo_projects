using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DojoSurvey
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder App, ILoggerFactory LoggerFactory)
        {
            LoggerFactory.AddConsole();
            App.UseDeveloperExceptionPage();
            App.UseStaticFiles();

            App.UseMvc();
        }
    }
}