Feature: Website

@Automated
Scenario: LoginUser
	Given I navigate to the website 'https://tutanota.com/'
	When I press the button with name 'LOGIN' with the next settings:
		| Type | ByLocation |
		| Text | false      |
		And I change tab to 'Tutanota Login'
		And I press the button with name 'Sign up' with the next settings:
		| Type | ByLocation |
		| Text | false      |
		And I wait 2 seconds
		And I press the button with name 'Select' with the next settings:
		| Type  | ByLocation |
		| Image | false      |
		And I press the button with name 'FreeCheckbox' with the next settings:
		| Type  | ByLocation |
		| Image | false      |
		And I press the button with name 'BusinessCheckbox' with the next settings:
		| Type  | ByLocation |
		| Image | false      |
		And I press the button with name 'Ok' with the next settings:
		| Type  | ByLocation |
		| Image | false      |