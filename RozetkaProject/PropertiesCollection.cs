using OpenQA.Selenium;

namespace RozetkaProject
{
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }

        public void CallSubmitType(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = element.GetAttribute("arguments[0].scrollIntoView(true);");
            js.ExecuteScript(script);
        }
    }

}
