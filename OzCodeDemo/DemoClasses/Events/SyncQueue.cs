using System.Collections.Generic;

namespace OzCodeDemo.DemoClasses.Events
{
    class SyncQueue<T>
    {
        private readonly Queue<T> _queue;
        private readonly object _sync = new object();

        public SyncQueue()
        {
            _queue = new Queue<T>();
        }

        public void Enqueue(T item)
        {
            lock (_sync)
            {
                _queue.Enqueue(item);
            }
        }

        public T Dequeue()
        {
            lock (_sync)
            {
                if (_queue.Count == 0)
                {
                    return default(T);
                }
                return _queue.Dequeue();
            }
        }
    }
}