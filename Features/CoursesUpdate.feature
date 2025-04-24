Feature: Test Case for Update Operation for Courses API

A short summary of the feature
Background: We are hitting API
	Given  Bavigate to API Server 'https://localhost:50748/'

Scenario: Verify Course Name is updated sucessfully
	When Set Endpoint to the API 'course/<CourseID>/name'
	Then Pass JSON value to API Request '<CourseName>'
	Then the response status code for Post and Put method should be <StatusCode>
	Then validate the response should contain the updated Details '<CourseName>'
Examples:
	| CourseID | StatusCode | CourseName |
	| 10        | 200        | AI Test    |
	
