using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace UnitTestProject3
{
    public class LoremPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.lipsum.com/";

        public LoremPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id='Panes']/div[4]/form/table/tbody/tr[1]/td[2]/table/tbody/tr[3]/td[2]/label")]
        public IWebElement bytesRadioButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='amount']")]
        public IWebElement input;
        [FindsBy(How = How.XPath, Using = "//*[@id='generate']")]
        public IWebElement generateButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='lipsum']/p")]
        public IWebElement LoremText;
        private void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }
        private void BytesRadioButtonClick()
        {
            this.bytesRadioButton.Click();
        }
        public string IputType(int charLength)
        {
            Navigate();
            BytesRadioButtonClick();
            this.input.Clear();
            this.input.SendKeys(Keys.Backspace + charLength);
            this.generateButton.Click();
            return LoremText.Text;
        }
        /*
        public string LoremTextReturn()
        {
            return LoremText.Text;
        }
        */
    }
}
