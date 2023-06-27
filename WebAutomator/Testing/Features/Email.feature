Feature: Email

As a user I want to create a new account

@Automated
Scenario: Create User
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
		And I wait 2 seconds
		And I send 'testmail31234' to the 'Email' textarea
		And I send 'Password@!!1234' to the 'Password' textarea
		And I send 'Password@!!1234' to the 'RepeatPass' textarea
		And I press the button with name 'Age' with the next settings:
		| Type  | ByLocation |
		| Image | false      |
		And I press the button with name 'Agree' with the next settings:
		| Type  | ByLocation |
		| Image | false      |
		And I press the button with name 'Next' with the next settings:
		| Type  | ByLocation |
		| Image | false      |
		And I wait 2 seconds
		And I press the button with name 'Next' with the next settings:
		| Type  | ByLocation |
		| Image | false      |
		And I wait 5 seconds
	Then URL contains 'https://mail.tutanota.com/'
		And I generate and save the report
		And I close the instance