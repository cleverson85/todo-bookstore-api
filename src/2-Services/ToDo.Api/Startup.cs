using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using ToDo.Api.Middlewares;
using ToDo.Application.Filters;
using ToDo.Domain.Interfaces;
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
                    options.UseCamelCasing(false);
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
            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();

                    var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                    await unitOfWork.Commit();
                }
                catch (Exception e)
                {
                    throw e;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
              .UseHttpsRedirection()
              .UseStaticFiles()
              .UseRouting()
              .UseCors("CorsPolicy")
              .UseMiddleware(typeof(JwtMiddleware))
              .UseMiddleware(typeof(ErrorHandlingMiddleware))
              .UseAuthentication()
              .UseAuthorization()
              .UseEndpoints(options =>
              {
                  options.MapControllers();
              })
              .UseSwagger()
              .UseSwaggerUI(options =>
              {
                  options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
              });
        }
    }
}
