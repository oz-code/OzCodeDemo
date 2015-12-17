using System.Threading;

namespace OzCodeDemo.DemoClasses.Events
{
    class LogBook
    {
        private readonly object _dbSync = new object();

        public bool Write(LoggingEvent current)
        {
            if (Monitor.TryEnter(_dbSync))
            {
                try
                {
                    Thread.Sleep(150);
                }
                finally
                {
                    Monitor.Exit(_dbSync);
                }

                return true;
            }

            return false;
        }
    }
}