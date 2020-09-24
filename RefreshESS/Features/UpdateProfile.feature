Feature: UpdateProfile
	I want to ensure Update Profile functionality is working end to end

@UpdateProfile
Scenario Outline: Login to ABIMM and update the profile
	Given I have lanuched <ABIMM> and entered <VenueID> with valid <UserID> and <Password>
		And I navigate to ABIMM Main Page 
	When I click Update Profile Link
		And I edit the profile with <Hat> and <Shoe> size
		And I save changes		
	Then I validate the changes are saved for <Hat> and <Shoe>

	
			
    Examples: 
		| ABIMM                 | VenueID | UserID       | Password | Hat | Shoe |
		| http://localhost/     | QA      | GEROW1234  | 1234     | 10  | 11   |
		| http://localhost/  | QA	   | GRANGER2963 | 1234    | 20  | 21   |