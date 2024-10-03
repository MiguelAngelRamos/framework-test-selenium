Feature: Google Search
  
  Scenario: Search for a term in Google
    Given I am on the google search page
    When I enter "Selenium WebDriver"
    And I click the search button
    Then I should see search results