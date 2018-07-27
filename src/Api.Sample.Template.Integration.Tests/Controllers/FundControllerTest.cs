using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Api.Sample.Template.ApplicationService.ViewModels;
using FluentAssertions;

namespace Api.Sample.Template.Integration.Tests.Controllers
{
    [TestFixture]
    public class FundControllerTest : SimpleControllerTest
    {
        [Test]
        public async Task WhenGetFund_Then_ReturnViewModelWithId()
        {
            // Arrange
            var expectedName = "FundName";
            var expectedDescription = "FundDescription";

            // Act
            var responseCreate = await client.PostAsync(
                    $"api/fund",
                    new StringContent($"{{'name':'{expectedName}', 'description':'{expectedDescription}'}}",
                    Encoding.UTF8,
                    "application/json"));

            responseCreate.EnsureSuccessStatusCode();
            var viewModelCreate = JsonConvert.DeserializeObject<FundViewModel>(await responseCreate.Content.ReadAsStringAsync());

            var responseGet = await client.GetAsync($"api/fund/{viewModelCreate.Id}");
            responseGet.EnsureSuccessStatusCode();
            var viewModelGet = JsonConvert.DeserializeObject<FundViewModel>(await responseGet.Content.ReadAsStringAsync());


            // Assert
            responseCreate.StatusCode.Should().Equals(HttpStatusCode.OK);
            viewModelCreate.Should().BeOfType<FundViewModel>();
            responseGet.StatusCode.Should().Equals(HttpStatusCode.OK);
            viewModelGet.Should().BeOfType<FundViewModel>();
            viewModelGet.Name.Should().Equals(expectedName);
            viewModelGet.Description.Should().Equals(expectedDescription);
            
        }
    }
}