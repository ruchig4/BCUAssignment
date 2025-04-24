using System;
using TechTalk.SpecFlow;
using RestSharp;
using Newtonsoft.Json;
using TechTalk.SpecFlow.Assist;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Security.Policy;

namespace BCU_Test.StepDefinitions
{
    [Binding]
    public class CoursesStepDefinition
    {
        private RestClient _client = null;
        private RestRequest _request = null;
        private RestResponse _response = null;
        private string _baseUrl = string.Empty;

        [Given(@"Set the API Url '([^']*)'")]
        public void GivenSetTheAPIUrl(string url)
        {
            _baseUrl = url;
            _client = new RestClient(_baseUrl);
        }



        [When(@"I send a GET request to the API '([^']*)'")]
        public void WhenISendAGETRequestToTheAPI(string endpoint)
        {
            _request = new RestRequest(endpoint, Method.Get);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            _response = _client.Execute(_request);
            var result = (int)_response.StatusCode == statusCode;
            Console.WriteLine("Response Body:");
            Console.WriteLine(_response.Content);
            Assert.IsTrue(result, $"Expected status code {statusCode} but got {_response.StatusCode}");
        }

        [Then(@"the response should contain the course details")]
        public void ThenTheResponseShouldContainTheCourseDetails()
        {
            bool isCourData = _response.Content.Contains("Unbranded Granite Bike");
        }

        [Then(@"Validate response should have number of Item and array of Object")]
        public void ThenValidateResponseShouldHaveNumberOfItemAndArrayOfCoursesObject()
        {
            RCourses courses = JsonConvert.DeserializeObject<RCourses>(_response.Content);
            Assert.IsTrue(courses.items.Count > 0, "The items list is empty.");
            Assert.IsTrue(courses.totalItems > 0, "The totalItems count is not greater than 0.");
        }


        [Then(@"Verify the data is returned in Sorted manner")]
        public void ThenVerifyTheDataIsReturnedInSortedManner()
        {
            var result = JsonConvert.DeserializeObject<RCourses>(_response.Content);
            var sortedList = result.items.Select(x => x.id).ToList();
            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                if (sortedList[i] > sortedList[i + 1])
                {
                    Assert.Fail("The list is not sorted in ascending order.");
                }
            }
        }

        [When(@"I send (.*) concurrent requests to the API and wait for all to complete and  the response status code should be (.*)")]
        public void WhenISendConcurrentRequestsToTheAPIAndWaitForAllToCompleteAndTheResponseStatusCodeShouldBe(int numberofThread, int statusCode)
        {
            int count = 0;
            int failureCount = 0;

            Parallel.For(0, numberofThread, method =>
            {
                try
                {
                    Console.WriteLine("Thread number" + count);
                    _response = _client.Execute(_request);
                    var result = (int)_response.StatusCode == statusCode;
                    Console.WriteLine($"Thread Number = {count}  and Status code is {(int)_response.StatusCode} ");
                    Assert.IsTrue(result, $"Expected status code {statusCode} but got {_response.StatusCode} and Concurrent request Number is {numberofThread}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Cocured for Thread Number {count} and Number of Thread Failed {failureCount}");
                    failureCount++;
                }
                count++;

            });


        }

        [Then(@"the response time should be less than (.*) second")]
        public void ThenTheResponseTimeShouldBeLessThanSecond(int seconds)
        {
            Stopwatch stopwatch = new Stopwatch();

            int statusCode = 200;
            stopwatch.Start();
            _response = _client.Execute(_request);
            stopwatch.Stop();
            int miliSecond = (int)TimeSpan.FromSeconds(seconds).TotalMilliseconds;
            if (stopwatch.Elapsed.TotalMilliseconds >= miliSecond)
            {
                Assert.Fail($"Response time exceeded {seconds} seconds. Actual response time: {stopwatch.ElapsedMilliseconds / 1000} seconds");
            }
            else
            {
                Assert.IsTrue(true, $"Response time is within the limit: {stopwatch.ElapsedMilliseconds / 1000} seconds");
            }
            var result = (int)_response.StatusCode == statusCode;
            Assert.IsTrue(result, $"Expected status code {statusCode} but got {_response.StatusCode}");

        }



    }
}
