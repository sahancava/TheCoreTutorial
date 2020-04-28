using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheCoreTutorial.Models.DBHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TheCoreTutorial
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DatabaseContext>(options=>options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TheNews;Integrated Security=True;"));
			services.AddMvc();
			services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(
			  Path.Combine(Directory.GetCurrentDirectory(), @"Css")),
				RequestPath = new PathString("/css")
			});
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(
			  Path.Combine(Directory.GetCurrentDirectory(), @"Vendor")),
				RequestPath = new PathString("/vendor")
			});
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(
			  Path.Combine(Directory.GetCurrentDirectory(), @"img")),
				RequestPath = new PathString("/img")
			});
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(
			  Path.Combine(Directory.GetCurrentDirectory(), @"Js")),
				RequestPath = new PathString("/js")
			});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
