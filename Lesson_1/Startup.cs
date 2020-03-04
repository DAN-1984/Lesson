using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson_1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lesson_1
{
    public class Startup
    {
        public IConfiguration configuration { get; set; }

        public Startup(IConfiguration configuration) => this.configuration = configuration;

        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ���������� ����� � ���������.
        // �������������� �������� � ��������� ���������� ��. �� �������� https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // ��� �����������
        }

        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ��������� ��������� HTTP- ��������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ��������� Middleware ��� ASP.NET CORE
            // localhost:5000/?token=12345678 
            //app.UseMiddleware<TokenMiddleware>();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!!!");
            //});

            app.UseStaticFiles();
            app.UseDefaultFiles(); // ��������� ��� �����
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/greetings", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllerRoute(
                    name: "default", 
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
