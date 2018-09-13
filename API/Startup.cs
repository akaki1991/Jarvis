using Domain.DAO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.ServiceBase;
using Services.Repository.Concrete;
using Services.Repository.Interface;
using Swashbuckle.AspNetCore.Swagger;
using API.Helpers;


namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EMobileContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            #region services
            services.AddScoped<IMobileService, MobileService>();
            
            #endregion
            #region repositories
            services.AddTransient<IPhotoRepository, PhotoRepository>();
            services.AddTransient<IMobileRepository, MobileRepository>();
            #endregion
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                var path = System.AppDomain.CurrentDomain.BaseDirectory + @"CoreWithSwagger.xml";
                c.IncludeXmlComments(path);
            });

            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="context"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,EMobileContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
               
            });
            context.Seed();
            

            app.UseMvc();
        }
    }
}
