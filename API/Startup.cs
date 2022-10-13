using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPApi.Context;
using TPApi.Repositoties;
using TPDataManager.library.IRepositories;

namespace API
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
            services.AddControllersWithViews();

            services.AddSwaggerGen();

            //add services to container
            services.AddSingleton<DapperContext>(); 
            services.AddScoped<IRepositoryEmployee, RepositoryEmployee>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IEmployeeDepartmentRepositoty, EmployeeDepartmentRepositoty>();
            services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();
            services.AddScoped<ITypeOfEmployeeRepository,TypeOfEmployeeRepository>();
            services.AddScoped<IEmloyeeTypeOfEmployeeRepository,EmloyeeTypeOfEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
