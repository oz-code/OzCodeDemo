using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo._13.LINQ
{
	[Export(typeof(IOzCodeDemo))]
	[ExportMetadata("Demo", "QuerySyntaxLinq")]
	public class QuerySyntaxLinqDemo : IOzCodeDemo
	{
		public void Start()
		{
			Debugger.Break();

			var states =
				from customer in CustomersRepository.LoadCustomersFromDb()
				let address = customer.Address
				where !string.IsNullOrWhiteSpace(address.State)
				group address by address.State
				into stateGroup
				select stateGroup.Key;

			Debug.Assert( states.Count() == 19 );
		}
	}
}