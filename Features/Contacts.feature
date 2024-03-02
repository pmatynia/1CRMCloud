Feature: Contacts

Background: Login
	Given the user login with following data
		| UserName | Password |
		| admin    | admin    |

@CreateContact
Scenario: Create a contact
	Given the user is on the 'Create Contact' page
	When the user adds new contact with following data
		| FirstName | LastName | BusinessRole | Category            |
		| Jan       | Kowalski | CEO          | Customers, Partners |
	Then contact is created with all data matching
