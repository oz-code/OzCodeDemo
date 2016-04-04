using System.ComponentModel.Composition;
using System.Diagnostics;
using OzCodeDemo.DemoClasses.StackOverflow;

namespace OzCodeDemo._13.Export
{
    [Export(typeof (IOzCodeDemo))]
    [ExportMetadata("Demo", "Export")]
    public class ExportDemo : IOzCodeDemo
    {
        public void Start()
        {
            var featuredQuestions = Client.GetFeaturedQuestions();

            Debugger.Break();

            FindRelevantQuestionsAndAnswer(featuredQuestions);
        }

        private void FindRelevantQuestionsAndAnswer(Rootobject featuredQuestions)
        {

        }
    }

}