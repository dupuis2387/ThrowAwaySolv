using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SolvTest.Api.Data.DbContexts;
using SolvTest.Api.Data.Entities;
using SolvTest.Api.Data.Models;
using SolvTest.Api.Data.Repositories;
using SolvTest.Api.Data.Services;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SolvTest.Api
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
            services.AddControllers(config =>
            {
                //let's save consumers from themselves
                config.ReturnHttpNotAcceptable = true;

                /*config.Filters.Add(
                new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                config.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                config.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));*/
            });
            //let's give XML consumers some love too
            //.AddXmlDataContractSerializerFormatters();


            //add our sqlite db context
            services.AddDbContext<MovieContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("AppDatabaseConnectionString"));
            });            

            //typically this would probably be split out into a different class library, along with all the data stuff
            //but since it's a small project, it all lives in here
            //and we can just look at the current assembly to find our mapping profiles
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddScoped<IMovieRepository<MovieModel>, MovieRepository<MovieEntity, MovieModel>>();
            //services.AddScoped<IMovieRepository<ShowTimeModel>, MovieRepository<ShowTimeEntity, ShowTimeModel>>();
            services.AddScoped<IMovieService, MovieService>();


            //Todo: fix this
            /*services.Scan(scan => scan
               .FromAssemblyOf<NewsFeedContext>()
               .AddClasses(classes => classes.AssignableTo<IInstaller>())
               .AsImplementedInterfaces()
               .WithTransientLifetime()
               );*/

            services.AddSwaggerGen(config =>
            {

                

                config.SwaggerDoc("v1",
                    new OpenApiInfo {
                        Title = "SolvTest Api",
                        Version = "v1",
                        Description = "A simple .net core 3 REST Api that lists movies and showtimes",
                        Contact = new OpenApiContact
                        {
                            Name = "Alex Trandaburu"
                        }
                    });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SolvTest Api V1");
                c.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
