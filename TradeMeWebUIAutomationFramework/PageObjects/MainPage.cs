using OpenQA.Selenium;
using System;

namespace TradeMeWebUIAutomationFramework.PageObjects
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public By PageLocator => By.CssSelector("div[class=page-body] div[id=Main]");

        /// <summary>
        /// Clicks the vertical Navigation Option provided.
        /// </summary>
        /// <param name="navOption"></param>
        internal void ClickVerticalNavOption(string navOption)
        {
            FindElement(By.CssSelector($"div[id=CatSplat] div[class=inner] ul li[id*={navOption}]")).Click(); 
        }
    }
}
