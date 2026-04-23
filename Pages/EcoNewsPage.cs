using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectSeleniumExample.Components;

namespace TestProjectSeleniumExample.Pages
{
    class EcoNewsPage : BasePage
    {

        private readonly By itemsFoundLocator = By.TagName("h2");
        private readonly By itemsDescriptionLocator = By.TagName("h3");
        private readonly By filterTagLocator = By.XPath("//div[@class='filter-tag']");
        private readonly By ecoNewsItemLocator = By.XPath("//ul[@aria-label='news list']/li");

        public EcoNewsPage(IWebDriver driver) : base(driver)
        {
        }


        public IWebElement ItemFound()
        {
            return driver.FindElement(itemsFoundLocator);
        }
        public List<IWebElement> ItemsDescriptions()
        {
            return driver.FindElements(itemsDescriptionLocator).ToList();
        }
        public List<IWebElement> FilterTags()
        {
            return driver.FindElements(filterTagLocator).ToList();
        }
        public string GetItemsFound()
        {
            return ItemFound().Text;
        }
        public int GetItemsFoundNumber()
        {
            string itemsFoundText = ItemFound().Text;
            string numberOnly = new string(itemsFoundText.Where(char.IsDigit).ToArray());
            return int.Parse(numberOnly);
        }

        protected List<IWebElement> GetEcoNewsItems()
        {
            return driver.FindElements(ecoNewsItemLocator).ToList();
        }
        public List<EcoNewsCard> GetNewsCards()
        {
            List<IWebElement> ecoNewsItems = GetEcoNewsItems();
            List<EcoNewsCard> newsCards = ecoNewsItems.Select(item => new EcoNewsCard(driver, item)).ToList();
            return newsCards;
        }
    }
}
