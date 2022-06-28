using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharpProject.Pages;
using SeleniumCSharpProject.Utilities;
using TechTalk.SpecFlow;

namespace SeleniumCSharpProject.StepDefs;

[Binding]
public  class GoogleSearchStepDefs
{
    private readonly  GoogleHomePage  _homePage=new GoogleHomePage();
    private readonly SeleniumHomePage _seleniumHomePage = new SeleniumHomePage();
    private readonly IWebDriver _driver = Driver.GetDriver();
    private  WebDriverWait _wait;
    [Given(@"Navigate to google")]
    public void GivenNavigateToGoogle()
    {
        Console.WriteLine("Navigate to Google...");
        _driver.Url = "https://www.google.com";
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [When(@"Enter the text to searchbar and click enter")]
    public void WhenEnterTheTextToSearchbarAndClickEnter()
    {
        string searchText = "Selenium Test Automation";
        IWebElement searchInput  = _driver.FindElement(_homePage.SearchInput);
        searchInput.SendKeys(searchText+Keys.Enter);
        Console.WriteLine($"user entered {searchText}");
    }

    [When(@"Click on first result")]
    public void WhenClickOnFirstResult()
    {
        UIHelper.ClickButton(_homePage.ResultList);
    }

    [Then(@"First result page title should contains ""(.*)""")]
    public void ThenFirstResultPageTitleShouldContains(string title)
    {
        string pageTitle = _driver.Title;
        Console.WriteLine($"Page title is {pageTitle}");
        Assert.IsTrue(pageTitle.Contains(title));
        Console.WriteLine("Done....");
    }

    [Then(@"User should be able to see all the sub menu on the page")]
    public void ThenUserShouldBeAbleToSeeAllTheSubMenuOnThePage()
    {
        List<string> list = UIHelper.GetTextofElements(_seleniumHomePage.SeleniumSubMenuLeftBar);
        Console.WriteLine("Count of menu : "+list.Count);
        Assert.True(list.Count>0);
    }
}