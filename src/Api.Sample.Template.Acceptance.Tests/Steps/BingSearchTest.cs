using Api.Sample.Template.Acceptance.Tests.Pages;
using TechTalk.SpecFlow;

namespace Api.Sample.Template.Acceptance.Tests.Steps
{
    [Binding]
    [Scope(Tag = "simpleSearchTag")]
    public class BingSearchTest : BasePageTest
    {        
        private BingMainPage bingPage;

        [Given(@"Opened Browser")]
        public void GivenOpenedBrowser()
        {            
            //navigator.Start();
        }

        [Given(@"Navigate to Bing Url")]
        public void GivenNavigateToBingUrl()
        {
            bingPage = new BingMainPage(navigator.Driver);
            bingPage.Navigate();
        }

        [When(@"Enter text on search box")]
        public void WhenEnterTextOnSearchBox()
        {
            bingPage.Search("Automate The Planet");
        }

        [When(@"Click on SearchButton")]
        public void WhenClickOnSearchButton()
        {
            bingPage.GoButtonClick();
        }

        [Then(@"Show the results")]
        public void ThenShowTheResults()
        {
            bingPage.Validate().ResultsCount(100000);
        }        
    }
}