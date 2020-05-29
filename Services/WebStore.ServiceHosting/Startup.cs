using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.services.InMemory;
using WebStore.Infrastructure.Services.InCookies;
using WebStore.Infrastructure.Services.InSQL;
using WebStore.Services.Products.InSQL;
using WebStore.Logger;
using WebStore.Interfaces.Services;
using WebStore.Services.Products.InCookies;
using WebStore.Services.Products;

namespace WebStore.ServiceHosting
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
      
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebStoreDB>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WebStore.DAL")));
            services.AddTransient<WebStoreDBInitializer>();

            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<WebStoreDB>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 3;

                opt.User.RequireUniqueEmail = false;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IEmpoyeesData, InMemoryEmployeesData>();
            services.AddScoped<IProductData, SqlProductData>();
            //services.AddScoped<ICartService, CookiesCartService>();
            services.AddScoped<ICartStore, CookiesCartStore>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, SqlOrderService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddSwaggerGen(opt =>
            //{
            //    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "WebStore.API", Version = "v1" });

            //    const string domain_doc_xml = "WebStore.Domain.xml";
            //    const string web_api_doc_xml = "WebStore.ServiceHosting.xml";
            //    const string debug_path = @"bin\debug\netcoreapp3.1";

            //    opt.IncludeXmlComments(web_api_doc_xml);
            //    if (File.Exists(domain_doc_xml))
            //        opt.IncludeXmlComments(domain_doc_xml);
            //    else if (File.Exists(Path.Combine(debug_path, domain_doc_xml)))
            //        opt.IncludeXmlComments(Path.Combine(debug_path, domain_doc_xml));
            //});
            services.AddAuthorization();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDBInitializer db, ILoggerFactory log)
        {
            log.AddLog4Net();
            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAuthorization();
            //app.UseSwagger();
            //app.UseSwaggerUI(opt =>
            //{
            //    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStore.API");
            //    opt.RoutePrefix = string.Empty;
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
