using System.Collections.Generic;

namespace OzCodeDemo
{
    public class DemoName
    {
        public DemoName(IDictionary<string, object> metaData)
        {
            Name = metaData["Demo"].ToString();
        }
        public string Name { get; private set; }
    }
}