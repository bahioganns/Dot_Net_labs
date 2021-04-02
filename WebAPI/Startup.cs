using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using AutoMapper;

using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Implementations;
using BLL.Contracts;
using BLL.Implementations;

namespace WebAPI
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
            services.AddAutoMapper(typeof(Startup));

            services.Add(new ServiceDescriptor(typeof(IUserDataAccess), typeof(UserDataAccess), ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IUserCreateService), typeof(UserService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserGetService), typeof(UserService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserUpdateService), typeof(UserService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserDeleteService), typeof(UserService), ServiceLifetime.Scoped));

            services.AddDbContext<NotesAppContext>();

            services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
