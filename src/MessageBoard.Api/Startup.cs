using System.Reflection;
using MessageBoard.Api.Attributes;
using MessageBoard.Daos;
using MessageBoard.Daos.Impl;
using MessageBoard.Services;
using MessageBoard.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<AuthorFilterAttribute>();

            services.AddControllers(options => options.Filters.Add(new GlobalExceptionFilterAttribute()));
            services.AddHealthChecks();

            services.AddOpenApiDocument(cfg => cfg.Title = Assembly.GetExecutingAssembly().GetName().Name);

            services.AddScoped<AuthorHelper>();
            services.AddScoped<IMessageDao, MessageDao>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddDbContext<MessageBoardDbContext>(options => options.UseInMemoryDatabase(databaseName: Configuration["DBName"]));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSwaggerUi3();
            app.UseOpenApi();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
