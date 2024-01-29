using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TNE_Test.Data;
using TNE_Test.Services;

namespace TNE_Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TNE_TestDBContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DBConnection"),
                    x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                )
                );
            services.AddScoped<DbContext, TNE_TestDBContext>();
            services.AddTransient<ITneServices, TneServices>();
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "TNE_Test", Version = "1.0",
                Description = "Даты отправляются и получаются в формате ISO 8601. Например: 2023-12-22T15:53:43.2311892"});
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "TNE_Test.xml");
                c.IncludeXmlComments(xmlPath);
            });
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
            app.UseSwagger().
                UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TNE_Test");
                    //  c.RoutePrefix = string.Empty;

                });
        }
    }
}
