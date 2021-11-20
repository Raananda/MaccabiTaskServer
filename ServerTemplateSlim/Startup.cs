using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServerTemplateSlim.BLL;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using Serilog;
using ServerTemplateSlim.Data;
using Microsoft.EntityFrameworkCore;
using ServerTemplateSlim.Model;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;

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

            //Inject ApplicationSettings model from appsetting.json file
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            // BLL      
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IVideoLinksService, VideoLinksService>();
            services.AddScoped<IVideoCategoriesService, VideoCategoriesService>();
            
            //EF
            services.AddDbContext<MaccabiContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=maccabi;Trusted_Connection=True;"));

            // Idenity
            services.AddIdentity<MaccabiUser, IdentityRole>(options =>
            {
                // Password options
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;

            }).AddEntityFrameworkStores<MaccabiContext>();

            #region Jwt Authentication Config
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Maccabi", Version = "v1" });
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
