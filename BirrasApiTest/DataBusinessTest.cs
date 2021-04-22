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

        [Fact]
        public async void GetBeersByTemp1()
        {
            //Arrange
            Mock<IWeatherLogic> mockrepo = new Mock<IWeatherLogic>();
            IDataBusiness business = new DataBusiness(mockrepo.Object);

            decimal response = 19.5m;
            mockrepo.Setup(x => x.GetTemperature("buenos aires")).ReturnsAsync(response);

            //Act
            int result = await business.GetHowManyBeers("buenos aires", 9);

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public async void GetBeersByTemp2()
        {
            //Arrange
            Mock<IWeatherLogic> mockrepo = new Mock<IWeatherLogic>();
            IDataBusiness business = new DataBusiness(mockrepo.Object);

            decimal response = 25m;
            mockrepo.Setup(x => x.GetTemperature("buenos aires")).ReturnsAsync(response);

            //Act
            int result = await business.GetHowManyBeers("buenos aires", 9);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public async void GetBeersByTemp3()
        {
            //Arrange
            Mock<IWeatherLogic> mockrepo = new Mock<IWeatherLogic>();
            IDataBusiness business = new DataBusiness(mockrepo.Object);

            decimal response = 22.5m;
            mockrepo.Setup(x => x.GetTemperature("buenos aires")).ReturnsAsync(response);

            //Act
            int result = await business.GetHowManyBeers("buenos aires", 9);

            //Assert
            Assert.Equal(2, result);
        }
    }
}
