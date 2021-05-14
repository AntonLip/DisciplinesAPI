using DisciplinesAPI.DataAccess;
using DisciplinesAPI.Models.SettingsClass;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Threading.Tasks;

namespace DisciplinesAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            services.Configure<DbSettings>(_configuration.GetSection(
                nameof(DbSettings)));

            services.AddCors(setup =>
            {
                setup.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.SetIsOriginAllowed(origin => true);
                    policy.AllowCredentials();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0",
                    Title = "Disciplines API 1.0",
                });

            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddDbContextPool<AppDbContext>(opts =>
                opts.UseSqlServer(_configuration["ConnectionString:Str"]));



            services.AddLessonTypeTransient();
            services.AddDisciplinesTransient();
            services.AddLessonTransient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Disciplines API 1.0");
            }
           );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/swagger/");
                    return Task.CompletedTask;
                    
                });
                endpoints.MapControllers();
            });
        }
    }
}
