using System.Collections.Generic;

namespace OzCodeDemo.DemoClasses.University
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}