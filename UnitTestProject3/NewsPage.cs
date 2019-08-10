using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace UnitTestProject3
{
    public class NewsPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.bbc.com/news";
        public NewsPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }
        private void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }
        private List<IWebElement> NewsListAdd()
        {
            Navigate();
            List<IWebElement> NewsList = new List<IWebElement>();
            NewsList.Add(driver.FindElement(By.XPath("//*[@data-entityid='container-top-stories#1']/div[1]/div/a/h3")));
            string passLeft = "//*[@data-entityid='container-top-stories#";
            string passRight = "']/div[2]/div/a/h3";
            for (int i = 2; i <= 6; i++)
            {
                NewsList.Add(driver.FindElement(By.XPath($"{passLeft}{i}{passRight}")));
            }
            return NewsList;
        }
        private List<string> MainArticlesAdd()
        {
            List<String> MainArticles = new List<string>();
            MainArticles.Add("Disgraced financier Epstein found dead in cell");
            MainArticles.Add("One million evacuated as deadly typhoon hits China");
            MainArticles.Add("Walmart panic caused by gun rights 'test'");
            MainArticles.Add("One person injured in Norway mosque shooting");
            MainArticles.Add("Tear gas at Kashmir rally India denies happened");
            MainArticles.Add("Moscow opposition protest 'largest for years'");
            return MainArticles;
        }
        public void CompareArticles()
        {
            NewsListAdd();
            MainArticlesAdd();
            List<IWebElement> NewsList = NewsListAdd();
            List<String> MainArticles = MainArticlesAdd();
            for (int i = 0; i < MainArticles.Count; i++)
            {
                Assert.AreEqual(MainArticles[i], NewsList[i].Text);
            }
        }
    }
}
