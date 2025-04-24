Feature: Working on BCU Automation Assigment for get API for courses

Background:
	Given Set the API Url 'https://localhost:50748/'

Scenario: Verify Get API through page no should return a 200 OK code for Successfull request
	When I send a GET request to the API 'course/page/1'
	Then the response status code should be 200

Scenario: Verify Get API through page no should return a 400 status code for Bad request
	When I send a GET request to the API 'course/page/$%$%'
	Then the response status code should be 400
	#And the response should contain the course details

Scenario: Verify given a page number and sort options the API should return a paginated list of courses
	When I send a GET request to the API 'course/page/0'
	Then the response status code should be 200
	And Verify the data is returned in Sorted manner

Scenario: Response of Get API through page no should include the total number of items and an array of course objects.
	When I send a GET request to the API 'course/page/1'
	Then the response status code should be 200
	Then Validate response should have number of Item and array of Object

# Scenario Outline is used to run the same scenario with different data, But in my opion we should write single scenario for each test case

Scenario Outline: Verify Get API through page no should status code for different query prameters
	When I send a GET request to the API 'course/page/<QueryString>'
	Then the response status code should be <StatusCode>
Examples:
	| QueryString | StatusCode |
	| 1           | 200        |
	| $%$%        | 400        |

  #Scenario to Test 1000 concurrent requests, You can change the number of request parameter to test the performance of the API and cover other test cases like 
  #handle concurrent requests without performance degradation 

Scenario: Verify Get API through page no should be able to handle 1000 concurrent requests without performance degradation.
	When I send a GET request to the API 'course/page/0'
	And I send 100 concurrent requests to the API and wait for all to complete and  the response status code should be 200

# Test Case to test the response time of the API <1
Scenario: Validate The Get API through page no should take less than one second to respond for a page size of 100 items.
	When I send a GET request to the API 'course/page/100'
	Then the response time should be less than 1 second
	

Scenario: Verify Get API through course ID should return a 200 OK code for Sucessfull request
	When I send a GET request to the API 'course/1'
	Then the response status code should be 200

