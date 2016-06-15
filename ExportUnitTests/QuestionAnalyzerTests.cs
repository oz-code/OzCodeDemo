using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OzCodeDemo.DemoClasses.StackOverflow;

namespace ExportUnitTests
{
    [TestClass]
    public class QuestionAnalyzerTests
    {
        [TestMethod]
        public void GetMostUsedTag_passFeaturedQuestions_returnMostUsedTag()
        {
            var data = LoadDataFromCode();

            var analyzer = new QuestionsAnalyzer(data);

            var result = analyzer.GetMostUsedTag();

            Assert.AreEqual("swift", result);
        }

        [TestMethod]
        [DeploymentItem("questions.json")]
        public void FindQuestionsByTag_allTagsQuestionsReturned()
        {
            var jsonString = File.ReadAllText("questions.json");
            var data = JsonConvert.DeserializeObject<Rootobject>(jsonString);

            var analyzer = new QuestionsAnalyzer(data);

            var result = analyzer.FindQuestionsByTag("c#");

            Assert.AreEqual("Why are COM event handlers always null?", result.Single());
        }

        private Rootobject LoadDataFromCode()
        {
            return new Rootobject();
        }
    }
}
