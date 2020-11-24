using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Data;
using Server.Services;

namespace Server
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
            var dbPath = Configuration.GetValue<string>("DataBaseSettings:dbPath");
            var connStr = new SqliteConnectionStringBuilder
                {
                    DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbPath)
                }
               .ToString();
            services.AddDbContext<MainDbContext>(op => op.UseSqlite(connStr))
                    .AddControllers();
            services.AddHttpContextAccessor();
            services.AddScoped<ApplicationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}