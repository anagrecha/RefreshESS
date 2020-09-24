using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using RefreshESS.Pages;
using OpenQA.Selenium;
using BoDi;
using OpenQA.Selenium.Firefox;

namespace RefreshESS
{
    [Binding]
    public class DriverSetup
    {
        private IObjectContainer _objectContainer;
        public IWebDriver Driver;

        public DriverSetup (IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new FirefoxDriver();
            _objectContainer.RegisterInstanceAs(Driver);
        }

    }
}
