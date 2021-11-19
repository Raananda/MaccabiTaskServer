using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServerTemplateSlim.BLL;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using ServerTemplateSlim.Infra.Interfaces.DAL;
using ServerTemplateSlim.DAL.MySqlInfraDAL;
using ServerTemplateSlim.Infra.Interfaces.DAL.DbContext;
using ServerTemplateSlim.DAL.DbContext;
using Serilog;

namespace ServerTemplateSlim
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

            // Add services here
            // BLL
            services.AddTransient<IInfraService,InfraService>();
            services.AddTransient<IJsonLocalFileService, JsonLocalFileService>();


            //DAL
            services.AddTransient<IInfraConext, InfraContext>();
            services.AddTransient<IInfraDAL, MySqlInfraDAL>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServerTemplateSlim", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServerTemplateSlim v1"));
            }

            app.UseHttpsRedirection();


            app.UseSerilogRequestLogging();

            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
