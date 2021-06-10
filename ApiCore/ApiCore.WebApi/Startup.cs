using ApiCore.Application;
using ApiCore.Infrastructure.Persistence;
using ApiCore.Infrastructure.Persistence.Contexts;
using ApiCore.Infrastructure.Shared;
using ApiCore.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;


namespace ApiCore.WebApi
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddPersistenceInfrastructure(_config);
            services.AddSharedInfrastructure(_config);
            services.AddSwaggerExtension();
            services.AddControllersExtension();
            // CORS
            services.AddCorsExtension();
            services.AddHealthChecks();
            // API version
            services.AddApiVersioningExtension();
            // API explorer
            services.AddMvcCore()
                .AddApiExplorer();
            // API explorer version
            services.AddVersionedApiExplorerExtension();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            dbContext.Database.EnsureCreated();

            // Add this line; you'll need `using Serilog;` up the top, too
            app.UseSerilogRequestLogging();
            loggerFactory.AddSerilog();
            app.UseHttpsRedirection();
            app.UseRouting();
            //Enable CORS
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();
            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });
        }
    }
}
