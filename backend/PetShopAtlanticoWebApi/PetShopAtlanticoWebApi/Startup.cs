using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PetshopAtlantico.DataBaseAccess.Entity;
using PetshopAtlantico.Services.Implementation;
using PetShopAtlantico.Services.Implementation;
using PetShopAtlantico.Services.Interfaces;
using System;

namespace PetShopAtlanticoWebApi
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
            services.AddControllers();
            

            services.AddCors(options =>
            options.AddPolicy("MyPolicy",
            builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PetShopAtlantico API",
                    Version = "v1",
                    Description = "Api criada para o desafio pratico do Instituto Atlantico",
                    Contact = new OpenApiContact
                    {
                        Name = "Ryoji Kitano",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/RyojiDev"),
                    },
                });
            });


            services.AddDbContext<PetShopDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnect")));

            services.AddTransient<IPetServices, PetServices>();
            services.AddTransient<IPetOwnerServices, PetOwnerServices>();
            services.AddTransient<IPetAccomodationServices, PetAccomodationServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetshopAtlantico API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
