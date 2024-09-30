using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.DataEntity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Bootcamp> Bootcamps => Set<Bootcamp>();
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<BootcampKayit> Kayitlar => Set<BootcampKayit>();
        public DbSet<Egitmen> Egitmenler => Set<Egitmen>();

    }
}