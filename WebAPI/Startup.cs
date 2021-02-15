using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddControllers();
            services.AddSingleton<ICarService, CarManager>();  // bu newleme gerektiginde newler
            services.AddSingleton<ICarDal, EfCarDal>();
            services.AddSingleton<IColorService, ColorManager>();  // bu newleme gerektiginde newler
            services.AddSingleton<IColorDal, EfColorDal>();
            services.AddSingleton<IBrandService, BrandManager>();  // bu newleme gerektiginde newler
            services.AddSingleton<IBrandDal, EfBrandDal>();
            services.AddSingleton<IRentalService, RentalManager>();  // bu newleme gerektiginde newler
            services.AddSingleton<IRentalDal, EfRentalDal>();
            services.AddSingleton<IUserService, UserManager>();  // bu newleme gerektiginde newler
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<ICustomerService, CustomerManager>();  // bu newleme gerektiginde newler
            services.AddSingleton<ICustomerDal, EfCustomerDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
