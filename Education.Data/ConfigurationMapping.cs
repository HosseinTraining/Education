using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Education.Model;

namespace Education.Data
{
    public class ConfigurationMapping
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            MapApiUser(modelBuilder);
            MapAuthToken(modelBuilder);
            MapPerson(modelBuilder);
            MapMessage(modelBuilder);
            MapSection(modelBuilder);
            MapPart(modelBuilder);
        }

        private static void MapPart(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>().ToTable("Part", "Partition");
            modelBuilder.Entity<Part>().HasKey(x => x.Id);
            modelBuilder.Entity<Part>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private static void MapSection(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>().ToTable("Section", "Partition");
            modelBuilder.Entity<Part>().HasKey(x => x.Id);
            modelBuilder.Entity<Part>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private static void MapMessage(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().ToTable("Message", "Communication");
            modelBuilder.Entity<Part>().HasKey(x => x.Id);
            modelBuilder.Entity<Part>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private static void MapPerson(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person", "Security");
            modelBuilder.Entity<Part>().HasKey(x => x.Id);
            modelBuilder.Entity<Part>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private static void MapAuthToken(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthToken>().ToTable("AuthToken", "Security");
            modelBuilder.Entity<Part>().HasKey(x => x.Id);
            modelBuilder.Entity<Part>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private static void MapApiUser(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiUser>().ToTable("ApiUser", "Security");
            modelBuilder.Entity<Part>().HasKey(x => x.Id);
            modelBuilder.Entity<Part>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}