using System.Collections.Generic;

namespace OzCodeDemo.ClassManagment
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Student> Students{get; set; } 
    }
}