Feature: TradeMe

Scenario: Verify the listings for brand under category used cars
	Given I navigate to the TradeMe Website
	Then I verify that I am on the Main Page
	When I press vertical navigation option : "Motors"
	Then I verify that I am on the Motors Page
	When I click the link "Used cars" on the widget navigation option on the Motors Page
	Then I verify that Used Cars table is loaded
	And I verify that the listing for used car brand : "Kia" is 1