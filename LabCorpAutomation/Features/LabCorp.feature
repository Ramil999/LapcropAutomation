Feature: Job Title Validation

A short summary of the feature


Scenario: Validate QA position in Lapcrop application
	Given I launch the application 
	And I click on Career Link
	When I serach Job for QA Test Automation 
	Then I validate the Job is displayed in Job portal
