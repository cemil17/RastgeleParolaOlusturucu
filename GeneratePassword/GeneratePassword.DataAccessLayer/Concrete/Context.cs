using GeneratePassword.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePassword.DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		// Bağlantı Adresi
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=KI2544200421; Database= PasswordGenerateApp; Integrated Security=True; TrustServerCertificate=True");
		}

		public DbSet<Cipher> Ciphers { get; set; }

	}
}
