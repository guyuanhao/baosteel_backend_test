using baosteelApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace baosteelApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CheckContext>(opt =>
                opt.UseSqlServer("Data Source=CNSHI6P1603;Initial Catalog=testBaoSteel;Integrated Security=True"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:9000")
                .AllowAnyHeader()
            );
            app.UseMvc();
        }
    }
}
