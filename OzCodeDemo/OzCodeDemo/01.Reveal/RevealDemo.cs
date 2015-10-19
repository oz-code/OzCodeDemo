using System.ComponentModel.Composition;
using System.Diagnostics;

namespace OzCodeDemo._01._Reveal
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "Reveal")]
    public class RevealDemo : IOzCodeDemo
    {
        public void Start()
        {
            Debugger.Break();
        }
    }
}
