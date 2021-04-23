using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using ToDo.Api.Middlewares;
using ToDo.Application.Filters;
using ToDo.Application.Validators;
using ToDo.Domain.Settings;
using ToDo.Infrastructure.IoC;

namespace ToDo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = new AppSettings(Configuration);
            services.AddSingleton(options => appSettings);

            services
                .ConfigureContext(appSettings.ConnectionStringDefault)
                .ConfigureServices()
                .ConfigureRepositories()
                .ConfigureAutoMapper()
                .ConfigureCors();

            services
                .AddControllers(options => options.Filters.Add(typeof(ModelValidationFilter)))
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo Book Store Api", Version = "v1" });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger()
                   .UseSwaggerUI(options =>
                   {
                       options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                   });
            }
            else
            {
                app.UseHsts();
            }

            app
              .UseStaticFiles()
              .UseRouting()
              .UseCors("CorsPolicy")
              .UseMiddleware(typeof(JwtMiddleware))
              .UseMiddleware(typeof(ErrorHandlingMiddleware))
              .UseHttpsRedirection()
              .UseAuthentication()
              .UseAuthorization()
              .UseEndpoints(options =>
              {
                  options.MapControllers();
              });
        }
    }
}
