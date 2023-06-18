Feature: Website

@Automated
Scenario: LoginUser
	Given I navigate to the website 'https://www.reddit.com'
	When I signup into the website with the following email: 'email@mail.com'