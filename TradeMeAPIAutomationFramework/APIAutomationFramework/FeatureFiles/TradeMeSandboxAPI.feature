Feature: TradeMeSandboxAPI

Scenario: Verify the count of the brands in Used Cards Category
	Given I run the API to get used car categories
	Then I verify the API to Get Categories of Used Cars ran successfully
	Then I verify the number of brands returned are equal to 76
	And I verify that the returned brand list contains brand : "Kia"
	And I verift that the returned brand list doesn't contain brand : "Hispano Suiza"