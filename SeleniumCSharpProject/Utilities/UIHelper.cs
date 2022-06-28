using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumCSharpProject.Utilities;

public class UIHelper
{
    public static void ClickButton(IWebDriver driver,By buttonElement)
    {
        var button = driver.FindElement(buttonElement);
        button.Click();
    }

    public static string GetTitle(IWebDriver driver)
    {
        return driver.Title;
    }

    public static string GetUrl(IWebDriver driver)
    {
        return driver.Url;
    }

    public static void SwitchToWindow(IWebDriver driver,string tabName)
    {
        var currentTab = driver.CurrentWindowHandle;
        ReadOnlyCollection<string> allTabs = driver.WindowHandles;
        foreach (var tab  in allTabs)
        {
            if (tab.Contains(tabName))
            {
                driver.SwitchTo().Window(tab);
            }
        }
    }

    public static void SelectByText(IWebDriver driver, By element, string dropdownText)
    {
        var dropDownList = driver.FindElement(element);
        var  select = new SelectElement(dropDownList);
        select.SelectByText(dropdownText);
    }

    public static void SelectByIndex(IWebDriver driver, By element, int index)
    {
        var dropDownList = driver.FindElement(element);
        var  select = new SelectElement(dropDownList);
        select.SelectByIndex(index);
    }
    public static void SelectByValue(IWebDriver driver, By element, string value)
    {
        var dropDownList = driver.FindElement(element);
        var  select = new SelectElement(dropDownList);
        select.SelectByValue(value);
    }

    public static IList<IWebElement> GetAllOptions(IWebDriver driver, By element)
    {
        var dropDownList = driver.FindElement(element);
        var  select = new SelectElement(dropDownList);
        return select.Options;
    }
    
    public static void AcceptAlert(IWebDriver driver)
    {
        var alert = driver.SwitchTo().Alert();
        alert.Accept();
    }
    public static void DismissAlert(IWebDriver driver)
    {
        var alert = driver.SwitchTo().Alert();
        alert.Dismiss();
    }
    public static string GetAlertText(IWebDriver driver)
    {
        var alert = driver.SwitchTo().Alert();
        return alert.Text;
    }
    
    public static void SendTextToAlert(IWebDriver driver,string text)
    {
        var alert = driver.SwitchTo().Alert();
         alert.SendKeys(text);
    }

    public static void SwitchToFrame(IWebDriver driver,By frame)
    {
        var targetFrame = driver.FindElement(frame);
        driver.SwitchTo().Frame(targetFrame);
    }
    public void ScrollToElement(IWebDriver driver,By element)
    {
        var targetElement = driver.FindElement(element);
       ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
    public static void VerifyElementDisplayed(IWebDriver driver,By element)
    {
        var targetElement = driver.FindElement(element);
        try {
            Assert.True(targetElement.Displayed, $"Element not visible: {targetElement} ");
        } catch (NoSuchElementException e) {
            Assert.Fail("Element not found: " + targetElement);
        }
    }
    public static void WaitForPageToLoad(IWebDriver driver,int timeOutInSeconds)
    {
   
        
    }
    public static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementExists(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }
    
    public static IWebElement WaitUntilElementVisible(IWebDriver driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
            throw;
        }
    }
    
    public static IWebElement WaitUntilElementClickable(IWebDriver driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }
    public static void ClickAndWaitForPageToLoad(IWebDriver driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            var element = driver.FindElement(elementLocator);
            element.Click();
            wait.Until(ExpectedConditions.StalenessOf(element));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }

    public static List<String> GetTextofElements(IWebDriver driver,By element)
    {
        var list = new List<string>();
        ReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
        foreach (IWebElement eachElement in elements)
        {
            list.Add(eachElement.Text);
            //Console.WriteLine(eachElement.Text);
        }
        return list;
    }
}