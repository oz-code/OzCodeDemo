using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;

namespace OzCodeDemo._13.LINQ
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "Linq")]
    public class LinqDemo : IOzCodeDemo
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
