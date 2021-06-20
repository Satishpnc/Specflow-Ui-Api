@api
Feature: Supervillain Herokuapp Api Tests

		@Api_GetUsers
Scenario: Get list of users and validate the schema
	Given I want to validate the users endpoint
	When I requested "GET" operation and fetch the response 
	Then I should see the 200 status code
	And I should validate the users response

	@Api_NewUser
Scenario: Create a new user
	Given I want to validate the creation of new user's endpoint
	When I requested "POST" operation to create new user to fetch the response 
	Then I should see the 201 status code
	And I see the response of new user being created successfully
	
	@Api_UpdateUser
Scenario: Update a user
	Given I want to validate the creation of new user's endpoint
	When I requested "PUT" operation to amend the score for the user "Test" and fetch the response
	Then I should see the 201 status code
	And I see the response of the user score has been updated successfully