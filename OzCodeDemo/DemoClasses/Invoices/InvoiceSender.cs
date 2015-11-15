using System;
using System.Diagnostics;

namespace OzCodeDemo.DemoClasses.Invoices
{
    internal class InvoiceSender
    {
        [DebuggerHidden]
        public void SendInvoice(string emailAddress, int pendingInvoiceId)
        {
            try
            {
                var invoice = LoadInvoiceFromDB(pendingInvoiceId);
                SendInvoiceToCustomer(emailAddress, invoice);
            }
            catch (Exception e)
            {
                throw new InvoiceProcessingException("Failed to process invoice. Operation will be rolled back.", e);
            }
        }

        [DebuggerHidden]
        private void SendInvoiceToCustomer(string emailAddress, Invoice invoice)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new InvoiceProcessingException();
            }
        }

        [DebuggerHidden]
        private Invoice LoadInvoiceFromDB(int pendingInvoiceId)
        {
            return new Invoice(pendingInvoiceId);
        }
    }
}