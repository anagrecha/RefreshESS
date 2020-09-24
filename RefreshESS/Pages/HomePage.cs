using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace RefreshESS.Pages
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) //: base()
        {
            this.driver = driver;
        }

        //Update Profile link
        public IWebElement LnkUpdateProfile => driver.FindElement(By.PartialLinkText("Profile"));

        public void IsHomePage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            //Validating the landed page
            Assert.IsTrue(driver.Title.Contains("Main Menu"));
        }

        public UpdateProfilePage ClickUpdateProfilePage()
        {
            //Click Update Profile Link
            LnkUpdateProfile.Click();

            return new UpdateProfilePage(driver);
        }

        public void CloseBrowser()
        {            
            driver.Quit();
            
        }

    }
}
