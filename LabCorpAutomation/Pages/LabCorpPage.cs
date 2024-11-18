using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabCorpAutomation.Pages
{
    public class LabCorpPage
    {
        IWebDriver driver;
        WebDriverWait wait;
        public LabCorpPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        #region Elements
        IWebElement career => driver.FindElement(By.XPath("//ul[@id='alantesting']//li//span[contains(text(),'Careers')]"));
        IWebElement acceptCookies => driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));     
        IWebElement searchInput => driver.FindElement(By.XPath("//input[@id='typehead']"));
        IWebElement searchButton => driver.FindElement(By.XPath("//button[@id='ph-search-backdrop']"));
        IWebElement jobCategory => driver.FindElement(By.XPath(" //p[@class='job-info']//span[@class='job-category']"));
        IWebElement jobId => driver.FindElement(By.XPath("//p[@class='job-info']//span[@class='au-target jobId']"));
        IWebElement jobType => driver.FindElement(By.XPath("//p[@class='job-info']//span[@class='au-target type']//span[2]"));
        IList<IWebElement> jobtitlesHeader => driver.FindElements(By.XPath("//div[@class='job-title']"));

        IWebElement currentJobTitle => driver.FindElement(By.XPath("//h1[@class='job-title']"));
        IWebElement currentJobId => driver.FindElement(By.XPath("//div[@class='Main-containter']/div[1]//span[3]/span"));
        IWebElement currentJobTypCss => driver.FindElement(By.CssSelector("span[class='au-target type']"));
        IWebElement currentJobCategory => driver.FindElement(By.XPath("//span[@class='au-target job-category']"));
        IWebElement applyButton => driver.FindElement(By.XPath("//div[@class='Sub-Actions']/a"));
        #endregion

        #region Methods
        public void SwitchToLastWindow(string lastWindow)
        {
            driver.SwitchTo().Window(lastWindow);
        }
        public string GetLastWindow()
        {
            return driver.WindowHandles.Last().ToString();
        }
       
        public void ClickCareerLink()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(career));
            acceptCookies.Click();
            career.Click();
        }

        public void SearchJob(string jobTitle)
        {
            SwitchToLastWindow(GetLastWindow());
            searchInput.SendKeys(jobTitle);
            searchButton.Click();
        }
        public string GetJobCategory()
        {
            return jobCategory.Text;
        }

        public string GetJobId()
        {
            return jobId.Text;
        }
        public string GetJobType()
        {
            return jobType.Text;
        }
        public string GetFirstJobTitle()
        {
            return jobtitlesHeader.First().Text;
        }
        public void ClickFirstJob()
        {
            jobtitlesHeader.First().Click();
        }

        public string GetCurrentJobCategory()
        {
            return currentJobCategory.Text;
        }

        public string GeCurrenttJobId()
        {
            return currentJobId.Text;
        }
        public string GetCurrentJobType()
        {
            return currentJobTypCss.Text;
        }
        public void WaitForElement(int seconds)
        {
             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
           
        }
        public string GetCurrenttJobTitle()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(currentJobTitle));
            return currentJobTitle.Text;
        }

        public void ClickApply()
        {
          
            applyButton.Click();

        }
        #endregion
    }
}
