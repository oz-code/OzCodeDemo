using System.ComponentModel.Composition;

namespace OzCodeDemo._02.Search
{
    [Export(typeof(ITestComponent))]
    public class TestComponent : ITestComponent
    {
        public string Message
        {
            get
            {
                return "Works!";
            }
        }
    }
}