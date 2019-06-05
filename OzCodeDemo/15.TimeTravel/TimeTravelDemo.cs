using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;

namespace OzCodeDemo
{
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "TimeTravel")]
    public class TimeTravelDemo : IOzCodeDemo
    {
        public void Start()
        {
            string text = @"99 little bugs in the code, 99 bugs in the code.
                         Take one down, patch it around, 127 bugs in the code.
                        (Repeat until NO MORE BUGS)";
            AnalyzePoem(text);
        }

        private static string FindMostFrequentWord(Dictionary<string, int> mydict)
        {
            var maxOccurences = 0;

            string mostFre = null;
            foreach (var kvp in mydict)
                if (kvp.Value >= maxOccurences)
                {
                    maxOccurences = kvp.Value;
                    mostFre = kvp.Key;
                }

            return mostFre;
        }

        private static void AnalyzePoem(string text)
        {
            Debugger.Break();
            var dict = new Dictionary<string, int>();
            var words = text.Split(new[] { ' ', '.', ',' }, StringSplitOptions.None);
            foreach (var word in words)
            {
                var currentWord = word;
                if (currentWord != String.Empty)
                {
                    if (dict.ContainsKey(currentWord))
                    {
                        dict[currentWord] = dict[currentWord] + 1;
                    }
                    else
                    {
                        dict[currentWord] = 1;
                    }
                }
            }
            Debug.Assert(FindMostFrequentWord(dict) == "bugs");
        }
    }
}
