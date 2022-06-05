using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumCSharpProject.StepDefs;

[Binding]
public class Hooks
{
    // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
    
    [BeforeScenario]
    public void BeforeScenario()
    {
        Console.WriteLine("Hooks Before Scenario....");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine("Hooks After Scenario....");
    }
}