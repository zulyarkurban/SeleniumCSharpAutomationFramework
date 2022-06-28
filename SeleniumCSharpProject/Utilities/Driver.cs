using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace SeleniumCSharpProject.Utilities;

public class Driver
{
    private static IWebDriver driver = null;
    private Driver(){}
    public static IWebDriver GetDriver()
    {
        if (driver == null)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();  
        }
        return driver;
    }

    public static void TearDown()
    {
        driver.Close();
    }
}