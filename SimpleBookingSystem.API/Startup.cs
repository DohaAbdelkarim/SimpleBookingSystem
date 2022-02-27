using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleBookingSystem.API.Infrastructure;
using SimpleBookingSystem.API.Infrastructure.Contracts;
using SimpleBookingSystem.API.Infrastructure.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace SimpleBookingSystem.API
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
            services.AddControllers().AddFluentValidation(fvc =>
                 {
                     fvc.RegisterValidatorsFromAssemblyContaining<Startup>();
                     fvc.ConfigureClientsideValidation(enabled: false);
                 });

            services.Configure<SimpleBookingSystemContext>(Configuration);
            services.AddDbContext<SimpleBookingSystemContext>(options => options.UseSqlite(Configuration.GetConnectionString("SimpleBookingSystemDB")));
           
            services.AddAutoMapper(Assembly.GetEntryAssembly(), typeof(Startup).Assembly);

            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMailService, MailService>();

            services.Configure<SwaggerUIOptions>(Configuration.GetSection("SwaggerUI"));
            services.Configure<SwaggerGenOptions>(Configuration.GetSection("SwaggerGen"));
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("CorsPolicy");
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