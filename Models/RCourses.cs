using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCU_Test
{
    public class RCourses
    {
        public int totalItems { get; set; }
        public List<Item> items { get; set; }

    }

    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

    }
}
