using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimulasiyaPronia.DAL;
using SimulasiyaPronia.Models;

namespace SimulasiyaPronia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvnbm@";
                option.User.RequireUniqueEmail = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AppDbContext>();


            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseStaticFiles();

          app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
