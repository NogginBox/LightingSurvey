using LightingSurvey.MvcSite.Services.Postcodes;
using System.Threading.Tasks;
using Xunit;

namespace LightingSurvey.Tests.MvcSite.Services.Postcodes
{
    public class PostcodeLookupServiceTests
    {
        [Fact]
        public async Task TestFindsPostcodeAddress()
        {
            // Arrange
            var service = new PostcodeLookupService();

            // Act
            var latLong = await service.Search("LS16 7NY");

            // Assert
            Assert.Equal(53.857431, latLong.Lat);
            Assert.Equal(-1.594628, latLong.Long);
        }
    }
}
