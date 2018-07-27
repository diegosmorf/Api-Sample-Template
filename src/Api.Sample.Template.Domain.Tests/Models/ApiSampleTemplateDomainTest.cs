using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Api.Sample.Template.Domain.Tests.Models
{
    [TestFixture]
    public class ApiSampleTemplateDomainTest
    {
        [Test]
        public async void WhenConditionThenResult()
        {
            //arrange
            var currentValue = false;
            var expectedResult = true;

            //act
            currentValue = await CalculateValue();

            //assert
            currentValue.Should()
                        .Equals(expectedResult);
        }
        
        [TestCase(true)]
        [TestCase(false)]
        public async void WhenInputEqualsTrueThenSucess(bool value)
        {
            //arrange
            var currentValue = false;
            var expectedResult = value;

            //act
            currentValue = await CalculateValue(value);

            //assert
            currentValue.Should()
                        .Equals(expectedResult);
        }

        private Task<bool> CalculateValue()
        {
            return Task.Run(() => { return CalculateValue(true); });
        }

        private Task<bool> CalculateValue(bool value)
        {
            return Task.Run(() => { return value; });
        }
    }
}
