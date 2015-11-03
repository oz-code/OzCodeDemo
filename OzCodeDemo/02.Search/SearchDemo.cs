using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using OzCodeDemo.DemoClasses;

namespace OzCodeDemo._02.Search
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "Search")]
    public class SearchDemo : IOzCodeDemo
    {
        public void Start()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(SearchDemo).Assembly));
            var container = new CompositionContainer(catalog);
            container.ComposeParts();

            try
            {
                var component = container.GetExport<ITestComponent>();
                if (component != null)
                    Console.WriteLine(component.Value.Message);
            }
            catch (Exception exp)
            {
                //Why does our call to 'GetExport' throw an exception?

                //Search for the string "Test" on the container variable
                //You'll find 3 instances in the Catalog.
                //Then search for ITestComponent. 
                //You'll need to click "Search Deeper" to expand the search.

                //Another way to do this is to view "container.Catalog.Parts", right click it,
                //select 'Edit Filter' and enter the following predicate:
                //         [obj].Exports(typoef(ITestComponent)

                MessageBox.Show(exp.Message, "Exception caught!");
            }
        }
    }
}
