using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using reverseJobsBoard.Auth;
using Swashbuckle;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
namespace reverseJobsBoard
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddAuthorization(auth => 
            { 
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder() 
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​) 
                    .RequireAuthenticatedUser().Build()); 
            }); 
            services.AddMvc();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            

            app.UseStaticFiles();


            app.UseJwtBearerAuthentication(new JwtBearerOptions() 
            { 
                TokenValidationParameters = new TokenValidationParameters() 
                { 
                    IssuerSigningKey = TokenAuthOption.Key, 
                    ValidAudience = TokenAuthOption.Audience, 
                    ValidIssuer = TokenAuthOption.Issuer, 
                    // When receiving a token, check that we've signed it. 
                    ValidateIssuerSigningKey = true, 
                    // When receiving a token, check that it is still valid. 
                    ValidateLifetime = true, 
                    // This defines the maximum allowable clock skew - i.e. provides a tolerance on the token expiry time  
                    // when validating the lifetime. As we're creating the tokens locally and validating them on the same  
                    // machines which should have synchronised time, this can be set to zero. Where external tokens are 
                    // used, some leeway here could be useful. 
                    ClockSkew = TimeSpan.FromMinutes(0) 
                } 
            }); 

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller}/{id}"
                );

                
                
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

           
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
