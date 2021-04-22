using Business;
using Business.Interfaces;
using Moq;
using Services.Interfaces;
using Xunit;

namespace BirrasApiTest
{
    public class DataBusinessTest
    {
        [Fact]
        public async void GetTemperatureTest()
        {
            //Arrange
            Mock<IWeatherLogic> mockrepo = new Mock<IWeatherLogic>();
            IDataBusiness business = new DataBusiness(mockrepo.Object);

            decimal response = 22.1m;
            mockrepo.Setup(x => x.GetTemperature("buenos aires")).ReturnsAsync(response);

            //Act
            decimal result = await business.GetTemperature("buenos aires");

            //Assert
            Assert.Equal(response, result);
        }
    }
}
