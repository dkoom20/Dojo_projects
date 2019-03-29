using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Time_Display
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Mvc as a service making it available across our entire app
            services.AddMvc();
        }
         
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // Use the Mvc to handle Http requests and responses
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseMvc();
        }
    }
}
