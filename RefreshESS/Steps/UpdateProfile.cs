using OpenQA.Selenium;
using RefreshESS.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RefreshESS.Steps
{
    [Binding]
    class UpdateProfile 
    {         
        //Initializing page objects
        private readonly IWebDriver _driver;
       
        LoginPage page;// = new LoginPage();
        HomePage home;// = new HomePage();
        UpdateProfilePage profile;// = new UpdateProfilePage();

        public UpdateProfile(IWebDriver driver)
        {
            _driver = driver;
            page = new LoginPage(driver);
            home = new HomePage(driver);
            profile = new UpdateProfilePage(driver);
          

        }

        [Given(@"I have lanuched (.*) and entered (.*) with valid (.*) and (.*)")]
        public void GivenIHaveLanuchedHttpLocalhostAndEnteredQAWithValidBOWLSBYAnd(string url, string venue, string UserID, string Password)
        {
           // page.LaunchBrowser();
            page.EnterURL(url);
            page.EnterVenueDetails(venue);
            page.EnterLoginDetails(UserID, Password);
        }
        [Given(@"I navigate to ABIMM Main Page")]
        public void GivenINavigateToABIMMMainPage()
        {
            home = page.ClickLogin();
            home.IsHomePage();
        }

        [When(@"I click Update Profile Link")]
        public void WhenIClickUpdateProfileLink()
        {
            profile = home.ClickUpdateProfilePage();
            profile.IsUpdateProfilePage();
        }

                 
        [When(@"I edit the profile with (.*) and (.*) size")]
        public void ThenIWantToEditTheProfileWithAndSize(string hat, string shoe)
        {
            profile.ClearDetails();
            profile.FillDetails(hat, shoe);
        }



        //[When(@"I want to edit the profile")]
        //public void WhenIWantToEditTheProfile(Table table)
        //{
        //    profile.ClearDetails();
        //    dynamic var = table.CreateDynamicInstance();
        //    profile.FillDetails(var.Hats, var.Shoes);
        //}

        [When(@"I save changes")]
        public void WhenISaveChanges()
        { 
            home = profile.SaveChanges();
            home.IsHomePage();
        }
        [Then(@"I validate the changes are saved for (.*) and (.*)")]
        public void ThenIValidateTheChangesAreSavedForAnd(string hat, string shoe)
        {
            profile = home.ClickUpdateProfilePage();
            profile.IsUpdateProfilePage();
            profile.ValidateDetails(hat, shoe);
            home = profile.SaveChanges();
            home.IsHomePage();
            home.CloseBrowser();

        }

        

    }
}
