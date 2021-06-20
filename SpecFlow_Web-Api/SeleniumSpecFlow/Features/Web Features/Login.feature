@ui
Feature: User Login

@UI_Login @Web
Scenario: Login to ResponsiveFight Covid19 Application
	Given I enter to Responsive Fight of Covid19 application
	When I create a warrior name with random name
	Then I should see the new user has been created
	And I should see the dashboard of Responsive Fight of Covid19