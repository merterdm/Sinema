using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sinema.MVCUI.Identity;

namespace Sinema.MVCUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Sql server DbContext Register
            builder.Services.AddDbContext<SinemaIdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));

            #region Identity Ayarlari
            ;
            builder.Services.AddIdentity<SinemaUser, IdentityRole>()
                            .AddEntityFrameworkStores<SinemaIdentityDbContext>() // Hangi Database'de veriler saklanacak. Onu belirtiyoruz
                            .AddDefaultTokenProviders(); //  Email gonderim sirasinda olusturulacak token icin gerekli


            //          builder.Services.AddDefaultIdentity<SinemaUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddRoles<IdentityRole>() //Line that can help you
            //.AddEntityFrameworkStores<SinemaIdentityDbContext>();



            builder.Services.Configure<IdentityOptions>(options =>
            {

                options.Password.RequireDigit = false; // Sifre olusturulurken sayisal bir alan olmasini istiyorsaniz true yapmaniz gereklidir
                options.Password.RequireUppercase = false; // Buyuk harf isteniyorsa true yapilacak
                options.Password.RequireLowercase = false;  // Kucuk harf isteniyorsa
                options.Password.RequireNonAlphanumeric = false; // Alfanumeric karakter isteniyorsa true yapilir.
                options.Password.RequiredLength = 3; // Sifrenin uzunlugu ne kadar olacak.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Lockout suresi ni belirliyoruz.
                options.Lockout.MaxFailedAccessAttempts = 5;// 5 kere yanlis giris yaparsa girisi askiya alinir.
                options.User.RequireUniqueEmail = true;//Birilecek mail adresleri tekil olmalidir
                options.SignIn.RequireConfirmedEmail = false; // Confirm mail zorunlulugu nun ayarlandigi yer
                options.User.AllowedUserNameCharacters = "abcçdefgðhijklmnoöpqrstuüvwxyzABÇCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";


            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Login/Login";
                options.AccessDeniedPath = "/Login/AccessDenied";
                options.LogoutPath = "/Login/Logout";
                options.SlidingExpiration = true;
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}