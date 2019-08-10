using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace UnitTestProject3
{
    public class HaveYouSayPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.bbc.com/news/uk-47933096";
        private int count = -1;
        [FindsBy(How = How.XPath, Using = "//*[@class='hearken-embed cleanslate']/div[1]/div[7]/button")]
        private IWebElement submitButton { get; set; }
        string errorText = "Name can't be blank";

        private void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }
        public HaveYouSayPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }

        public Dictionary<string, IWebElement> Inputs()
        {
            Dictionary<string, IWebElement> inputs = new Dictionary<string, IWebElement>();
            inputs.Add("inputForm", driver.FindElement(By.XPath("//*[@class='hearken-embed cleanslate']/div[1]/div[1]/textarea")));
            inputs.Add("inputName", driver.FindElement(By.XPath("//*[@class='hearken-embed cleanslate']/div[1]/div[3]/div[1]/div/label/input")));
            inputs.Add("inputEmail", driver.FindElement(By.XPath("//*[@class='hearken-embed cleanslate']/div[1]/div[3]/div[2]/div/label/input")));
            inputs.Add("inputAge", driver.FindElement(By.XPath("//*[@class='hearken-embed cleanslate']/div[1]/div[3]/div[3]/div/label/input")));
            inputs.Add("inputPostCode", driver.FindElement(By.XPath("//*[@class='hearken-embed cleanslate']/div[1]/div[4]/label/input")));

            return inputs;
        }
        private List<string> FillInInfoList()
        {
            List<string> fillInfoList = new List<string>();
            fillInfoList.Add("");
            fillInfoList.Add("My NAme");
            fillInfoList.Add("ddd@com.ua");
            fillInfoList.Add("19");
            fillInfoList.Add("11111");
            return fillInfoList;
        }

        public void Fillform(string someText = "don't try to mess with my code!", bool status = false)
        {
            Navigate();
            int breakingNewsButtonList = driver.FindElements(By.XPath("//*[@id='breaking-news-container']/div/div/button")).Count;
            if (breakingNewsButtonList > 0)
            {
                IWebElement breakingNewsButton = driver.FindElement(By.XPath("//*[@id='breaking-news-container']/div/div/button"));
                breakingNewsButton.Click();
            }
        Dictionary<string, IWebElement> inputs = Inputs();
            if (status==false)
            {
                
                inputs["inputForm"].Click();
                inputs["inputForm"].SendKeys(someText);
                foreach (string key in inputs.Keys)
                {
                    inputs[key].Click();
                    inputs[key].SendKeys(myInfo(false));
                }
                ScrenshotMaker();
            }
            else
            {
                inputs["inputForm"].Click();
                inputs["inputForm"].SendKeys(someText);
                foreach (string key in inputs.Keys)
                {
                    inputs[key].Click();
                    inputs[key].SendKeys(myInfo(true));
                }
                submitButton.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                IWebElement inputName = driver.FindElement(By.XPath("//*[@class='hearken-embed cleanslate']/div[1]/div[3]/div[1]/div/label/div"));
                Assert.AreEqual(errorText, inputName.Text);
            }
        }    
        private string myInfo(bool choice)
        {
            List<string> fillInfoList = FillInInfoList();
            count++;
            if (count == 1 && choice == true)
            {
                fillInfoList[1] = "";
            }
            if (count > 4)
            {
                count = -1;
            }
            return fillInfoList[count];
        }

        private void ScrenshotMaker()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(@"C:\Users\admin\Desktop\HelloWorld\QA\Автоматизация\HOMETASK!!!!\UnitTestProject3\UnitTestProject3\screenshot\SeleniumTestingScreenshot.jpg");
        }

    }
}
