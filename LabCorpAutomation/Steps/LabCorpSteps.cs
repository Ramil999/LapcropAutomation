using Gherkin;
using LabCorpAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.ComponentModel.DataAnnotations;
using TechTalk.SpecFlow;

namespace LabCorpAutomation.Steps
{
    [Binding]
    public class LabCorpSteps
    {
        static IWebDriver driver;
        LabCorpPage labCorpPage;

        [BeforeTestRun]
        public static void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
          
        }

        [Given(@"I launch the application")]
        public void Ilaunchtheapplication()
        {
            driver.Url = "http://www.labcorp.com";
            labCorpPage = new LabCorpPage(driver);
        }

        [Given(@"I click on Career Link")]
        public void IclickonCareerLink()
        {
            labCorpPage.WaitForElement(10);
            labCorpPage.ClickCareerLink();
        }

        [When(@"I serach Job for QA Test Automation")]
        public void IserachJobforQATestAutomation()
        {
            labCorpPage.SearchJob("QA Test Automation");
        }
        [Then(@"I validate the Job is displayed in Job portal")]
        public void IvalidatetheJobisdisplayedinJobportal()
        {
            var jobCategory = labCorpPage.GetJobCategory();
            var jobId = labCorpPage.GetJobId();
            var jobType = labCorpPage.GetJobType();
            var jobTitle = labCorpPage.GetFirstJobTitle();

            labCorpPage.ClickFirstJob();

            labCorpPage.WaitForElement(100);
            var currentJobTitle = labCorpPage.GetCurrenttJobTitle();
            var currentJobId = labCorpPage.GeCurrenttJobId();
            var currentJobTypCss = labCorpPage.GetCurrentJobType();
            var currentJobCategory = labCorpPage.GetCurrentJobCategory();


            Assert.AreEqual(jobTitle, currentJobTitle,"Title does not match");
            Assert.AreEqual(jobId.Split(":")[1].Trim(), currentJobId.Split(":")[1].Trim(),"Job Id does not match");
            Assert.IsTrue(currentJobTypCss.Contains(jobType), "Job Type does not match");
            Assert.AreEqual(jobCategory, currentJobCategory,"Job Category does not match");

            labCorpPage.ClickApply();

            driver.SwitchTo().Window(driver.WindowHandles.First());
            //var title = driver.Title;         

        }

        [AfterTestRun]
        public static void TearDown()
        {
            driver.Quit();

        }

    }
}
