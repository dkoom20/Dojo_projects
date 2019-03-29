using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ccard_csharp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
//          if (env.IsDevelopment())
//          {       
//              app.UseDeveloperExceptionPage();
//          }
      
            app.UseMvc();
        }
    }
}