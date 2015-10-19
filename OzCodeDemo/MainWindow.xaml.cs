using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OzCodeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [ImportMany(typeof(IOzCodeDemo))]
        public IEnumerable<Lazy<IOzCodeDemo, DemoName>> OzCodeDemos { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MainWindow).Assembly));

            //Create the CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Trace.WriteLine(compositionException.Message);
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;
            try
            {
                var demo = (from d in OzCodeDemos
                            where button != null && d.Metadata.Name == button.Name
                            select d.Value).Single();

                demo.Start();
            }

            catch (Exception exp)
            {
                Trace.WriteLine(exp.Message);
            }
        }
    }
}
