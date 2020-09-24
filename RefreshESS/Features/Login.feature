Feature: Login
	I want to ensure Login functionality is working end to end

@login
Scenario Outline: I should able to successfully Login to ABIMM 
	Given I have launched the browser to enter ABIMM <Site> 
	And I have given the <Venue>
	And I entered <LoginID> and <PIN>
	Then I should be should be in ABIMM Main Page 
	
    Examples: 
		| Site                 | Venue | LoginID       | PIN | 
		| http://localhost/     | QA      | BOWLSBY3562  | 1234     | 
		| https://ess.abimm.com/ | ABICO   | NAGRECHA6308 | ADITI   | 