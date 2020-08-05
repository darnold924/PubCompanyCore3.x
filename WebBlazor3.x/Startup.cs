using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using ServiceLayer;
using WebRazor3.x.Models;

namespace WebRazor3.x
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
          
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            //Domain Model
            services.AddTransient<IAuthorDM, AuthorDM>();
            services.AddTransient<IPayRollDM, PayRollDM>();
            services.AddTransient<IArticleDM, ArticleDM>();

            //ServiceLayer
            services.AddTransient<IAuthorSvc, AuthorSvc>();
            services.AddTransient<IPayRollSvc, PayRollSvc>();
            services.AddTransient<IArticleSvc, ArticleSvc>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory)
        {
                        
            app.UseExceptionHandler("/Error");
            
            loggerfactory.AddSerilog();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
