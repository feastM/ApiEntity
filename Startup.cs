using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using Users.API.Domain.Repositories;
using Users.API.Domain.Services;
using Users.API.Servicies;

using AutoMapper;
using Users.API.Mapping;
using Users.API.Resources;
using Users.API.Repositories;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Data.Common;

namespace Users.API
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
            /*

            services.AddTransient<DbConnection, SqlConnection>(provider =>
            {
                return new SqlConnection
                {
                    ConnectionString = Configuration.GetConnectionString("DefaultConnection")
                };
            });
           */

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddControllers().AddNewtonsoftJson();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelToResourceProfile());
                mc.AddProfile(new ResourceToModelProfile());
                mc.AddProfile(new ResourceToModelUpdate());
              
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
          
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
