using WebAPI___Integracion.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebAPI___Integracion.Models;

namespace WebAPI___Integracion
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


            services.Configure<PaisesConf>(Configuration.GetSection("Paises"));
            services.AddTransient<IProcesoRepository, ProcesoRepository>();
            services.AddSingleton<IConfiguration>(Configuration);
            
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc()
            .AddXmlDataContractSerializerFormatters()
                .AddXmlSerializerFormatters() ;
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
