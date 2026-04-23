using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectSeleniumExample.Infrastructure
{
    public abstract class Base
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected Base(IWebDriver driver) { 
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
