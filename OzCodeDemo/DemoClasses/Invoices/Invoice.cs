namespace OzCodeDemo.DemoClasses.Invoices
{
    class Invoice
    {
        private readonly int _id;

        public Invoice(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
        }

        internal double CalculateVAT()
        {
            return 5;
        }
    }
}