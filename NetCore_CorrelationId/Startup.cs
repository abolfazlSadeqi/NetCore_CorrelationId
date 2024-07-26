
using Microsoft.AspNetCore.Builder;
using NetCore_CorrelationId.Common.Middlewares;
using Serilog;

namespace NetCore_CorrelationId
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
            services.AddHttpContextAccessor();
         
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<ICorrelationIdService, CorrelationIdService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
            // app.UseMiddleware<CorrelationIdMiddleware>();
            

            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        

        }
    }
}
