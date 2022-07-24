using AutoMapper;
using BL;
using DL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer
{

    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileUploadMime = "multipart/form-data";
            if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
                return;

            var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
            operation.RequestBody.Content[fileUploadMime].Schema.Properties =
                fileParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
                {
                    Type = "string",
                    Format = "binary"
                });
        }
    }

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Volunteer", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
                c.OperationFilter<SwaggerFileOperationFilter>();
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<VolunteerContext>(options => options.UseSqlServer
          (
               Configuration.GetConnectionString("miriam")
           ), ServiceLifetime.Scoped) ;
            services.AddScoped<IFamilyDL, FamilyDL>();
            services.AddScoped<IFamilyBL, FamilyBL>();
            services.AddScoped<ICommentDL, CommentDL>();
            services.AddScoped<ICommentBL, CommentBL>();
            services.AddScoped<ISpecialProjectDL, SpecialProjectDL>();
            services.AddScoped<ISpecialProjectBL, SpecialProjectBL>();
            services.AddScoped<IVolunteeringDL, VolunteeringDL>();
            services.AddScoped<IVolunteeringBL, VolunteeringBL>();
            services.AddScoped<IReportDL, ReportDL>();
            services.AddScoped<IReportBL, ReportBL>();
            services.AddScoped<IStudentDL, StudentDL>();
            services.AddScoped<IStudentBL, StudentBL>();
            services.AddScoped<IGradeDL, GradeDL>();
            services.AddScoped<IUserDL,UserDL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IPasswordHashHelperBL, PasswordHashHelperBL>();
            services.AddScoped<IstudentsVolunteeringBL, studentsVolunteeringBL>();
            services.AddScoped<IstudentsVolunteeringDL, studentsVolunteeringDL>();
            services.AddScoped<IVolunteerTypeBL, VolunteerTypeBL>();
            services.AddScoped<IVolunteerTypeDL, VolunteerTypeDL>();
            services.AddScoped<IAbsentDL, AbsentDL>();
            services.AddScoped<IAbsentBL, AbsentBL>();


            //services.AddScoped<Itry2,try2>();

            services.AddResponseCaching();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("key").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
          
            
            logger.LogInformation("hi the server is up");
            app.UseLoggerMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Volunteer v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.Map("/api", app1 =>
            {
                app1.UseRouting();
                app1.UseRatingMiddleware();
                app1.UseAuthorization();
                app.UseResponseCaching();

                app.Use(async (context, next) =>
                {
                    context.Response.GetTypedHeaders().CacheControl =
                        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                        {
                            Public = true,
                            MaxAge = TimeSpan.FromSeconds(10)
                        };
                    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                        new string[] { "Accept-Encoding" };

                    await next();
                });


                app1.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
            app.UseLoggerMiddleware();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
