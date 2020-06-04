using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace TradeMeWebUIAutomationFramework.PageObjects
{
    public class MotorsPage : BasePage
    {
        public MotorsPage(IWebDriver driver) : base(driver)
        {
        }

        public By PageLocator => By.CssSelector("div[id=mainContent] form[action*=motors]");

        private IEnumerable<IWebElement> Widgets => FindElements(By.CssSelector("div[class*=sub-nav-motors-two] ul[class=Widget] li"));

        private IWebElement TableMakes => FindElement(By.CssSelector("table[id=makes]"));

        private IEnumerable<IWebElement> Makes => FindElements(By.XPath("//table[@id='makes']//tr//td"));

        internal void ClickSubNavigationOption(string option)
        {
            var x = Widgets.ElementAt(1).Text;
            Widgets.First(w => w.Text == option).Click();
        }

        internal bool? IsUsedCarTableLoaded()
        {
            return TableMakes.Displayed;
        }

        internal int GetListingForCarMakes(string carBrand)
        {
            var listText = Makes.First(m => m.Text.Contains(carBrand)).Text;
            return GetListingValue(listText);
        }

        private static int GetListingValue(string listText)
        {
            var listingCountString = listText.Substring(listText.IndexOf("(") + 1, listText.Length - (listText.IndexOf("(") + 1));
            return int.Parse(listingCountString.Replace(")", ""));
        }
    }
}
