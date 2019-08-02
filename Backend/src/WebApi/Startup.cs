using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Persistence;
using WebApi.Helpers;

namespace WebApi
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
            services.AddCors();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMediatR(Assembly.Load("ReadModel"), Assembly.Load("WriteModel"));

            services.AddAutoMapper(Assembly.Load("ReadModel"), Assembly.Load("WriteModel"));

            services.AddSingleton<TempData>();

            var connectionString =
                                //Configuration.GetSection("DbConnections:Predictions:AWS:ConnectionString").Value;
                // Configuration.GetSection("DbConnections:Predictions:Somee:ConnectionString").Value;
//                Configuration.GetSection("DbConnections:Predictions:SomeeRecreated:ConnectionString").Value;
                                Configuration.GetSection("DbConnections:Predictions:ElephantSql:ConnectionString").Value;

//            services.AddDbContext<PredictionsContext>(options =>
//                options.UseSqlServer(connectionString));
            
            services.AddDbContext<PredictionsContext>(options =>
                options.UseNpgsql(connectionString));
            
            
        }

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
		.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader()
    		.AllowCredentials());

            app.UseMvc();
        }
    }
}