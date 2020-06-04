using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TradeMeWebUIAutomationFramework.PageObjects;
using TradeMeWebUIAutomationFramework.Support;

namespace TradeMeWebUIAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class TradeMeStepDefinition
    {
        private readonly MainPage mainPage;
        private readonly MotorsPage motorsPage;

        public TradeMeStepDefinition(IWebDriver driver)
        {
            mainPage = new MainPage(driver);
            motorsPage = new MotorsPage(driver);
        }

        [Given(@"I navigate to the TradeMe Website")]
        public void GivenINavigateToTheTradeMeWebsite()
        {
            // Gets the website URL from appsettings.json
            mainPage.Navigate(TestConfiguration.GetSectionAndValue("Settings", "url"));
        }

        [Then(@"I verify that I am on the Main Page")]
        public void ThenIVerifyThatIAmOnTheMainPage()
        {
            var pageLocator = mainPage.PageLocator;
            Assert.IsTrue(mainPage.IsPageLoaded(pageLocator));
        }

        [When(@"I press vertical navigation option : ""(.*)""")]
        public void WhenIPressVerticalNavigationOption(string navOption)
        {
            mainPage.ClickVerticalNavOption(navOption);
        }

        [Then(@"I verify that I am on the Motors Page")]
        public void ThenIVerifyThatIAmOnTheMotorsPage()
        {
            var pageLocator = motorsPage.PageLocator;
            Assert.IsTrue(motorsPage.IsPageLoaded(pageLocator));
        }

        [When(@"I click the link ""(.*)"" on the widget navigation option on the Motors Page")]
        public void WhenIClickTheLinkOnTheControlTableOnTheMotorsPage(string option)
        {
            motorsPage.ClickSubNavigationOption(option);
        }

        [Then(@"I verify that Used Cars table is loaded")]
        public void ThenIVerifyThatUserCarsTableIsLoaded()
        {
            Assert.IsTrue(motorsPage.IsUsedCarTableLoaded());
        }

        [Then(@"I verify that the listing for used car brand : ""(.*)"" is (.*)")]
        public void ThenIVerifyThatTheListingUsedCarBrandIs(string carBrand, int listingCount)
        {
            Assert.AreEqual(listingCount, motorsPage.GetListingForCarMakes(carBrand));
        }
    }
}
