using System.Collections.Generic;

namespace OzCodeDemo.DemoClasses.IoT
{
    public class Sensor
    {
        public static IEnumerable<Data> ReadData()
        {
            return new[]
            {
                new Data {Humidity = 20.3, Temperature = 15.5, Pressure = 10},
                new Data {Humidity = 20.5, Temperature = 15.5, Pressure = 10},
                new Data {Humidity = 20.7, Temperature = 15.5, Pressure = 11},
                new Data {Humidity = 20.3, Temperature = 15.7, Pressure = 11},
                new Data {Humidity = 70.0, Temperature = 42.0, Pressure = 5}
            };
        }
    }
}