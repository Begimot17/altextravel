﻿using AltexTravel.API.Amadeus;
using AltexTravel.API.DAL;
using AltexTravel.API.DAL.QueryHandlers.Features.Locations;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AltexTravel.API
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
            services.AddSingleton(Configuration.GetSection("AmadeusConfiguration").Get<AmadeusConfiguration>());
            services.AddSingleton<AmadeusManager>();

            //Add MediatR
            services.AddMediatR(typeof(LocationQueryHandler));

                //AddSwagger
                services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "AltexTravel.API - API HTTP API",
                    Version = "v1",
                    Description = "The Catalog Microservice HTTP API. This is a Data-Driven/CRUD microservice sample",
                    TermsOfService = "Terms Of Service"
                });
            });

                //Add FluentValidation 

                services.AddMvc()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LocationValidator>());

                //ADD EF
                services.AddDbContext<TravelContext>
                    (options => options.UseSqlServer(Configuration.GetSection("ConnectionStrings:traveldb").Value));
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
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
                var pathBase = Configuration["PathBase"];


                app.UseHttpsRedirection();

                app.UseMvc();

                //AddSwagger
                app.UseStaticFiles();

                //AddSwagger
                app.UseSwagger()
                  .UseSwaggerUI(c =>
                  {
                      c.SwaggerEndpoint("../swagger/v1/swagger.json", "Identity.API");
                      c.RoutePrefix = string.Empty;
                  });

                app.UseAuthentication();

            }
        }
    }
