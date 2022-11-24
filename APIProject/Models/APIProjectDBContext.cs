using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using APIProject.Models;
using System.Collections.Generic;

namespace APIProject.Models
{
    public class APIProjectDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public APIProjectDBContext(DbContextOptions<APIProjectDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("StudentDiscountsDB");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Company> companys { get; set; } = null!;
        public DbSet<Service> services { get; set; } = null!;
        public DbSet<Student> students { get; set; } = null!;
    }
}