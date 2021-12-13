using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Models
{
	//A bridge file between entity classes ( C# classes) and the database tables (sql)
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
		{

		}

		// use Books to get and send data in the database
		public DbSet<Book> Books { get; set; }
	}
}
