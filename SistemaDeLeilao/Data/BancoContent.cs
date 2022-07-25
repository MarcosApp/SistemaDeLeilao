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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>().HasData(
                            new UsuarioModel
                            {

                                Email = "admin@yahoo.com",
                                Login = "admin",
                                Senha = "d033e22ae348aeb5660fc2140aec35850c4da997",
                                Perfil = Enums.PerfilEnum.Admin,
                                DataCadastro = System.DateTime.Now,
                                Id = 1
                            }
                        );
        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<OfertaModel> Oferta { get; set; }
        public DbSet<LanceModel> Lance { get; set; }
        public DbSet<EmbarcadoresModel> Embarcadores { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<TransportadorModel> Transportadores { get; set; }
    }
}
