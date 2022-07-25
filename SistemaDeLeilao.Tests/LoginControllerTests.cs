using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeLeilao.Data;
using SistemaDeLeilao.Models;
using SistemaDeLeilao.Repositorio;
using Xunit;

namespace SistemaLeilao.Tests
{
    public class LoginControllerTests
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public LoginControllerTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IEmbarcadoresRepositorio, EmbarcadoresRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContent>(
                    options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LeiloesDB;Trusted_Connection=true"));
            var serviceProvider = services.BuildServiceProvider();

            _UsuarioRepositorio = serviceProvider.GetService<IUsuarioRepositorio>();
        }
      

        [Fact]
        public void LoginControllerTests_AdicionarLogin()
        {
            UsuarioModel model = new UsuarioModel()
            {
                DataAtualizacao = System.DateTime.Now,
                DataCadastro = System.DateTime.Now,
                Login = "Admin",
                Email = "Admin@gmail.com",
                Perfil = SistemaDeLeilao.Enums.PerfilEnum.Admin,
                Senha = "Admin"

            };
            model.SetSenhaHash();
            UsuarioModel embarcador = _UsuarioRepositorio.Adicionar(model);
            Assert.NotNull(embarcador);
        }

        [Fact]
        public void LoginControllerTests_ReturnTrue_Apagar()
        {
            var dados = _UsuarioRepositorio.BuscarTodos();
            int correto = dados[dados.Count - 1].Id;
            var apagar = _UsuarioRepositorio.Apagar(correto);
            Assert.True(apagar);
        }
    }
}
