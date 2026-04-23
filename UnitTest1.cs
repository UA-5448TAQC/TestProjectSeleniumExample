using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using static System.Net.Mime.MediaTypeNames;

namespace TestProjectSeleniumExample
{
    public class Tests
    {
        private ChromeDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            Thread.Sleep(2000);
        }

        [Test]
        public void Test1()
        {

            //string title = driver.Title;
            var titleElement = driver.FindElement(By.TagName("title"));
            string title = titleElement.GetAttribute("innerHTML");
            Assert.That(title, Is.EqualTo("Web form"));

            var textInput = driver.FindElement(By.Id("my-text-id"));
            //textInput.Clear();
            textInput.SendKeys(Keys.Control + "a");
            textInput.SendKeys(Keys.Delete);
            textInput.SendKeys("Selenium");

            var option = driver.FindElements(By.TagName("option"));
            Assert.That(option.Count, Is.EqualTo(9));

            var rootMyOptions = driver.FindElement(By.Id("my-options"));
            var option2 = rootMyOptions.FindElements(By.TagName("option"));
            Assert.That(option2.Count, Is.EqualTo(5));
            var myDetails = driver.FindElement(By.XPath("//input[@name='my-datalist']"));
            myDetails.Click();
            var op = option2[1].GetAttribute("value");
            myDetails.SendKeys(op);
            var element = driver.FindElement(By.XPath("//input[@id='my-check-1']/../.."));
            Assert.That(element.Text, Is.EqualTo("Checked checkbox\r\nDefault checkbox"));
            var myFile = driver.FindElement(By.Name("my-file"));

            new Actions(driver)
                .MoveToElement(myFile)
                .Pause(TimeSpan.FromSeconds(1))
                .Perform();

        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2000);
            driver.Quit();
            //driver.Close();
        }
    }
}