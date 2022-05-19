using AlunoAPI.Data;
using AlunoAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TestePraticoUpBase
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

            services.AddDbContext<AlunoContext>(opts => opts.UseMySQL(Configuration.GetConnectionString("AlunoConnection")));
            services.AddScoped<AlunoService, AlunoService>();
            services.AddScoped<SecurityService, SecurityService>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    
                    Version = "1.0.0",
                    Title = "Practical Evaluation UpBase - StudentAPI",
                    Description = "RESTful API created as an evaluation requirement for the practical phase of the " +
                    "selection process for a .NET internship at UpBase. This API has CRUD functionalities, integration " +
                    "with MySQL database, and the following resources: password saved with encryption, criteria that prevent " +
                    "registration of duplicated data, criteria for creating user name and criteria to create a secure " +
                    "password (minimum: 6 characters; must contain at least one capital letter, one special character and one number).",
                    Contact = new OpenApiContact
                    {
                        Name = "Support",
                        Url = new Uri("https://www.linkedin.com/in/henrique-weege-baa287166/"),
                        Email = "henriqueweege@gmail.com"

                    },
                    License = new OpenApiLicense
                    {
                        Name = "License: GPLv3",
                        Url = new Uri("https://www.gnu.org/licenses/gpl-3.0.html")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practical Evaluation UpBase - StudentAPI 1.0.0"));

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
