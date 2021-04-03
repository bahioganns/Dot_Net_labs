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
            // Mapper
            services.AddAutoMapper(typeof(Startup));

            // DataAccess
            services.AddDbContext<NotesAppContext>();
            services.Add(new ServiceDescriptor(typeof(IUserDataAccess), typeof(UserDataAccess), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteDataAccess), typeof(NoteDataAccess), ServiceLifetime.Scoped));

            // User Services BLL
            services.Add(new ServiceDescriptor(typeof(IUserCreateService), typeof(UserService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserGetService),    typeof(UserService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserUpdateService), typeof(UserService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserDeleteService), typeof(UserService), ServiceLifetime.Scoped));

            // Note Services BLL
            services.Add(new ServiceDescriptor(typeof(INoteCreateService), typeof(NoteService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteGetService),    typeof(NoteService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteUpdateService), typeof(NoteService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteDeleteService), typeof(NoteService), ServiceLifetime.Scoped));

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
