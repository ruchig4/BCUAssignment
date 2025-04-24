Feature: Test Case for Update Operation for Student API

A short summary of the feature
Background: We are hitting API
	Given  Bavigate to API Server 'https://localhost:50748/'

Scenario: Verify Student Name is updated sucessfully
	When Set Endpoint to the API 'student/<StudentID>/name'
	Then Pass JSON value to API Request '<StudentName>'
	Then the response status code for Post and Put method should be <StatusCode>
	Then validate the response should contain the updated Details '<StudentName>'
Examples:
	| StudentID | StatusCode | StudentName |
	| 10        | 200        | AI Test    |
	
