using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Api.Sample.Template.Acceptance.Tests.Pages
{
    public class BingMainPageElementMap
    {
        private readonly IWebDriver browser;
        public BingMainPageElementMap(IWebDriver browser)
        {
            this.browser = browser;
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(browser, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        [FindsBy(How = How.Id, Using = "sb_form_q")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Id, Using = "sb_form_go")]
        public IWebElement GoButton { get; set; }

        [FindsBy(How = How.Id, Using = "b_tween")]
        public IWebElement ResultsCountDiv { get; set; }
    }
}