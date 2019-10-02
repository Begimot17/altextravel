using AltexTravel.API.Mappers;
using Xunit;

namespace AltexTravel.API.Tests
{
    public class RecommendationTests
    {
        [Theory]
        [InlineData("WAR AND PEACE")]
        [InlineData("war and peace")]
        [InlineData("WaR aNd PeAcE")]
        public void StringToTitleCase_ValidTitleCase_IsMatched(string inputValue)
        {
            //Arrange
            var val = inputValue.StringToTitleCase();

            //Act
            var isMatch = val.Equals("War And Peace");

            //Assert
            Assert.True(isMatch);
        }
    }
}
