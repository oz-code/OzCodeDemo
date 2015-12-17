using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading;
using OzCodeDemo.DemoClasses.Events;

namespace OzCodeDemo._08.Trace
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "EnhancedTrace")]
    public class TraceDemo : IOzCodeDemo
    {

        public void Start()
        {
            using (EventProcessor processor = new EventProcessor())
            {
                var eventsLogged = 0;
                var eventsSaved = 0;

                processor.OnEventLogged += (sender, args) =>
                {
                    Interlocked.Increment(ref eventsLogged);
                    if (args.Success)
                    {
                        Interlocked.Increment(ref eventsSaved);
                    }
                };
                
                var eventsToProcess = LoggingEventFactory.GetEvents(100);

                foreach (var loggingEvent in eventsToProcess)
                {
                    processor.LogEvent(loggingEvent);
                }

                while (eventsLogged < 100)
                {
                }

                Debug.Assert(eventsLogged == eventsSaved);
            }
        }
    }
}
