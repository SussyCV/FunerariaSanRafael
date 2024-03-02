using Microsoft.EntityFrameworkCore;
using System.Configuration;



namespace FunerariaSanRafael.Models
{

    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = ConfigurationManager.ConnectionStrings["fsrafael"].ConnectionString;

            optionsBuilder.UseSqlServer(connection);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<rel_recibo_metodo_pago>().HasKey(x => new { x.cod_expediente, x.rec_periodo });
        }

        public DbSet<mst_Ruta> mst_Ruta { get; set; }
        public DbSet<mst_Expediente> mst_Expediente { get; set; }
        public DbSet<mst_MetodoPago> mst_MetodoPago { get; set; }
        public DbSet<mst_Recibo> mst_Recibo { get; set; }
        public DbSet<mst_Servicio> mst_Servicio { get; set; }
        public DbSet<mst_User> mst_User { get; set; }
        public DbSet<rel_expediente_servicio> rel_expediente_servicio { get; set; }
        public DbSet<rel_recibo_metodo_pago> rel_recibo_metodo_pago { get; set; }





    }

}
