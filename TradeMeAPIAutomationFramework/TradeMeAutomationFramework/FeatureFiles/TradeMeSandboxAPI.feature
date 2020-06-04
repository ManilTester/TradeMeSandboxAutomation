Feature: TradeMeSandboxAPI

Background:
	Given I run the API to get used car categories
	Then I verify the API to Get Categories of Used Cars ran successfully

Scenario: Verify the count of the brands in Used Cards Category
	Then I verify the number of brands returned are equal to 76

Scenario: Verify the brand existing in Used Cars Category
	Then I verify that the returned brand list contains brand : "Kia"
	And I verift that the returned brand list doesn't contain brand : "Hispano Suiza"