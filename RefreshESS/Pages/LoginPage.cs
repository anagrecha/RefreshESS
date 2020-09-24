using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace RefreshESS.Pages
{
    [Binding]
    class LoginPage : BasePage
    {
        //IWebDriver _driver;

        // public LoginPage() => _driver = driver;

        public LoginPage(IWebDriver driver) //: base()
        {
            this.driver = driver;
        }

        //Venue ID
        public IWebElement TxtvenueID => driver.FindElement(By.Id("input_venue"));
        //Submit button
        public IWebElement BtnSubmit => driver.FindElement(By.XPath("//input[contains(@value,'Submit')]"));
        //UserID
        public IWebElement TxtuserID => driver.FindElement(By.Id("LoginId"));
        //PIN
        public IWebElement Txtpassword => driver.FindElement(By.Id("PIN"));
        //Login button
        public IWebElement BtnLogIn => driver.FindElement(By.XPath("//input[contains(@value,'Log In')]"));

        //Launch browser
        public void LaunchBrowser()
        {
            driver.Manage().Window.Maximize();
        }

        //Enter URL and validate the landed page
        public void EnterURL(string url)
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            driver.Navigate().GoToUrl(url);
            //Assert.IsTrue(_driver.Title.StartsWith("ABI MasterMind"));
        }

        //Enter Venue detail
        public void EnterVenueDetails(string venueId)
        {
            TxtvenueID.SendKeys(venueId);
            BtnSubmit.Click();
        }

        //Enter credentials
        public void EnterLoginDetails(string userId, string password)
        {
            TxtuserID.SendKeys(userId);
            Txtpassword.SendKeys(password);
        }

        //Click Login button to land to Home Page
        public HomePage ClickLogin()
        {
            BtnLogIn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            return new HomePage(driver);
        }

        


    }
}
