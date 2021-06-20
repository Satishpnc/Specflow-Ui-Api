using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebLibrary.Pages
{
    public abstract class PageBase : LoadableComponent<PageBase>
    {
        public IWebDriver _driver { get; }
        protected WebDriverWait _wait;
        protected const int DefaultTimeout = 30;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, new TimeSpan(0, 0, DefaultTimeout));
        }
        public IWebDriver Driver
        {
            get { return _driver; }
        }
        public WebDriverWait Wait
        {
            get { return _wait; }
        }

        public void WaitForElement(IWebElement element, int timeout = 60)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until<bool>(driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
        protected override void ExecuteLoad()
        {
        }
    }
}
