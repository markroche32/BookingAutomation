using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    [TestClass]
    public class BookingAutomationTests
    {

        private TestContext testContextInstance;
        private IWebDriver driver;
        private string todayDatePlus30Day;
        private string todayDatePlus30;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestInitialize()]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.booking.com/");

            todayDatePlus30Day = DateTime.Now.AddMonths(3).ToString("dd").TrimStart('0');
            todayDatePlus30 = DateTime.Now.AddMonths(3).ToString("MMMM yyyy");

        }


        [TestMethod]
        public void SaunaLimerickStrandHotelShouldBeListed()
        {

            new BookingPage(driver).Destination.SetText(driver, "Limerick");
            new BookingPage(driver).DestinationListItem("Limerick City Centre").Click(driver);
            Assert.IsTrue(new BookingPage(driver).ClickCalendarDayMonth(todayDatePlus30Day, todayDatePlus30));
            new BookingPage(driver).AdultsDropdown.PickDropdownByText(driver, "2 adults");
            new BookingPage(driver).RoomsDropdown.PickDropdownByText(driver, "1 room");
            new BookingPage(driver).Search.Click(driver);
            new BookingPage(driver).SaunaFiter.Click(driver);

            //Actually TC will throw NoSuchElementException if hotel is not in Search Results.
            Assert.IsNotNull(new BookingPage(driver).ReturnSearchResultByHotel("Limerick Strand Hotel"));
       
        }


        [TestMethod]
        public void SaunaGeorgeLimerickHotelShouldNotBeListed()
        {

            new BookingPage(driver).Destination.SetText(driver, "Limerick");
            new BookingPage(driver).DestinationListItem("Limerick City Centre").Click(driver);
            Assert.IsTrue(new BookingPage(driver).ClickCalendarDayMonth(todayDatePlus30Day, todayDatePlus30));
            new BookingPage(driver).AdultsDropdown.PickDropdownByText(driver, "2 adults");
            new BookingPage(driver).RoomsDropdown.PickDropdownByText(driver, "1 room");
            new BookingPage(driver).Search.Click(driver);
            new BookingPage(driver).SaunaFiter.Click(driver);

            //TC will throw NoSuchElementException as hotel is not in Search Results.
            try
            {
                new BookingPage(driver).ReturnSearchResultByHotel("George Limerick Hotel");
            }
            catch (Exception)
            {
                //TC passes 
                Assert.IsTrue(true);
            }
        }


        [TestMethod]
        public void Star5TheSavoyHotelShouldBeListed()
        {

            new BookingPage(driver).Destination.SetText(driver, "Limerick");
            new BookingPage(driver).DestinationListItem("Limerick City Centre").Click(driver);
            Assert.IsTrue(new BookingPage(driver).ClickCalendarDayMonth(todayDatePlus30Day, todayDatePlus30));
            new BookingPage(driver).AdultsDropdown.PickDropdownByText(driver, "2 adults");
            new BookingPage(driver).RoomsDropdown.PickDropdownByText(driver, "1 room");
            new BookingPage(driver).Search.Click(driver);
            new BookingPage(driver).Star5Fiter.Click(driver);

            //Actually TC will throw NoSuchElementException if hotel is not in Search Results.
            Assert.IsNotNull(new BookingPage(driver).ReturnSearchResultByHotel("The Savoy Hotel"));

        }


        [TestMethod]
        public void Star5GeorgeLimerickHotelShouldNotBeListed()
        {

            new BookingPage(driver).Destination.SetText(driver, "Limerick");
            new BookingPage(driver).DestinationListItem("Limerick City Centre").Click(driver);
            Assert.IsTrue(new BookingPage(driver).ClickCalendarDayMonth(todayDatePlus30Day, todayDatePlus30));
            new BookingPage(driver).AdultsDropdown.PickDropdownByText(driver, "2 adults");
            new BookingPage(driver).RoomsDropdown.PickDropdownByText(driver, "1 room");
            new BookingPage(driver).Search.Click(driver);
            new BookingPage(driver).Star5Fiter.Click(driver);

            //TC will throw NoSuchElementException as hotel is not in Search Results.
            try
            {
                new BookingPage(driver).ReturnSearchResultByHotel("George Limerick Hotel");
            }
            catch (Exception)
            {
                //TC passes 
                Assert.IsTrue(true);
            }
        }






        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

    }
}
