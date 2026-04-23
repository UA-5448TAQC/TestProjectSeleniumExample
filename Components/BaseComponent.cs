using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectSeleniumExample.Infrastructure;

namespace TestProjectSeleniumExample.Components
{

    
    abstract class BaseComponent : Base
    {
        protected IWebElement rootElement;

        protected BaseComponent(IWebDriver driver, IWebElement rootElement) : base(driver)
        {
            this.rootElement = rootElement;
        }


    }
}
