Feature: ActivityLog

Background: Login
	Given the user login with following data
		| UserName | Password |
		| admin    | admin    |

Scenario: Remove events from Activity Log
	Given the user is on the 'Activity Log' page
	When the user deletes first '3' items in the table
	Then items should be deleted
