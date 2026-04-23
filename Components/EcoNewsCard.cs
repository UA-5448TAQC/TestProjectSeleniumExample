using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectSeleniumExample.Components
{
    class EcoNewsCard: BaseComponent
    {
        private readonly By DescriptionLocator = By.TagName("h3");
        private readonly By filterTagLocator = By.XPath(".//div[@class='filter-tag']");
        public EcoNewsCard(IWebDriver driver, IWebElement rootElement) : base(driver, rootElement)
        {
        }

        public string GetDescription()
        {
            return rootElement.FindElement(DescriptionLocator).Text;
        }
        public IWebElement FilterTagsElement()
        {
            return rootElement.FindElement(filterTagLocator);
        }
        public List<String> GetTags()
        {
            string filterTagText = FilterTagsElement().Text;
            List<String> tags = filterTagText
                .Split(new[] { "\r\n", "\r", "\n", "|" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Console.WriteLine($" {GetDescription()} Tags '{filterTagText}': {string.Join(", ", tags)}");
            return tags;
        }
        public void Click()
        {
            rootElement.Click();
        }
    }
}
