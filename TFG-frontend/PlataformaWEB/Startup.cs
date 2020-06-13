#region Using
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using PlataformaWEB.Configuration;
using PlataformaWEB.Extensions;
using Microsoft.Extensions.Hosting;
using PlataformaWEB.Models;

#endregion

namespace PlataformaWEB
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IConfiguration _configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			Action<ConnectionOptions> connectionOptions = (opt =>
			{
				opt.apiDevelop = "https://apitfgalex.azurewebsites.net";
				opt.apiLocal = "http://localhost:5001";
			});

			services.Configure(connectionOptions);
			services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<ConnectionOptions>>().Value);

			services.Configure<AppSettings>(_configuration);

			services.AddControllersWithViews();

			services.Configure<RequestLocalizationOptions>(
				opts =>
				{
					var supportedCultures = new List<CultureInfo>
					{
						new CultureInfo("en-GB"),
						new CultureInfo("es-ES")
					};
					opts.DefaultRequestCulture = new RequestCulture("es-ES");
					opts.SupportedCultures = supportedCultures;
					opts.SupportedUICultures = supportedCultures;
				});

			var settings = _configuration.Get<AppSettings>();

			services.AddSession(o =>
			{
				o.IdleTimeout = TimeSpan.FromMinutes(6 * 60);
			});

			services.AddHttpClientServices(_configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}");
			});
		}
	}
}