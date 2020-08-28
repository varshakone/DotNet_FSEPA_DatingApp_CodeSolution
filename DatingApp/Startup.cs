using System.Threading.Tasks;
using Dating.BusinessLayer.Interface;
using DatingApp.BusinessLayer.Interface;
using DatingApp.BusinessLayer.Service;
using DatingApp.BusinessLayer.Service.Repository;
using DatingApp.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DatingApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<MongoSettings>(options => {

                options.DatabaseName = Configuration.GetSection("MongoConnection:DatabaseName").Value;
                options.Connection = Configuration.GetSection("MongoConnection:Connection").Value;

                if (options.Connection == null && options.DatabaseName == null)
                {
                    options.Connection =
                    "mongodb://user:password@127.0.0.1:27017";
                    options.DatabaseName = "guestbook";
                }
            }
            );


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMongoDBContext, MongoDBContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IDateService, DateService>();
            services.AddScoped<IDateRepository, DateRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
