using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace P2_2019AM604_2018PR603.Models
{
		public class dbCovidContext : DbContext
		{

		public dbCovidContext(DbContextOptions<dbCovidContext> options) : base(options)
		{

		}

		public DbSet<Creportado> creportado { get; set; }
		public DbSet<Departamento> departamento { get; set; }
		public DbSet<Genero> genero { get; set; }


	}
	}
