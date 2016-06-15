using System.Collections.Generic;
using System.Linq;

namespace OzCodeDemo.DemoClasses.StackOverflow
{
    public class QuestionsAnalyzer
    {
        private readonly Rootobject _questions;

        public QuestionsAnalyzer(Rootobject questions)
        {
            _questions = questions;
        }

        public string GetMostUsedTag()
        {
            return _questions.items
                .SelectMany(item => item.tags)
                .GroupBy(s => s)
                .OrderBy(s => s.Count())
                .Select(grouping => grouping.Key)
                .First();
        }

        public bool HasQuestionsWithTag(string tagName)
        {
            return _questions.items
                .SelectMany(item => item.tags)
                .Distinct()
                .OrderBy(tag => tag)
                .Any(tag => tag == tagName);
        }

        public IEnumerable<string> FindQuestionsByTag(string tagName)
        {
            return _questions.items
                .Where(item => item.tags.Contains(tagName))
                .Select(item => item.title);
        }
    }
}