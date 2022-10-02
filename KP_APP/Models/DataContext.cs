using Microsoft.EntityFrameworkCore;
using KP_APP.Models;
using System.Xml;

namespace KP_APP.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<departments> departments => Set<departments>();
        public DbSet<positions> positions => Set<positions>();
        public DbSet<sost_departments> sost_departments => Set<sost_departments>();
        public DbSet<status_zakazis> status_zakazis => Set<status_zakazis>();
        public DbSet<accounts> accounts => Set<accounts>();
        public DbSet<tov_kategories> tov_kategories => Set<tov_kategories>();
        public DbSet<parameters> parameters => Set<parameters>();
        public DbSet<sootv_kategor_parameters> sootv_kategor_parameters => Set<sootv_kategor_parameters>();


    }
}