using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace UnitTestProject3
{
    public class SearchPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.bbc.com/news";

        public SearchPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@data-entityid='container-top-stories#1']/div[1]/ul/li[2]/a/span")]
        public IWebElement region { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='orb-search-q']")]
        public IWebElement input { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='orb-search-button']")]
        public IWebElement searchButton { get; set; }
        private void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void SearchNewsText(string text)
        {
            Navigate();
            this.input.Click();
            this.input.Clear();
            this.input.SendKeys(text);
            this.searchButton.Click();
        }
        
        public void SearchNewsText()
        {
            Navigate();
            this.input.Click();
            this.input.Clear();
            this.input.SendKeys(this.region.Text);
            this.searchButton.Click();
        }
    }
}
