using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpProject.Utilities;

public class Driver
{
    private static IWebDriver driver;
    public static IWebDriver getWebDriver()
    {
        string homeDirector = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        driver = new ChromeDriver(homeDirector+"/RiderProjects/SeleniumCSharpProject");
        return driver;
    }
}