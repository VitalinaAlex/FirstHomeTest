using OpenQA.Selenium;

namespace Testfirst
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly String test_url = "https://www.google.com.ua/";
        private readonly By locatorLogo = By.XPath("//img[@class='lnXdpd']");
        private readonly By locatorImages = By.XPath("//img");
        private readonly By locatorImage = By.XPath("//a[(text()='Images')]");

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl(test_url);
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void FindLogoImage()
        {
            try
            {
                driver.FindElement(locatorLogo).Click();
            }
            catch (NoSuchElementException)
            {
            }
        }

        [Test]
        public void IfImageDisplayed()
        {
            IWebElement clickImages = driver.FindElement(locatorImages);
            bool imagePresent = clickImages.Displayed;
            Assert.IsTrue(imagePresent, "The image is not exist.");
        }

        [Test]

        public void FindImagesOnImageTab()
        {
            IWebElement clickImages = driver.FindElement(locatorImage);
            clickImages.Click();
            IWebElement findImages = driver.FindElement(locatorImages);
            findImages.Click();
        }
        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}

