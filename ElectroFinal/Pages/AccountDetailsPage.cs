using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace ElectroFinal.Pages
{
    public class AccountDetailsPage
    {
        IWebDriver driver;

        By accountDetailsLinkLocator = By.XPath("//*[@id=\"post-3854\"]/div/div/nav/ul/li[6]/a");
        By firstNameFieldLocator = By.Id("account_first_name");
        By lastNameFiedLocator = By.Id("account_last_name");
        By displayNameFiedLocator = By.Id("account_display_name");
        By saveChangesButtonLocator = By.XPath("//*[@id=\"post-3854\"]/div/div/div/form/p[5]/button");
        By loggedInlMessageLocator = By.CssSelector("div.woocommerce-message");
        By currentPasswordFieldLocator = By.Id("password_current");
        By newPasswordFieldLocator = By.Id("password_1");
        By confirNewPasswordFieldLocator = By.Id("password_2");
        By accountDetailMessageLocator = By.CssSelector("div.woocommerce-message");
        By logOutLinkLocator = By.LinkText("Logout");

        string FirstName = "Mimi";
        string LastName = "Jovanova";
        string DisplayName = "Mimik";
        string CurrentPasswort = "mimik@gmail.com";
        string NewPassword = "mimik@gmail.com";
        string ConfirmNewPassword = "mimik@gmail.com";

        public AccountDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void clickAccountDetailsLink()
        {

            IWebElement AccountDetailsLink = driver.FindElement(accountDetailsLinkLocator);
            AccountDetailsLink.Click();
        }
        public void enterFirstName()
        {
            IWebElement firstNameField = driver.FindElement(firstNameFieldLocator);
            firstNameField.Clear();
            firstNameField.SendKeys(FirstName);
        }
        public void enterLastName()
        {
            IWebElement lastNameFied = driver.FindElement(lastNameFiedLocator);
            lastNameFied.Clear();
            lastNameFied.SendKeys(LastName);
        }

        public void enterDislayName()
        {
            IWebElement displayNameFied = driver.FindElement(displayNameFiedLocator);
            displayNameFied.Clear();
            displayNameFied.SendKeys(DisplayName);
        }
        public void clickSaveChangesButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement saveChangesButton = driver.FindElement(saveChangesButtonLocator);
            IWebElement saveChangesButton1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"post-3854\"]/div/div/div/form/p[5]/button")));

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()",saveChangesButton);
        }
        public void VerifyThatAccountDetailMessageisDisplay()
        {
            IWebElement logInMessage = driver.FindElement(loggedInlMessageLocator);
            string message = logInMessage.GetAttribute("value");

            Assert.That(driver.FindElement(loggedInlMessageLocator).Displayed);
            Console.WriteLine("The'Account details changed successfully' message was successfully displayed");
        }

        public void currentPasswordField()
        {
            IWebElement currentPasswordField = driver.FindElement(currentPasswordFieldLocator);
            currentPasswordField.Clear();
            currentPasswordField.SendKeys(CurrentPasswort);

        }

        public void newPasswordField()
        {
            IWebElement newPasswordField = driver.FindElement(newPasswordFieldLocator);
            newPasswordField.Clear();
            newPasswordField.SendKeys(NewPassword);
        }

        public void confirmNewPasswordField()
        {
            IWebElement confirmNewPasswordField = driver.FindElement(confirNewPasswordFieldLocator);
            confirmNewPasswordField.Clear();
            confirmNewPasswordField.SendKeys(ConfirmNewPassword);
        }
        public void VerifyThatAccountDetailsChanged()
        {
            IWebElement accountDetailsMessage = driver.FindElement(accountDetailMessageLocator);
            string message = accountDetailsMessage.GetAttribute("value");

            Assert.That(driver.FindElement(accountDetailMessageLocator).Displayed);
            Console.WriteLine("The 'Account details changed successfully' message was successfully displayed");
        }
        public void clickLogOutLink()
        {
            IWebElement logOutLink = driver.FindElement(logOutLinkLocator);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement logOutLink1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Logout")));

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", logOutLink);

        }

      
       
    }
}
