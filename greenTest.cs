using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TestProjectSeleniumExample.Components;
using TestProjectSeleniumExample.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace TestProjectSeleniumExample
{
    public class GreenCityTests
    {
        private ChromeDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Navigate().GoToUrl("https://www.greencity.cx.ua/#/greenCity/news");
            Thread.Sleep(2000);
        }

        [Test]
        public void Test1()
        {
              EcoNewsPage ecoNewsPage = new EcoNewsPage(driver);
              string title = ecoNewsPage.GetTitle();
               Assert.That(title, Is.EqualTo("GreenCity — Eco Service to Save the Planet"));
               Assert.That(ecoNewsPage.GetUrl(), Is.EqualTo("https://www.greencity.cx.ua/#/greenCity/news"));
                Assert.That(ecoNewsPage.ItemFound().Text, Is.EqualTo("2507 items found"));
                Assert.That(ecoNewsPage.ItemsDescriptions().Count, Is.EqualTo(12));
            Assert.Multiple(() =>
            {
                Assert.That(ecoNewsPage.ItemsDescriptions()[0].Text, Is.EqualTo("Upcoming environmental event"));
                Assert.That(ecoNewsPage.ItemsDescriptions()[1].Text, Is.EqualTo("New eco-friendly product launch"));
                Assert.That(ecoNewsPage.ItemsDescriptions()[2].Text, Is.EqualTo("Climate change update"));
      
            });
            Assert.Multiple(() =>
            {
                Assert.That(ecoNewsPage.FilterTags()[0].Text, Is.EqualTo("EVENTS"));
                Assert.That(ecoNewsPage.FilterTags()[1].Text, Is.EqualTo("EDUCATION|\r\nADS"));
                Assert.That(ecoNewsPage.FilterTags()[2].Text, Is.EqualTo("NEWS|\r\nEVENTS"));
            });

        }
        [Test]
        public void TestCard()
        {
            EcoNewsPage ecoNewsPage = new EcoNewsPage(driver);
            string title = ecoNewsPage.GetTitle();
            Assert.That(title, Is.EqualTo("GreenCity — Eco Service to Save the Planet"));
            Assert.That(ecoNewsPage.GetUrl(), Is.EqualTo("https://www.greencity.cx.ua/#/greenCity/news"));
            Assert.That(ecoNewsPage.ItemFound().Text, Is.EqualTo("2507 items found"));
            List<EcoNewsCard> cards = ecoNewsPage.GetNewsCards();
            Assert.That(cards.Count, Is.EqualTo(12));

            List<(String, List<String>)> expected = new List<(String, List<String>)>
            {
                ("Upcoming environmental event", new List<String> { "EVENTS" }),
                ("New eco-friendly product launch", new List<String> { "EDUCATION", "ADS" }),
                ("Climate change update", new List<String> { "NEWS", "EVENTS" })
            };

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(cards[i].GetDescription(), Is.EqualTo(expected[i].Item1), $"Description for card '{expected[i].Item1}' does not match expected description.");
                    CollectionAssert.AreEquivalent(expected[i].Item2, cards[i].GetTags(), $"Tags for card '{expected[i].Item1}' do not match expected tags.");
                
                });
            }
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