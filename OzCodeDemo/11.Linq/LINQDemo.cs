using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzCodeDemo._11.Linq
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "LINQ")]

    class LINQDemo : IOzCodeDemo
    {
        public void Start()
        {
            Debugger.Break();

            var text = @"99 little bugs in the code, 99 bugs in the code.
                         Take one down, patch it around, 127 bugs in the code.
                        (Repeat until NO MORE BUGS)";

            var mostFrequentWord = text
                .Split(' ', '.', ',')
                .Where(i => i != "")
                .GroupBy(i => i)
                .OrderBy(i => i.Count())
                .Last();

            Debug.Assert(mostFrequentWord.Key == "bugs");
        }
    }
}
