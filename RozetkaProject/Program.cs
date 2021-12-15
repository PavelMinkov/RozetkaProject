using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace RozetkaProject
{
    //[TestFixture]
    class Program
    {

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("https://rozetka.com.ua/ua/");
            PropertiesCollection.driver.Manage().Window.Maximize();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait =  TimeSpan.FromSeconds(90);
        }

        [Test]
        public void ExecuteTest()
        {
            Actions actionProvider = new Actions(PropertiesCollection.driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)PropertiesCollection.driver;

            //PRODUCT_1
            //listMenu
            SeleniumSetMethods.ClickList("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]", 0, "XPath");
            //listTitleMenu
            SeleniumSetMethods.ClickList("tile-cats", 0, "ClassName");
            //elementBrandHP
            SeleniumSetMethods.Click("//input[@id='HP']/parent::*", "XPath");
            //elementModel
            SeleniumSetMethods.Click("//input[@id='Pavilion']/parent::*", "XPath");
            //elementSort
            SeleniumSetMethods.SelectDropDown("select[class*='select']", 2, "CssSelector");
            //listProducts
            PropertiesCollection.driver.Navigate().Refresh();
            SeleniumSetMethods.ClickList("span.goods-tile__title", 0, "CssSelector");
            //elementButtonBuy
            actionProvider.MoveToElement(PropertiesCollection.driver.FindElement(By.CssSelector("p[class*='product-prices']"))).Build().Perform();
            SeleniumSetMethods.Click("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]", "XPath");
            //elementCartClose
            SeleniumSetMethods.Click("div.modal__header button[class*='close']", "CssSelector");
            //elementLogo
            SeleniumSetMethods.Click("a.header__logo", "CssSelector");

            //PRODUCT_2
            //listMenu
            SeleniumSetMethods.ClickList("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]", 1, "XPath");
            //listTitleMenu
            SeleniumSetMethods.ClickList("tile-cats", 0, "ClassName");
            //elementBrandSamsung
            SeleniumSetMethods.Click("//input[@id='Samsung']/parent::*", "XPath");
            //elementModel
            SeleniumSetMethods.Click("//input[@id='Galaxy M']/parent::*", "XPath");
            //elementSort
            SeleniumSetMethods.SelectDropDown("select[class*='select']", 2 , "CssSelector");
            //listProducts
            PropertiesCollection.driver.Navigate().Refresh();
            SeleniumSetMethods.ClickList("span.goods-tile__title", 3, "CssSelector");
            //elementButtonBuy
            //js.ExecuteScript("window.scrollBy(0,500)");
            //actionProvider.MoveToElement(PropertiesCollection.driver.FindElement(By.CssSelector("p[class*='product-prices']"))).Build().Perform();
            SeleniumSetMethods.Click("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]", "XPath");
            //elementCartClose
            SeleniumSetMethods.Click("div.modal__header button[class*='close']", "CssSelector");
            //elementLogo
            SeleniumSetMethods.Click("a.header__logo", "CssSelector");

            //PRODUCT_3
            //listMenu
            SeleniumSetMethods.ClickList("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]", 1, "XPath");
            //listTitleMenu
            SeleniumSetMethods.ClickList("tile-cats", 0, "ClassName");
            //elementBrandSamsung
            SeleniumSetMethods.Click("//input[@id='Samsung']/parent::*", "XPath");
            //elementModel
            SeleniumSetMethods.Click("//input[@id='Galaxy S']/parent::*", "XPath");
            //elementSort
            SeleniumSetMethods.SelectDropDown("select[class*='select']", 2 , "CssSelector");
            //listProducts
            PropertiesCollection.driver.Navigate().Refresh();
            SeleniumSetMethods.ClickList("span.goods-tile__title", 3, "CssSelector");
            //elementButtonBuy
            //js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
            //actionProvider.MoveToElement(PropertiesCollection.driver.FindElement(By.CssSelector("p[class*='product-prices']"))).Build().Perform();
            SeleniumSetMethods.Click("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]", "XPath");
            //elementCartClose
            SeleniumSetMethods.Click("div.modal__header button[class*='close']", "CssSelector");
            //elementLogo
            SeleniumSetMethods.Click("a.header__logo", "CssSelector");

            //check quantity
            String quantity = PropertiesCollection.driver.FindElement(By.XPath("//span[contains(@class,'counter')]")).Text;
            Console.WriteLine(quantity);
            Assert.IsTrue(quantity.Contains("3"));

            //check summ products
            SeleniumSetMethods.Click("//li[contains(@class,'cart')]", "XPath");
            int summ = int.Parse(PropertiesCollection.driver.FindElement(By.XPath("//div[@class='cart-receipt__sum-price']/span[1]")).Text);
            Console.WriteLine(summ);
            Assert.That(summ, Is.LessThan(100000));

            //make screenshot
            try
            {
                Screenshot ss = ((ITakesScreenshot)PropertiesCollection.driver).GetScreenshot();
                ss.SaveAsFile(@"C:\Паша\EPAM\LAB\HomeWork\RozetkaProject\SeleniumTestingScreenshot.jpg", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
        }


    }
}
