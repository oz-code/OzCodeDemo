using System.ComponentModel.Composition;
using OzCodeDemo._02.Search;

namespace OzCodeDemo.DemoClasses
{
    [Export(typeof(ITestComponent))]
    public class AnotherTestComponent : ITestComponent
    {
        public string Message
        {
            get
            {
                return "Also Works!";
            }
        }
    }
}