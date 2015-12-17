using System;

namespace OzCodeDemo.DemoClasses.Events
{
    internal class EventLoggedEventArgs : EventArgs
    {
        public bool Success { get; private set; }

        public EventLoggedEventArgs(bool success)
        {
            Success = success;
        }
    }
}