using OzCodeDemo.ClassManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace OzCodeDemo._11.Linq
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "LINQ2")]
    public class LINQDemo2 : IOzCodeDemo
    {
        public void Start()
        {
            var allStudents = StudentRepository.GetAllStudents()
                                                .SelectMany(d => d.Students);

            var averageGrade = allStudents.Average(s => s.Grade);

            Debugger.Break();

            var aboveAverageStudents =
                allStudents
                    .Where(args => args.Grade >= averageGrade)
                    .Select(args => args.Name)
                    .Count();


            Debug.Assert(aboveAverageStudents < allStudents.Count());
        }
    }
}
