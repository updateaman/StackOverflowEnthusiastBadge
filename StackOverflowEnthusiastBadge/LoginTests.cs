using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.PageObjects;

namespace StackOverflowEnthusiastBadge
{
    [TestClass]
    public class LoginTests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void MyTest(string chromePath = null)
        {
            var path = chromePath ?? System.Environment.CurrentDirectory;
            var options = new PhantomJSOptions();

            using (var webDriver = new PhantomJSDriver(path, options) { Url = "https://stackoverflow.com/users/login" })
            {
                Wait(webDriver, "Log In - Stack Overflow");
                Assert.AreEqual("Log In - Stack Overflow", webDriver.Title);

                var loginPageObject = new LoginPageObject();
                PageFactory.InitElements(webDriver, loginPageObject);

                var username = ConfigurationManager.AppSettings["Username"];
                var password = ConfigurationManager.AppSettings["Password"];

                loginPageObject.Login(username, password);

                Wait(webDriver, "Stack Overflow - Where Developers Learn, Share, & Build Careers");

                Assert.AreEqual("Stack Overflow - Where Developers Learn, Share, & Build Careers", webDriver.Title);

                var questionList = webDriver.FindElements(By.CssSelector(".question-summary.narrow.tagged-interesting"));

                Assert.IsTrue(questionList.Count > 1);

            }
        }

        private static void Wait(IWebDriver webDriver, string title, int retryCount = 5)
        {
            var count = retryCount;
            while (count > 0)
            {
                if (webDriver.Title != title) Thread.Sleep(1000);
                count--;
            }
        }
        
    }
}
