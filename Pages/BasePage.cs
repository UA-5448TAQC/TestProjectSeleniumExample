using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectSeleniumExample.Infrastructure;

namespace TestProjectSeleniumExample.Pages
{
    public abstract class BasePage: Base
    {
        protected BasePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetTitle()
        {
            return driver.Title;
        }
        public string GetUrl()
        {
            return driver.Url;
        }

    }
}
    