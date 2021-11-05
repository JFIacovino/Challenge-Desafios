using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Challenge_Desafio3.Models;
using Microsoft.EntityFrameworkCore;
using Challenge_Desafio3.Repository;
namespace Challenge_Desafio3
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


            
           
            services.AddSingleton<IConfiguration>(Configuration);
            
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc()
            .AddXmlDataContractSerializerFormatters()
                .AddXmlSerializerFormatters();
            
            services.AddDbContext<ChallengeContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"));
            }
            );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();



            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("wwwroot\\index.html");
            app.UseDefaultFiles(defaultFilesOptions);

            app.UseStaticFiles();

            // app.UseStatusCodePages();
            app.UseMvc();











        }
    }
}
