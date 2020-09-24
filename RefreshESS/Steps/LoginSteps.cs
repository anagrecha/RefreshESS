using OpenQA.Selenium;
using RefreshESS.Pages;
using TechTalk.SpecFlow;

namespace RefreshESS.Steps
{
    [Binding]
    class LoginSteps
    {
        //Initializing page objects
        private readonly IWebDriver _driver;
        LoginPage login;// = new LoginPage();
        HomePage home;// = new HomePage();

        public LoginSteps (IWebDriver driver)
        {
            _driver = driver;
            login = new LoginPage(driver);
            home = new HomePage(driver);           
        }


       

        [Given(@"I have launched the browser to enter ABIMM (.*)")]
        public void GivenIHaveLaunchedTheBrowserToEnterABIMMHttpLocalhost(string url)
        {
            //login.LaunchBrowser();
         //  _scenarioContext[LoginPage] = login;
            login.EnterURL(url);
        }

        [Given(@"I have given the (.*)")]
        public void GivenIHaveGivenThe(string venue)
        {
            login.EnterVenueDetails(venue);
        }

        [Given(@"I entered (.*) and (.*)")]
        public void GivenIEnteredBOWLSBYAnd(string userID, string pin)
        {
            login.EnterLoginDetails(userID, pin);
        }

        [Then(@"I should be should be in ABIMM Main Page")]
        public void ThenIShouldBeShouldBeInABIMMMainPage()
        {
            home = login.ClickLogin();
            home.IsHomePage();
            home.CloseBrowser();

        }


    }
}
