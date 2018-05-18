using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public static class WebDriverUtil
    {


        public static void Click(this IWebElement element, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

            element.Click();
        }


        public static void SetText(this IWebElement element, IWebDriver driver, string textToEnter)
        {

            element.SendKeys(textToEnter);

        }


        public static string GetText(this IWebElement element, IWebDriver driver)
        {

            return null;
        }

        public static void PickDropdownByText(this IWebElement element, IWebDriver driver, string choice)
        {

            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(choice);

        }
    }
}
