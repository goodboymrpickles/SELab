using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using EDUProjects.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EDUProjects.DataAccess;
using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.ApplicationLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace EDUProjects
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
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			services.AddDbContext<EDUProjectsDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
			  .AddRoles<IdentityRole>()
			 .AddEntityFrameworkStores<ApplicationDbContext>();




			services.AddScoped<IClassRepository, ClassRepository>();
			services.AddScoped<ClassService>();

			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<StudentService>();

			services.AddScoped<ITeacherRepository, TeacherRepository>();
			services.AddScoped<TeacherService>();

			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<ProjectService>();

			services.AddScoped<IGradingRepository, GradingRepository>();
			services.AddScoped<ProjectService>();

			services.AddScoped<IEnrollRepository, EnrollRepository>();

			services.AddScoped<RegisterService>();

			services.AddControllersWithViews();
			services.AddRazorPages();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
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

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
		
			
		});

		 CreateUserRoles(services).Wait();

		}


		private async Task CreateUserRoles(IServiceProvider serviceProvider)
		{
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

			IdentityResult roleResult;
			//here in this line we are adding Admin Role
			var roleCheck = await RoleManager.RoleExistsAsync("Teacher");
			if (!roleCheck)
			{
				//here in this line we are creating admin role and seed it to the database
				roleResult = await RoleManager.CreateAsync(new IdentityRole("Teacher"));
			}
			//here we are assigning the Admin role to the User that we have registered above 
			//Now, we are assinging admin role to this user("Ali@gmail.com"). When will we run this project then it will
			//be assigned to that user.
			IdentityUser user = await UserManager.FindByEmailAsync("teacher@gmail.com");
			var User = new IdentityUser();
			await UserManager.AddToRoleAsync(user, "Teacher");


			roleCheck = await RoleManager.RoleExistsAsync("Student");
			if (!roleCheck)
			{
				//here in this line we are creating admin role and seed it to the database
				roleResult = await RoleManager.CreateAsync(new IdentityRole("Student"));
			}
			//here we are assigning the Admin role to the User that we have registered above 
			//Now, we are assinging admin role to this user("Ali@gmail.com"). When will we run this project then it will
			//be assigned to that user.
			IdentityUser user2 = await UserManager.FindByEmailAsync("studentt@gmail.com");
			var User2 = new IdentityUser();
			await UserManager.AddToRoleAsync(user2, "Student");

		}

	}
}
