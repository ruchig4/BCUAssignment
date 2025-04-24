using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCU_Test.StepDefinitions
{
    [Binding]
    public  class UpdateOperationStepDefinitions
    {
        private RestClient _client = null;
        private RestRequest _request = null;
        private RestResponse _response = null;
        private string _baseUrl = string.Empty;

        [Given(@"Bavigate to API Server '([^']*)'")]
        public void GivenBavigateToAPIServer(string url)
        {
            _baseUrl = url;
            _client = new RestClient(_baseUrl);
        }

        [When(@"Set Endpoint to the API '([^']*)'")]
        public void WhenSetEndpointToTheAPI(string courseId)
        {
            _request = new RestRequest(courseId, Method.Put);
        }


        [Then(@"Pass JSON value to API Request '([^']*)'")]
        public void ThenPassJSONValueToAPIRequest(string courseName)
        {
            _request.AddQueryParameter("newName", courseName);
        }
        [Then(@"the response status code for Post and Put method should be (.*)")]
        public void ThenTheResponseStatusCodeForPostAndPutMethodShouldBe(int statusCode)
        {
            _response = _client.Execute(_request);
            var result = (int)_response.StatusCode == statusCode;
            Assert.IsTrue(result, $"Expected status code {statusCode} but got {_response.StatusCode}");
        }


        [Then(@"validate the response should contain the updated Details '([^']*)'")]
        public void ThenValidateTheResponseShouldContainTheUpdatedDetails(string expectedValue)
        {
            var data = JsonConvert.DeserializeObject<CourseResponse>(_response.Content);
            Assert.IsTrue(data.name == expectedValue, $"Expected course name {expectedValue} but got {data.name}");
        }



    }
}
