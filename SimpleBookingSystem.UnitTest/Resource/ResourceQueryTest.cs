using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SimpleBookingSystem.UnitTest
{
    public class ResourceQueryTest
    {
        [Fact]
        public async Task GetResources_ReturnResourceModel()
        {
            //Arrange
            var resourceServiceTestFactory = TestFactories.ResourceServiceTestFactory();

            //Act
            var resources = await resourceServiceTestFactory.GetResourcesAsync();

            //Assert
            Assert.NotNull(resources);
            Assert.True(resources.Count()>0);
        }
    }
}