using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeLeilao.Data;
using SistemaDeLeilao.Models;
using SistemaDeLeilao.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SistemaDeLeilao.Tests
{
    public class FuncionarioControllerTests
    {
        private readonly IFuncionarioRepositorio _FuncionarioRepositorio;

        public FuncionarioControllerTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IFuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContent>(
                    options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LeiloesDB;Trusted_Connection=true"));
            var serviceProvider = services.BuildServiceProvider();

            _FuncionarioRepositorio = serviceProvider.GetService<IFuncionarioRepositorio>();
        }

        [Fact]
        public void FuncionarioControllerTests_ReturnFalse_Apagar()
        {
            int valorErrado = 54545;
            var apagar = _FuncionarioRepositorio.Apagar(valorErrado);
            Assert.False(apagar);
        }
    }
}
