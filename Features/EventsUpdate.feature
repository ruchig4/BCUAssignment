Feature: Test Case for Update Operation for Event API

A short summary of the feature
Background: We are hitting API
	Given  Bavigate to API Server 'https://localhost:50748/'

Scenario: Verify Event Name is updated sucessfully
	When Set Endpoint to the API 'event/<EventID>/name'
	Then Pass JSON value to API Request '<EventName>'
	Then the response status code for Post and Put method should be <StatusCode>
	Then validate the response should contain the updated Details '<EventName>'
Examples:
	| EventID | StatusCode | EventName |
	| 10        | 200        | Handmade Plastic Chips    |
	
