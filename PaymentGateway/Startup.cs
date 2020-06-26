using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace PaymentGateway
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
            services.Configure<KestrelServerOptions>(
                Configuration.GetSection("Kestrel"));
            services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config =>
                {
                    var secretBytes = Encoding.UTF8.GetBytes(SecurityConstants.Secret);
                    var key = new SymmetricSecurityKey(secretBytes);

                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = SecurityConstants.Issuer,
                        ValidAudience = SecurityConstants.Audience,
                        IssuerSigningKey = key,
                    };
                });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
