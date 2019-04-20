using CalculatedTriangleRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Triangles.TriangleByPosition;
using Triangles.TriangleByVertices;

namespace WebApp
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
            var triangleRepo = new TriangleRepo(
                Configuration.GetValue<int>("Triangles:NumberOfRows"), 
                Configuration.GetValue<int>("Triangles:NumberOfColumns"), 
                Configuration.GetValue<int>("Triangles:LegLength"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<ITriangleByPositionRepo>(triangleRepo);
            services.AddSingleton<ITiangeByVerticesRepo>(triangleRepo);
            services.AddTransient<TriangleByPositionService>();
            services.AddTransient<TriangleByVerticesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "wwwroot/index.html");
            });
        }
    }
}