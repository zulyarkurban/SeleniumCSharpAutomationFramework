using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpProject.Utilities;
using TechTalk.SpecFlow;

namespace SeleniumCSharpProject.StepDefs;

[Binding]
public class Hooks
{

    [BeforeScenario]
    public void BeforeScenario()
    {
        Console.WriteLine("Hooks Before Scenario....");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine("Hooks After Scenario....");
        Driver.TearDown();
    }
}