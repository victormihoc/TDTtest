using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace RegatulJocurilorTests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1080);
        }

        [Test]
        public void Run()
        {
            driver.Navigate().GoToUrl("https://regatuljocurilor.ro/ro/contact");

            IWebElement mailInput = driver.FindElement(By.XPath("//*[@id=\"content\"]/section/form/section/div[3]/div/input"));
            mailInput.Clear();
            mailInput.SendKeys("mihocvictor@gmail.com");

            IWebElement messageInput = driver.FindElement(By.XPath("//*[@id=\"content\"]/section/form/section/div[5]/div/textarea"));
            messageInput.Clear();
            messageInput.SendKeys("Buna ziua");

            IWebElement sendButton = driver.FindElement(By.XPath("//*[@id=\"content\"]/section/form/footer/input[3]"));
            sendButton.Click();
            Thread.Sleep(1000);

            IWebElement succesMessage = driver.FindElement(By.XPath("//*[@id=\"content\"]/section/form/div/ul/li"));
            Assert.IsTrue(succesMessage != null);

        }

        [TearDown]
        public void TearDown()
        {
            // Close the driver and the browser
            driver.Quit();
        }
    }
}