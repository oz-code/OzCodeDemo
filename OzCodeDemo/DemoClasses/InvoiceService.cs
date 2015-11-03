using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows;

namespace OzCodeDemo.DemoClasses
{
    public class InvoiceService
    {
        private readonly BlockingCollection<Tuple<string, int>> _queue = new BlockingCollection<Tuple<string, int>>();

        readonly InvoiceSender _sender = new InvoiceSender();

        public InvoiceService()
        {
            new Thread(ProcessInvoiceRequests).Start();
        }

        public void SendInvoice(Customer customer) // <---- Use QuickAction Here.
        {
            _queue.Add(new Tuple<string, int>(customer.EmailAddress, customer.PendingInvoiceID));
        }

        private void ProcessInvoiceRequests()
        {
            while (!_queue.IsCompleted)
            {
                try
                {
                    var invoiceDetails = _queue.Take();
                    string customerEmail = invoiceDetails.Item1;
                    int pendingInvoiceId = invoiceDetails.Item2;

                    _sender.SendInvoice(customerEmail, pendingInvoiceId);
                }
                catch (Exception exp)
                {                    
                    MessageBox.Show(exp.Message, "Exception caught!");
                }

            }
        }

        public void Shutdown()
        {
            _queue.CompleteAdding();
        }
    }
}