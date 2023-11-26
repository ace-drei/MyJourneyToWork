Feature: Calculator Sustainability Weighting Calculation

 Scenario: Calculate Sustainability Weighting for a different transport mode
    Given I have a distance of 20 miles
    And I travel to work for 5 days
    When I select the transport mode as Electric
    Then the Sustainability Weighting should be calculated as 800.0

  Scenario: Calculate Sustainability Weighting for a given transport mode
    Given I have a distance of 10 miles
    And I travel to work for 3 days
    When I select the transport mode as Petrol
    Then the Sustainability Weighting should be calculated as 480.0

  Scenario: Calculate Sustainability Weighting for another transport mode
    Given I have a distance of 15 miles
    And I travel to work for 3 days
    When I select the transport mode as Cycling
    Then the Sustainability Weighting should be calculated as 0.44999999999999996