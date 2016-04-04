using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace OzCodeDemo.DemoClasses.StackOverflow
{
    public class Client
    {
        public static Rootobject GetFeaturedQuestions()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("OzCodeDemo.json.SO_Featured.json"))
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Rootobject>(json);
            }
        }
    }
}