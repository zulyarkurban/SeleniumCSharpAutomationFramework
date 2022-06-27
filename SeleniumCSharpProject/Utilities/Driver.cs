using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace SeleniumCSharpProject.Utilities;

public class Driver
{
    private static IWebDriver driver;

    public static IWebDriver GetWebDriver()
    {
        //string homeDirector = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        //driver = new ChromeDriver(homeDirector+"/RiderProjects/SeleniumCSharpProject");
        new DriverManager().SetUpDriver(new ChromeConfig());
        var driver = new ChromeDriver();
        return driver;
    }
    
    
}