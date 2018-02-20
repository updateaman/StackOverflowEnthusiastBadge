using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace StackOverflowEnthusiastBadge
{
    public class LoginPageObject
    {
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "submit-button")]
        public IWebElement LoginButton { get; set; }

        public void Login(string email, string password)
        {
            EmailTextBox.SendKeys(email);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
        }
    }
}
