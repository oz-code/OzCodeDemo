using System.Collections.Generic;

namespace OzCodeDemo.DemoClasses
{
    public class Logger
    {
        private static List<string> _logMessages = new List<string>();

        public static void LogMessage(string message)
        {
            _logMessages.Add(message);
        }

        public static IEnumerable<string> GetAllMessages()
        {
            return _logMessages;
        } 
    }
}