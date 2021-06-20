@ui
Feature: User Challenge

Background: Create user and start the challenge
	Given I login to to Responsive Fight of Covid19 application

	@UI_FinalScore @Web
Scenario: Final Score of the Challenge
	When the user start the challenge 'Take the bus'
	And the user choose the correct answer
	Then the score '100' is displayed
	When the user check the final score
	Then the final score '5000' is displayed

	@UI_NextChallenge @Web
Scenario: Validate Next Challenge exist
	When the user start the challenge 'Take the bus'
	And the user choose the correct answer
	Then the next challenge is displayed

	@UI_NegativeTest @Web
Scenario:Validate Incorrect answer in challenge
	When the user start the challenge 'Take the bus'
	And the user choose the incorrect answer
	Then the try again option is displayed

	@UI_TimeOut @Web
Scenario: Validate Timeout
	When the user start the challenge 'Go to a public place'
	And the challenge timeout
	Then the covid poster is displayed