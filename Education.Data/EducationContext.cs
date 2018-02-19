using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;

namespace Education.Data
{
    public class EducationContext : DbContext
    {
        public EducationContext()
        : base("EducationContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.UseDatabaseNullSemantics = true;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            ConfigurationMapping.Configure(modelBuilder);

        }

        public DbSet<ApiUser> ApiUsers { get; set; }
        public DbSet<AuthToken> AuthTokens { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Part> Parts { get; set; }
    }
}
