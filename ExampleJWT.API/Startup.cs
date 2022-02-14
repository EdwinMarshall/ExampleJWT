using ExampleJWT.API.Common;
using ExampleJWT.API.Services;
using ExampleJWT.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ExampleJWT.API
{
    public class Startup
    {
        readonly string cors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: cors,
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });

            services.AddControllers();

            IConfigurationSection appSettingsSection = Configuration.GetSection("Jwt");
            //services.Configure<AppSettings>(appSettingsSection);

            // JWT
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Key);
            services.AddAuthentication(d =>
                {
                    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(d =>
                {
                    d.RequireHttpsMetadata = false;
                    d.SaveToken = true;
                    d.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExampleJWT.API", Version = "v1" });
            });

            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampleJWT.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(cors);

            app.UseAuthentication(); // JWT

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
