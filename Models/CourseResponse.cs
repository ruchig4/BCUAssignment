using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BCU_Test
{
    public class EnrolledStudent
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public DateTime enrollmentDate { get; set; }
    }

    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string location { get; set; }
    }

    public class CourseResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<EnrolledStudent> enrolledStudents { get; set; }
        public List<Event> events { get; set; }
    }


}
