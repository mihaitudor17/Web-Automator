Feature: YouTube

As a user I want to play a video

@Automated
Scenario: Video play
	Given I navigate to the website 'https://www.youtube.com/'
	When I send 'universitatea transilvania' to the 'VideoSearch' textarea and confirm
		And I press the button with name 'CONEXIUNI' with the next settings:
		| Type | ByLocation |
		| Text | false      |
	Then URL contains 'https://www.youtube.com/watch?v=w05armhvJZ4'
		And I generate and save the report
		And I close the instance
