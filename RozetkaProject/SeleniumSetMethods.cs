using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace RozetkaProject
{
    class SeleniumSetMethods
    {
        public static void EnterText(string element, string value, string elementType)
        {
            if (elementType == "ClassName")
                PropertiesCollection.driver.FindElement(By.ClassName(element)).SendKeys(value);

            if (elementType == "CssSelector")
                PropertiesCollection.driver.FindElement(By.CssSelector(element)).SendKeys(value);

            if (elementType == "XPath")
                PropertiesCollection.driver.FindElement(By.XPath(element)).SendKeys(value);
        }
        public static void Click(string element, string elementType)
        {
            if (elementType == "ClassName")
                PropertiesCollection.driver.FindElement(By.ClassName(element)).Click();

            if (elementType == "CssSelector")
                PropertiesCollection.driver.FindElement(By.CssSelector(element)).Click();

            if (elementType == "XPath")
                PropertiesCollection.driver.FindElement(By.XPath(element)).Click();
        }

        public static void ClickList(string element, int number, string elementType)
        {
            if (elementType == "ClassName")
                PropertiesCollection.driver.FindElements(By.ClassName(element))[number].Click();

            if (elementType == "CssSelector")
            {
                IList<IWebElement> listProduct = PropertiesCollection.driver.FindElements(By.CssSelector(element));
                foreach (var item in listProduct)
                {
                    Console.WriteLine(item.Text);
                }
                listProduct[number].Click();
            }

            if (elementType == "XPath")
                PropertiesCollection.driver.FindElements(By.XPath(element))[number].Click();
        }

        public static void SelectDropDown(string element, int value, string elementType)
        {
            if (elementType == "ClassName")
                new SelectElement (PropertiesCollection.driver.FindElement(By.ClassName(element))).SelectByIndex(value);

            if (elementType == "CssSelector")
                new SelectElement(PropertiesCollection.driver.FindElement(By.CssSelector(element))).SelectByIndex(value);

            if (elementType == "XPath")
                new SelectElement(PropertiesCollection.driver.FindElement(By.XPath(element))).SelectByIndex(value);
        }

    }
}
