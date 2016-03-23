using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzCodeDemo.ClassManagment
{
    static class StudentRepository
    {
        public static IEnumerable<Department> GetAllStudents()
        {
            return new[]
            {
                new Department {Id=1, Name="Math", Students = new [] {
                new Student{Id = 1,Name = "Barbara Montgomery",Email=  "in.faucibus.orci@sitametultricies.ca",Grade = 38},
                new Student{Id = 2, Name = "Ivory Benjamin", Email=  "non.dui.nec@ultricesmaurisipsum.co.uk", Grade = 81},
                new Student{Id= 3, Name= "Chancellor Levine", Email= "ut@loremtristique.ca", Grade= 14},
                new Student{Id= 4, Name= "Nicholas Barry", Email= "Vestibulum.accumsan.neque@egestasFuscealiquet.com", Grade= 21},
                new Student{Id= 5, Name= "Carissa Ball", Email= "rutrum@necquamCurabitur.co.uk", Grade= 70}
            }},

            new Department {Id=2, Name="Physics", Students = new [] {
                new Student{Id= 6, Name= "Rama Carney", Email= "Curabitur@nisl.ca", Grade= 46},
                new Student{Id= 7, Name= "Nadine Rollins", Email= "nisi.Aenean@vitaediam.edu", Grade = 71},
                new Student{Id= 8, Name= "Cameron Pollard", Email= "risus@adipiscingfringillaporttitor.org", Grade= 7},
                new Student{Id= 9, Name= "Juliet Hopkins", Email= "viverra@Pellentesque.ca", Grade= 76},
                new Student{Id= 10,Name= "Charissa Levine", Email= "ultricies.adipiscing@sempercursus.org", Grade= 27},
                new Student{Id = 11, Name = "Brett Bryan", Email = "Quisque.varius.Nam@vulputateposuerevulputate.com", Grade =  59},
                new Student{Id = 12, Name = "Zahir Short", Email = "ac.nulla@lectusjusto.ca", Grade = Double.NegativeInfinity},
                new Student{Id = 13, Name = "Kermit Rasmussen", Email = "pede.blandit@tellus.ca", Grade =  52},
                new Student{Id = 14, Name = "Damon Lancaster", Email = "mauris.blandit.mattis@tempor.org", Grade =  16}}},

           new Department {Id=3, Name="Biology", Students = new [] {
                new Student{Id = 15, Name = "Channing Leblanc", Email = "blandit.viverra.Donec@adipiscingenim.edu", Grade =  92},
                new Student{Id = 16, Name = "Kane Conway", Email = "amet.ultricies@erateget.com", Grade =  Double.NegativeInfinity},
                new Student{Id = 17, Name = "Vernon Whitaker", Email = "purus@enimsitamet.ca", Grade =  85},
                new Student{Id = 18, Name = "Cheryl Shaw", Email = "magna.a@Nunccommodoauctor.edu", Grade =  21},
                new Student{Id = 19, Name = "Christen Pennington", Email = "quis.pede.Praesent@turpisvitaepurus.edu", Grade =  69},
                new Student{Id = 20, Name = "Emily Hudson", Email = "Donec@conubia.ca", Grade =  99},
            }}};
        }
    }
}
