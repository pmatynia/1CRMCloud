Feature: Reports

Background: Login
	Given the user login with following data
		| UserName | Password |
		| admin    | admin    |

Scenario: Run Report
	Given the user is on the 'Reports' page
	When the user runs a 'Project Profitability' report
	Then some results are returned
