Feature: UnitBv

As a user I want to use the search function

@Automated
Scenario: Search Tabere
Given I navigate to the website 'https://www.unitbv.ro/'
	When I press the button with name 'Acceptare toate' with the next settings:
		| Type | ByLocation |
		| Text | false      |
		And I press the button with name 'Search' with the next settings:
		| Type  | ByLocation |
		| Image | true       |
		And I send 'tabere' to the 'SearchBox' textarea and confirm
		And I press the button with name 'Acceptare toate' with the next settings:
		| Type | ByLocation |
		| Text | false      |
		And I press the button with name 'Tabere 2023' with the next settings:
		| Type | ByLocation |
		| Text | false      |
		And I change tab to 'Facultatea de Litere'
		And I press the button with name 'Acceptare toate' with the next settings:
		| Type | ByLocation |
		| Text | false      |
		And I press the button with name 'Calendar tabere' with the next settings:
		| Type | ByLocation |
		| Text | false      |
		And I change tab to 'Nota_calendar'
	Then URL contains 'https://litere.unitbv.ro/images/Tabere_2023'
		And I generate and save the report
		And I close the instance
