Feature: Google Search Functionality Test
  @google
  Scenario: User should be able to search a text on google
    Given Navigate to google
    When Enter the text to searchbar and click enter
    And Click on first result
    Then First result page title should contains "Test Automation"
    
  @Selenium
  Scenario: User should be able to see all submenu list on the page
    Given Navigate to google
    When Enter the text to searchbar and click enter
    And Click on first result
    Then First result page title should contains "Test Automation"
    Then User should be able to see all the sub menu on the page