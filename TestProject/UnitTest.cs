using System;
using System.Threading.Tasks;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class RepositoryGenericsTests
    {
        private DbContextOptions<ContextBase> _options;

        [SetUp]
        public void SetUp()
        {
            // Configurar as opções de contexto do banco de dados para teste
            _options = new DbContextOptionsBuilder<ContextBase>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
        }

        [Test]
        public async Task CreateAsync_WhenCalledWithValidEntity_ShouldAddEntityToDatabase()
        {
            // Arrange
            using (var context = new ContextBase(_options))
            {
                var repository = new RepositoryGenerics<TEntity>();

                var entity = new TEntity(); // Substitua TEntity pelo tipo real da sua entidade
                                            // ... preencha a entidade com dados de teste, se necessário

                // Act
                await repository.CreateAsync(entity);

                // Assert
                // Verificar se a entidade foi adicionada ao banco de dados
                Assert.That(context.Set<TEntity>().Contains(entity), Is.True);
            }
        }

        // Outros testes podem ser adicionados aqui para cobrir outros cenários, como testes de erro, testes de comportamento, etc.
    }

}