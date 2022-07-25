using SistemaDeLeilao.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeLeilao.Data
{
    public class BancoContent : DbContext
    {
        public BancoContent(DbContextOptions<BancoContent> options) :
            base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmbarcadorTransports>()
        // .HasKey(pc => new { pc.IdEmbarcadores, pc.IdTransportador });
        //}
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<OfertaModel> Oferta { get; set; }
        public DbSet<LanceModel> Lance { get; set; }
        public DbSet<EmbarcadoresModel> Embarcadores { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<TransportadorModel> Transportadores { get; set; }
    }
}
