Feature: Google Search
  
  Scenario: Search for a term in Google
    Given I am on the google search page
    When I enter "Java"
    And I click the search button
    Then The search results should contain the term "Java"