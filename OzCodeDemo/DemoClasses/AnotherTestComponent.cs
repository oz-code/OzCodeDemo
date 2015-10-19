using System.ComponentModel.Composition;

namespace OzCodeDemo._02.Search
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