using Api.Sample.Template.Acceptance.Tests.Pages;
using TechTalk.SpecFlow;

namespace Api.Sample.Template.Acceptance.Tests.Steps
{
    [Binding]
    public class BasePageTest
    {
        protected static BrowserNavigator navigator;        

        [BeforeTestRun]
        public static void BeforeAllTests()
        {
            navigator = new BrowserNavigator();
            navigator.Start();
        }

        [AfterTestRun]
        public static void AfterAllTests()
        {
            navigator.Stop();
        }
    }
}