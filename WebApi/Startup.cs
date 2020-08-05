using System.Net;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebApi3.x
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DAL
            services.AddTransient<IDaoAuthor, DaoAuthor>();
            services.AddTransient<IDaoPayroll, DaoPayroll>();
            services.AddTransient<IDaoArticle, DaoArticle>();

            services.AddDbContext<PublishingCompanyContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddMvc(options =>
            {
                options.Filters.Add(new ErrorHandlingFilter(Configuration));

            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory)
        {
            app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "text/html";
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                if (ex.Error.InnerException != null)
                                {
                                    var err = $"<h1>Error: {ex.Error.Message} </h1>{ex.Error.StackTrace } {ex.Error.InnerException.Message} ";
                                    await context.Response.WriteAsync(err).ConfigureAwait(false);
                                }
                                else
                                {
                                    var err = $"<h1>Error: {ex.Error.Message} </h1>{ex.Error.StackTrace }";
                                    await context.Response.WriteAsync(err).ConfigureAwait(false);
                                }
                            }
                        });
                }
            );

            loggerfactory.AddSerilog();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
