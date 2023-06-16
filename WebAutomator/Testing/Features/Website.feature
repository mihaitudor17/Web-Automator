Feature: Website

@Automated
Scenario: LoginUser
	Given I navigate to the website 'https://www.reddit.com'
	When I log into the website with user 'user' and password 'password'