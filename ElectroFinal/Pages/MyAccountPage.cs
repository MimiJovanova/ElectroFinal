using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace ElectroFinal.Pages
{
    public class MyAccountPage
    {
        IWebDriver driver;


        By myAccountLinkLocator = By.LinkText("My Account");
        By emailFieldLocator = By.Id("username");
        By passwordFieldLocator = By.Id("password");
        By logInButtondLocator = By.XPath("//*[@id=\"customer_login\"]/div[1]/form/p[4]/button");
        By loggedInlMessageLocator = By.XPath("//*[@id=\"post-3854\"]/div/div/div/p[1]/strong[2]");

        string email = "mimik@gmail.com";
        string password = "mimik@gmail.com";




        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void clickMyAccountLink()
        {

            IWebElement MyAccountLink = driver.FindElement(myAccountLinkLocator);
            MyAccountLink.Click();
        }
        public void enterEmail()
        {
            IWebElement emailField = driver.FindElement(emailFieldLocator);
            emailField.Clear();
            emailField.SendKeys(email);
        }

        public void passwordField()
        {
            IWebElement passwordField = driver.FindElement(passwordFieldLocator);
            passwordField.Clear();
            passwordField.SendKeys(password);
        }
        public void clickLoInButton()
        {
            IWebElement loInButton = driver.FindElement(logInButtondLocator);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement logInButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"customer_login\"]/div[1]/form/p[4]/button")));


            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click();", loInButton);
        }

        public void VerifyThatUserIsLoggedIn()
        {
            IWebElement logInMessage = driver.FindElement(loggedInlMessageLocator);
            string message = logInMessage.GetAttribute("value");

            Assert.That(driver.FindElement(loggedInlMessageLocator).Displayed);
            Console.WriteLine("The user is successfully logged in on the 'My Account' page");
        }
        





    }
}
