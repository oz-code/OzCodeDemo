using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Windows;
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

            var analyzer = new QuestionsAnalyzer(featuredQuestions);

            var mostUsedTag = analyzer.GetMostUsedTag();

            MessageBox.Show("The most used tag is: " + mostUsedTag);

            if (analyzer.HasQuestionsWithTag("c#"))
            {
                var questionList = analyzer.FindRelevantQuestionsToAnswer("c#");

                MessageBox.Show("Selected questions: " + string.Join("\n",questionList.ToArray() ));
            }
        }
    }
}