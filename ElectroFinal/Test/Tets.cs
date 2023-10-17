using ElectroFinal.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;


namespace ElectroFinal.Test
{
    [TestFixture]
    public class Tets
    {
        IWebDriver driver;
        MyAccountPage myAccountPageObject;
        AccountDetailsPage accountDetailsPageObject;


        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://electro.madrasthemes.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            myAccountPageObject = new MyAccountPage(driver);
            accountDetailsPageObject = new AccountDetailsPage(driver);
        }

        [Test]
        public void LogInToElectro()
        {
            myAccountPageObject.clickMyAccountLink();
            myAccountPageObject.enterEmail();
            myAccountPageObject.passwordField();
            myAccountPageObject.clickLoInButton();
            myAccountPageObject.VerifyThatUserIsLoggedIn();
        }

        [Test]
        public void ChangeAccountDetails()
        {
            myAccountPageObject.clickMyAccountLink();
            myAccountPageObject.enterEmail();
            myAccountPageObject.passwordField();
            myAccountPageObject.clickLoInButton();
            accountDetailsPageObject.clickAccountDetailsLink();
            accountDetailsPageObject.enterFirstName();
            accountDetailsPageObject.enterLastName();   
            accountDetailsPageObject.enterDislayName();
            accountDetailsPageObject.clickSaveChangesButton();
            accountDetailsPageObject.VerifyThatAccountDetailMessageisDisplay();
            

        }

        [Test]
        public void ChangePassword() 
        {
            myAccountPageObject.clickMyAccountLink();
            myAccountPageObject.enterEmail();
            myAccountPageObject.passwordField();
            myAccountPageObject.clickLoInButton();
            accountDetailsPageObject.clickAccountDetailsLink();
            accountDetailsPageObject.enterFirstName();
            accountDetailsPageObject.enterLastName();
            accountDetailsPageObject.enterDislayName();
            accountDetailsPageObject.currentPasswordField();
            accountDetailsPageObject.newPasswordField();
            accountDetailsPageObject.confirmNewPasswordField();
            accountDetailsPageObject.clickSaveChangesButton();
            accountDetailsPageObject.VerifyThatAccountDetailsChanged(); 
            accountDetailsPageObject.clickLogOutLink();
            myAccountPageObject.clickMyAccountLink();
            myAccountPageObject.enterEmail();
            myAccountPageObject.passwordField();
            myAccountPageObject.clickLoInButton();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
