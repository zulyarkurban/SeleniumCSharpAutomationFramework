using OpenQA.Selenium;

namespace SeleniumCSharpProject.Pages;

public class GoogleHomePage
{
    public  readonly By SearchInput = By.XPath("//*[@name='q']");
    public readonly By ResultList = By.XPath("(//h3/a)[1]");

}