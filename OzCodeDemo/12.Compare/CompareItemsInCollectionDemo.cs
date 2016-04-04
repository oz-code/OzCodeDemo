using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using OzCodeDemo.DemoClasses.IoT;

namespace OzCodeDemo._12.Compare
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "CompareItemsInCollection")]
    class CompareItemsInCollectionDemo : IOzCodeDemo
    {
        public void Start()
        {
            var sensorData = Sensor.ReadData();

            DoSomeImportantCalculations(sensorData);

            Debugger.Break();
        }

        private void DoSomeImportantCalculations(IEnumerable<Data> sensorData)
        {
            // TODO: important calculations
        }
    }
}