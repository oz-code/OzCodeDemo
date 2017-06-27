using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using OzCodeDemo.DemoClasses.Customers;
using OzCodeDemo.DemoClasses.University;

namespace OzCodeDemo._13.LINQ
{
	[Export(typeof(IOzCodeDemo))]
	[ExportMetadata("Demo", "QuerySyntaxLinq")]
	public class QuerySyntaxLinqDemo : IOzCodeDemo
	{
	    public void Start()
	    {
	        Debugger.Break();

	        // Get all the students whose grade is above average within their department
	        var aboveAverageStudents =
	            StudentRepository.GetAllDepartments()
	                .Select(department =>
	                    new
	                    {
	                        Department = department,
	                        Average = department.Students.Average(student => student.Grade)
	                    })
	                .SelectMany(arg =>
	                    arg.Department.Students.Where(
	                        student => student.Grade >= arg.Average));


	        var aboveAverageStudents2 =
	            from department in StudentRepository.GetAllDepartments()
	            let departmentAverage = department.Students.Average(student => student.Grade)
	            from student in department.Students
	            where student.Grade >= departmentAverage
	            select student.Name;
	    }
    }
}