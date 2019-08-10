using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace UnitTestProject3
{
    [TestClass]
    public class BBCTest
    {
        private IWebDriver Driver { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new ChromeDriver();
        }
        [TestMethod]
        public void TestHomePage()
        {            
            HomePage bbcHomePage = new HomePage(Driver);
            bbcHomePage.Navigate();
            bbcHomePage.NewsButtonClick();
            NewsPage newsPage = new NewsPage(this.Driver);
            newsPage.CompareArticles();
            SearchPage bbcsearchPage = new SearchPage(this.Driver);
            bbcsearchPage.SearchNewsText("you can leave this method empty");
            LoremPage loremHomePage = new LoremPage(this.Driver);
            string loremText = loremHomePage.IputType(141);
            HaveYouSayPage haveYouSayPage = new HaveYouSayPage(this.Driver);
            haveYouSayPage.Fillform(loremText, false);
        }        
    }
}

