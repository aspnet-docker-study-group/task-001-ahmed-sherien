using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Students.Api.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;

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

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "AspNetDockerStudyGroup - Students API",
                    Version = "v1",
                    Description = "The Students API",
                    TermsOfService = "None"
                });
            });

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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Students API V1");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
