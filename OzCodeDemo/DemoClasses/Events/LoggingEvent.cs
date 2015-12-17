using System;

namespace OzCodeDemo.DemoClasses.Events
{
    public class LoggingEvent
    {
        public LoggingEvent()
        {
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; }
        public EventType EventType { get; set; }
    }
}