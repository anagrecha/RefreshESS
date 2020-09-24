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

    public sealed class Hooks : BasePage
    {
        public IWebDriver Driver;   
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        public static AventStack.ExtentReports.ExtentReports Extent;

        private readonly ScenarioContext _scenarioContext;
                      
        public Hooks(ScenarioContext scenarioContext, IWebDriver driver)
        {            
           _scenarioContext = scenarioContext;
            Driver = driver;
        }


        [BeforeTestRun]
        public static void IntializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\anagrecha\source\repos\new\RefreshESS\Index.html");
            //htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            Extent = new AventStack.ExtentReports.ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }
        
        [BeforeFeature]
        public static void CreateFeature(FeatureContext featureContext)
        {
            featureName = Extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void CreateScenario()
        {
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);            
        }            

        [AfterStep]
        public void InsertReportingSteps()
        {

            // var StepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var StepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (StepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (StepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                else if (StepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (StepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                //screenshot in Base64 format
                var mediaEntity = CaptureScreeshot(_scenarioContext.ScenarioInfo.Title.Trim());
                if (StepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (StepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (StepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (StepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                else if (StepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                else if (StepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
            }

        }

        [AfterTestRun]
        public static void FlushExtent()
        {
            Extent.Flush();
        }
       
    }

}
