using OpenQA.Selenium;
using System;

namespace RozetkaProject
{
    class SeleniumGetMethods
    {
        public static string GetText(string element, string elementType)
        {
            if (elementType == "ClassName")
                return PropertiesCollection.driver.FindElement(By.ClassName(element)).Text;

            if (elementType == "CssSelector")
                return PropertiesCollection.driver.FindElement(By.CssSelector(element)).Text;

            if (elementType == "XPath")
                return PropertiesCollection.driver.FindElement(By.XPath(element)).Text;

            else return String.Empty;
        }
    }
}
