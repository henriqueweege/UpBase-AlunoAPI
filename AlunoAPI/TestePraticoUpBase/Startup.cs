using AlunoAPI.Data;
using AlunoAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
                    Title = "Teste Prático UpBase - AlunoAPI",
                    Description = "API RESTful criada como requisito avaliativo da fase prática do processo " +
                    "seletivo para vaga de estágio .NET na UpBase. Esta API conta com recursos CRUD, integração com " +
                    "banco de dados MySQL, e recursos extra como senha criptografada e critérios que impedem o cadastro " +
                    "de usuário com dados duplicados.",
                    Contact = new OpenApiContact
                    {
                        Name = "Suporte",
                        Url = new Uri("https://www.linkedin.com/in/henrique-weege-baa287166/"),
                        Email = "henriqueweege@gmail.com"

                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença: GPLv3",
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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Prático UpBase - AlunoAPI 1.0.0"));

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
