using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace UnitTestProject3
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.bbc.com/";

        public HomePage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id='orb-nav-links']/ul/li[2]/a")]
        private IWebElement NewsButton { get; set; }
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void NewsButtonClick()
        {
            this.NewsButton.Click();
        }
    }
}
