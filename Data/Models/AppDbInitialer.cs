using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Models
{
	public class AppDbInitialer
	{
		public static void Seed(IApplicationBuilder applicationBuilder) {

			// the instance is closed after the code is executed.
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				if (!context.Books.Any())
				{
					context.Books.AddRange(new Book()
					{
						Title = "1st Book Title",
						Description = "1st Book Description",
						IsRead = true,
						DateRead = DateTime.Now.AddDays(-10),
						Rate = 4,
						Genre = "Comic",
						Author = "Yoyo",
						CoverUrl = "https...",
						DateAdded = DateTime.Now
					},
					new Book()
					{
						Title = "2nd Book Title",
						Description = "2nd Book Description",
						Rate = 4,
						Genre = "Comic",
						Author = "Yoyo",
						DateAdded = DateTime.Now
					});
					context.SaveChanges();
				}
			}

		}
	}
}
