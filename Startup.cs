using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SensorApiMDB.Models;
using SensorApiMDB.Service;

namespace SensorApiMDB
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

            services.Configure<SensorDatabaseSettings>(Configuration.GetSection(nameof(SensorDatabaseSettings)));

            services.AddSingleton<ISensorDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SensorDatabaseSettings>>().Value);

            services.AddControllers();

            services.AddSingleton<SensorService>();

            //services.AddDbContext<SensorContext>(opt => opt.("SensorList"));

            //services.AddDbContext<SensorContext>(opt => opt.UseSqlServer("Data Source=localdatabase.db"));


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
