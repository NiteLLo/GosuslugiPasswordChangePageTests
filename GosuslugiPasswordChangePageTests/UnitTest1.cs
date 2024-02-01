using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GosuslugiPasswordChangePageTests
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By signInButton = By.XPath("//button[@class=\"reset link-plain login-button ng-star-inserted\"]");
        private readonly By canNotLogInButton = By.XPath("//button[@class=\"plain-button-inline\"] [text()=' Не удаётся войти? ']");
        private readonly By passwordRecoveryButton = By.XPath("//button[@class=\"plain-button-inline\"] [text()=' восстановления пароля ']");

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru");
        }

        [Test]
        public void Test1()
        {          
            var signIn = WaitUntilElementClickable(signInButton);
            signIn.Click();

            var canNotLogIn = WaitUntilElementClickable(canNotLogInButton);
            canNotLogIn.Click();

            var passwordRecovery = WaitUntilElementClickable(passwordRecoveryButton);
            passwordRecovery.Click();

            Assert.IsTrue(driver.Url == "https://esia.gosuslugi.ru/login/recovery");
        }

        /// <summary>
        /// Метод для ожидания загрузки элемента интефейса
        /// </summary>
        /// <param name="elementLocator">искомый элемент</param>
        /// <param name="timeout">время ожидания между проверками</param>
        /// <returns></returns>

        public IWebElement WaitUntilElementClickable(By elementLocator, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(x => x.FindElement(elementLocator));
        }
    }
}