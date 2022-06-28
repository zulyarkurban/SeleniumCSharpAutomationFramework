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
    public static void ClickButton(By buttonElement)
    {
        var button = Driver.GetDriver().FindElement(buttonElement);
        button.Click();
    }

    public static string GetTitle()
    {
        return Driver.GetDriver().Title;
    }

    public static string GetUrl()
    {
        return Driver.GetDriver().Url;
    }

    public static void SwitchToWindow(string tabName)
    {
        var currentTab = Driver.GetDriver().CurrentWindowHandle;
        ReadOnlyCollection<string> allTabs = Driver.GetDriver().WindowHandles;
        foreach (var tab  in allTabs)
        {
            if (tab.Contains(tabName))
            {
                Driver.GetDriver().SwitchTo().Window(tab);
            }
        }
    }

    public static void SelectByText(By element, string dropdownText)
    {
        var dropDownList = Driver.GetDriver().FindElement(element);
        var  select = new SelectElement(dropDownList);
        select.SelectByText(dropdownText);
    }

    public static void SelectByIndex( By element, int index)
    {
        var dropDownList = Driver.GetDriver().FindElement(element);
        var  select = new SelectElement(dropDownList);
        select.SelectByIndex(index);
    }
    public static void SelectByValue( By element, string value)
    {
        var dropDownList = Driver.GetDriver().FindElement(element);
        var  select = new SelectElement(dropDownList);
        select.SelectByValue(value);
    }

    public static IList<IWebElement> GetAllOptions(By element)
    {
        var dropDownList = Driver.GetDriver().FindElement(element);
        var  select = new SelectElement(dropDownList);
        return select.Options;
    }
    
    public static void AcceptAlert()
    {
        var alert = Driver.GetDriver().SwitchTo().Alert();
        alert.Accept();
    }
    public static void DismissAlert(IWebDriver driver)
    {
        var alert = driver.SwitchTo().Alert();
        alert.Dismiss();
    }
    public static string GetAlertText()
    {
        var alert = Driver.GetDriver().SwitchTo().Alert();
        return alert.Text;
    }
    
    public static void SendTextToAlert(string text)
    {
        var alert = Driver.GetDriver().SwitchTo().Alert();
         alert.SendKeys(text);
    }

    public static void SwitchToFrame(By frame)
    {
        var targetFrame = Driver.GetDriver().FindElement(frame);
        Driver.GetDriver().SwitchTo().Frame(targetFrame);
    }
    public void ScrollToElement(IWebDriver driver,By element)
    {
        var targetElement = driver.FindElement(element);
       ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
    public static void VerifyElementDisplayed(By element)
    {
        var targetElement = Driver.GetDriver().FindElement(element);
        try {
            Assert.True(targetElement.Displayed, $"Element not visible: {targetElement} ");
        } catch (NoSuchElementException e) {
            Assert.Fail("Element not found: " + targetElement);
        }
    }
    public static void WaitForPageToLoad(IWebDriver driver,int timeOutInSeconds)
    {
   
        
    }
    public static IWebElement WaitUntilElementExists( By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementExists(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }
    
    public static IWebElement WaitUntilElementVisible(By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
            throw;
        }
    }
    
    public static IWebElement WaitUntilElementClickable( By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }
    public static void ClickAndWaitForPageToLoad(By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(timeout));
            var element = Driver.GetDriver().FindElement(elementLocator);
            element.Click();
            wait.Until(ExpectedConditions.StalenessOf(element));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }

    public static List<String> GetTextofElements(By element)
    {
        var list = new List<string>();
        ReadOnlyCollection<IWebElement> elements = Driver.GetDriver().FindElements(element);
        foreach (IWebElement eachElement in elements)
        {
            list.Add(eachElement.Text);
            //Console.WriteLine(eachElement.Text);
        }
        return list;
    }
}