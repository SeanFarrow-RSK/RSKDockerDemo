Feature: IdentityServerLogIn

ensure login works as expected.

@RequiresChrome	
Scenario: Login succeeds
	Given I am on the login page
	When I enter a username of alice
	And I enter a password of alice
	And I click the login button
	Then I should be loged in
