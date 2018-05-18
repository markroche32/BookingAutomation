

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace UnitTestProject1
{
    class BookingPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = @"ss")]
        public IWebElement Destination { get; set; }

        [FindsBy(How = How.Id, Using = @"group_adults")]
        public IWebElement AdultsDropdown { get; set; }

        [FindsBy(How = How.Id, Using = @"no_rooms")]
        public IWebElement RoomsDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@class='c2-button c2-button-further']")]
        public IWebElement GoRight { get; set; }

        [FindsBy(How = How.XPath, Using = @"//button//span[text()='Search']")]
        public IWebElement Search { get; set; }

        [FindsBy(How = How.XPath, Using = @"//a[@data-id='popular_activities-10']")]
        public IWebElement SaunaFiter { get; set; }

        [FindsBy(How = How.XPath, Using = @"//a[@data-id='class-5']")]
        public IWebElement Star5Fiter { get; set; }
        
       
        public BookingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginToApplication()
        {
      
        }


        public IWebElement DestinationListItem(string destination)
        {

            return driver.FindElement(By.XPath("//li//b[contains(text(),'" + destination + "')]")); ;

        }


        public IWebElement SelectCalendarDayMonth(string day , string month)
        {

            return driver.FindElement(By.XPath("(//*[contains(text(), '" + month + "')]/ancestor::thead/following-sibling::tbody//td[contains(@class, 'c2-day')]//span[contains(text(),'" + day + "')])[1]")); 

        }


        public IWebElement ReturnSearchResultByHotel(string hotel)
        {

            return driver.FindElement(By.XPath("//span[contains(@class, 'sr-hotel__name') and contains(text(), '" + hotel + "')]"));

        }

        public bool ClickCalendarDayMonth(string day, string month)
        {
            var i = 0;

            //3 months from 2days date should be never be further than GoRight x 5
            while (i < 5)
            {
                try
                {
                    SelectCalendarDayMonth(day, month).Click(driver);
                    return true;
                }
                catch (Exception)
                {
                    //Date Is Not Visible => Clickable => Go Right 
                    GoRight.Click(driver);
                    Thread.Sleep(2000);
                }
            }

            return false;
        }

    }

}
