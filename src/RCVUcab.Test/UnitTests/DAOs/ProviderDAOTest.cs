using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using RCVUcab.Persistence.DAOs.Implementations;
using RCVUcab.Persistence.Database;
using RCVUcab.Test.DataSeed;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RCVUcab.Test.UnitTests.DAOs
{
    public class ProviderDAOTest
    {
        private readonly ProviderDAO _dao;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<ProviderDAO>> _mockLogger;
       
        public ProviderDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<ProviderDAO>>();
            
            _dao = new ProviderDAO(_contextMock.Object);
            _contextMock.SetupDbContextData();
        }

        [Theory]
        [InlineData("Toyota")]
        public Task ShouldReturnAllClaimsProviderData(string brand)
        {
            var result = _dao.GetProvidersByBrand(brand);
            var data = result;
            Assert.True(data.Any());
            return Task.CompletedTask;
        }
    }
}
