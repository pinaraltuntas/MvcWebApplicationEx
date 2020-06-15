using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEx.Models;

namespace WebApplicationEx.Data
{
	public class ExAppDataContext:DbContext
	{
		public ExAppDataContext(DbContextOptions<ExAppDataContext> options)		//DbContextOptions<> => DbContext ile ilgili ayarların yapıldığı generic class
			:base(options)
		{

		}
		public DbSet<Product> Products { get; set; }
	}
}
