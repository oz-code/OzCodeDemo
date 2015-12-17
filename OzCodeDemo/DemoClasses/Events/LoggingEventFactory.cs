using System;

namespace OzCodeDemo.DemoClasses.Events
{
    public class LoggingEventFactory
    {
        private static int _uniqueId;
        private static readonly Random Rand = new Random();

        public static LoggingEvent[] GetEvents(int eventsNumber)
        {
            LoggingEvent[] result = new LoggingEvent[eventsNumber];
            for (int i = 0; i < eventsNumber; i++)
            {
                result[i] = CreateEvent();
            }

            return result;
        }

        private static LoggingEvent CreateEvent()
        {
            return new LoggingEvent { Id = _uniqueId++, EventType = (EventType)Rand.Next(0, 3) };
        }
    }
}