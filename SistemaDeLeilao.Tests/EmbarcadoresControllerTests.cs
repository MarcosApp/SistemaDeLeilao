using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeLeilao.Data;
using SistemaDeLeilao.Models;
using SistemaDeLeilao.Repositorio;
using Xunit;

namespace SistemaLeilao.Tests
{
    public class EmbarcadoresControllerTests
    {
        private readonly IEmbarcadoresRepositorio _EmbarcadoresRepositorio;

        public EmbarcadoresControllerTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IEmbarcadoresRepositorio, EmbarcadoresRepositorio>();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContent>(
                    options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LeiloesDB;Trusted_Connection=true"));
            var serviceProvider = services.BuildServiceProvider();

            _EmbarcadoresRepositorio = serviceProvider.GetService<IEmbarcadoresRepositorio>();
        }
        [Fact]
        public void EmbarcadoresControllerTests_ReturnFalse_Apagar()
        {
            int valorErrado = 54545;
            var apagar = _EmbarcadoresRepositorio.Apagar(valorErrado);
            Assert.False(apagar);
        }

        [Fact]
        public void EmbarcadoresControllerTests_AdicionarEmbarcador()
        {
            EmbarcadoresModel model = new EmbarcadoresModel()
            {
                DataAtualizacao = System.DateTime.Now,
                DataCadastro = System.DateTime.Now,
                Nome = "Teste",
                SelectedTransportadorIds = null,
                Transportador = null,
                Usuario = new UsuarioModel()
                {
                    DataAtualizacao = System.DateTime.Now,
                    DataCadastro = System.DateTime.Now,
                    Login = "teste",
                    Email = "teste@gmail.com",
                    Perfil = SistemaDeLeilao.Enums.PerfilEnum.Embarcadores,
                    Senha = "teste"
                }

            };
            model.Usuario.SetSenhaHash();
            EmbarcadoresModel embarcador = _EmbarcadoresRepositorio.Adicionar(model);
            Assert.NotNull(embarcador);
        }

        [Fact]
        public void EmbarcadoresControllerTests_ReturnTrue_Apagar()
        {
            var dados = _EmbarcadoresRepositorio.BuscarTodos();
            int correto = dados[dados.Count - 1].Id;
            var apagar = _EmbarcadoresRepositorio.Apagar(correto);
            Assert.True(apagar);
        }
    }
}
