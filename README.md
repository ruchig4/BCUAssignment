# BCUAssignment

# BCU_test
A .NET solution that utilizes RestSharp to interact with RESTful APIs. This project is intended for testing and demonstrating API integrations.

# 📚 Features
Full REST API testing coverage (GET, PUT)
BDD-style SpecFlow scenarios
Concurrent request validation
Response time and data sorting checks
JSON deserialization and validation

## 🚀 Getting Started

### 🔧 Prerequisites

- run README.md of BCU.Contoso.Timetable solution and get the local base URL from swagger
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)
- [SpecFlow](https://specflow.org/)
- [RestSharp](https://restsharp.dev/)
- [NUnit](https://nunit.org/) or compatible testing framework
- Visual Studio 2022+ or Rider

## 🛠 Installation

Clone the repository and modified the local base URL(got after running full solution) in background section of all below mentioned feature files:
- Courses
- CoursesUpdate
- Events
- EventsUpdate
- Students
- StudentsUpdate

#🧪 Running Tests
- Run tests via the Test Explorer in Visual Studio.

 Sample Usage
✅ GET Request Scenario
_client = new RestClient("https://api.example.com");
_request = new RestRequest("courses", Method.Get);
_response = _client.Execute(_request);

// Validate response
var courses = JsonConvert.DeserializeObject<RCourses>(_response.Content);
Assert.IsTrue(courses.items.Count > 0);

🔁 PUT Request Scenario
_request = new RestRequest("courses/123", Method.Put);
_request.AddQueryParameter("newName", "Updated Course Name");

_response = _client.Execute(_request);

var data = JsonConvert.DeserializeObject<CourseResponse>(_response.Content);
Assert.AreEqual("Updated Course Name", data.name);


