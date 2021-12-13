using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using my_book.Data.Models;
using my_book.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book
{
	public class Startup
	{
		public string ConnectionString { get; set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			// get the name from appsetting file.
			ConnectionString = configuration.GetConnectionString("DefaultConnectionString");
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();

			//Configure DBContext with SQL Database
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

			//Configure Book Service
			services.AddTransient<BooksServices>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v2", new OpenApiInfo { Title = "my_book_updated_title", Version = "v2" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "my_book_updated_ui v2"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			AppDbInitialer.Seed(app);
		}
	}
}
