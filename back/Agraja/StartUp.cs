using Agraja.CrossCutting.Configuration;

namespace Agraja_API
{
    public class StartUp
    {
        public StartUp(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public StartUp(IConfiguration configuration)//
        {
            Configuration = configuration;//
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>//
            {
                options.AddPolicy("MyCorsPolicy", builder =>//
                {
                    builder//
                        .AllowAnyOrigin()//
                        .AllowAnyMethod()//
                        .AllowAnyHeader();//
                });
            });

            services.AddMvc(option => option.EnableEndpointRouting = false);


            services.AddSingleton<IConfiguration>(Configuration);

            IoC.Register(services);

            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "1.0",
                    Title = "Agraja"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyCorsPolicy");//

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(cfg =>
            {
                cfg.SwaggerEndpoint("./v1/swagger.json", "Agraja");
            });

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
