using System;
using System.Timers;
using Timer = System.Timers.Timer;

namespace OzCodeDemo.DemoClasses.Events
{
    class EventProcessor : IDisposable
    {
        private readonly SyncQueue<LoggingEvent> _messageQueue;
        private readonly Timer _timer;
        public event EventHandler<EventLoggedEventArgs> OnEventLogged;

        private readonly LogBook _logBook;

        public EventProcessor()
        {
            _logBook = new LogBook();
            _messageQueue = new SyncQueue<LoggingEvent>();

            _timer = new Timer(10);
            _timer.Elapsed += HandleNextEvent;
            _timer.Start();
            
        }

        public void LogEvent(LoggingEvent loggingEvent)
        {
            _messageQueue.Enqueue(loggingEvent);
        }

        private void HandleNextEvent(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var loggingEvent = _messageQueue.Dequeue();
            if (loggingEvent == null)
            {
                return;
            }

            var result = _logBook.Write(loggingEvent);

            if (OnEventLogged != null)
                OnEventLogged(this, new EventLoggedEventArgs(result));
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}