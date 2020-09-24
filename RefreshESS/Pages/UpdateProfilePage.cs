using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RefreshESS.Pages
{
    [Binding]
    class UpdateProfilePage : BasePage
    {
        //IWebDriver driver;
        ////public UpdateProfilePage() => driver = driver;
        //public UpdateProfilePage(IWebDriver webDriver) => driver = webDriver;

        public UpdateProfilePage(IWebDriver driver) //: base()
        {
            this.driver = driver;
        }
        public IWebElement TxtHat => driver.FindElement(By.Id("Hat"));
        public IWebElement TxtShoe => driver.FindElement(By.Id("Shoe"));
        public IWebElement TxtVest => driver.FindElement(By.Id("Vest"));
        public IWebElement TxtInseam => driver.FindElement(By.Id("Inseam"));

        public IWebElement BtnSubmit => driver.FindElement(By.Id("submit_button")); 

        //Validate landed page
        public void IsUpdateProfilePage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            Assert.IsTrue(driver.Title.Contains("Update"));
        }

        public void ClearDetails()
        {
            TxtHat.Clear();
            TxtShoe.Clear();
            
        }
        //Enter details to edit the profile
        public void FillDetails (string hat, string shoe)
        {
            TxtHat.SendKeys(hat);
            TxtShoe.SendKeys(shoe);
         }

        

        //Validate details to edit the profile
        public void ValidateDetails(string hat, string shoe)
        {
            if (TxtHat.GetAttribute("value") == hat && TxtShoe.GetAttribute("value") == shoe)
            {
                Assert.IsTrue(TxtHat.GetAttribute("value") == hat);
                Assert.IsTrue(TxtShoe.GetAttribute("value") == shoe);
            }

        }
        //Save changes to return to Home Page
        public HomePage SaveChanges()
        {
            BtnSubmit.Click();
            return new HomePage(driver);
        }

        public void CloseBrowser()
        {

            driver.Quit();
            driver.Dispose();
            driver = null;
        }



    }
}
