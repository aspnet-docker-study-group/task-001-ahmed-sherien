using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Students.Api.Infrastructure;

namespace Students.Api
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
            services.AddDbContext<StudentsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("StudentsContext"));
            });
            services.AddMvc();

            var serviceProvider = services.BuildServiceProvider();

            var context = serviceProvider.GetService<StudentsContext>();

            StudentsContextInitializer.InitializeDatabase(context);
            StudentsContextSeeder.SeedData(context);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
