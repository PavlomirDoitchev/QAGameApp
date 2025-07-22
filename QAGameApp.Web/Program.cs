using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QAGameApp.Data;

namespace QAGameApp.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
										?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services
				.AddDbContext<QAGameAppDbContext>(options =>
				{
					options.UseSqlServer(connectionString);
				});
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services
				.AddDefaultIdentity<IdentityUser>(options =>
				{
					options.SignIn.RequireConfirmedEmail = false;
					options.SignIn.RequireConfirmedAccount = false;
					options.SignIn.RequireConfirmedPhoneNumber = false;

					options.Password.RequiredLength = 3;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireDigit = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireUppercase = false;
					options.Password.RequiredUniqueChars = 0;
				})
				.AddEntityFrameworkStores<QAGameAppDbContext>();

			// Add services to the container.
			builder.Services.AddControllersWithViews();

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
