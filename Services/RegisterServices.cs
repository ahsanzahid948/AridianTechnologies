
using Foundation.Data;
using Microsoft.EntityFrameworkCore;

namespace Foundation.Services
{
    public static class RegisterServices
    {

        public static void AddServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));
            services.AddControllersWithViews();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });
        }
    }
}
