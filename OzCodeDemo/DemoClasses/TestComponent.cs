using System.ComponentModel.Composition;

namespace OzCodeDemo.DemoClasses
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