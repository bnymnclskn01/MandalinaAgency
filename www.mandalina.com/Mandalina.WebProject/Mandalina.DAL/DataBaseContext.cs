using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.DAL
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext() 
        {
            this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer( new DbOlusturucu());
            //Database.SetInitializer<DataBaseContext>(new CreateDatabaseIfNotExists<DataBaseContext>());

        }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Categories> Category { get; set; }

        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Languages> Languages { get; set; }

        public DbSet<Sliders> Slider { get; set; }
        public DbSet<SliderImage> SliderImage { get; set; }

        public DbSet<Work> Work { get; set; }
        public DbSet<Service> Service { get; set; }

        public DbSet<ContactForm> ContactForm { get; set; }
        public DbSet<ConstantValues> ConstantValue { get; set; }
        public DbSet<Menuler> Menuler { get; set; }
        public DbSet<SocialMedias> SocialMedias { get; set; }
        public DbSet<SeoSettings> SeoSetting { get; set; }
        public DbSet<References> Reference { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<VideoPlayer> VideoPlayer { get; set; }
        public DbSet<WorkImage> WorkImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceCategory>()
                    .HasKey(c => new { c.CategoriesID, c.ServiceID });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
