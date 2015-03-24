using System;

namespace LA3
{
    class PaymentInfo
    {
        public int AccountId { get; set; }
        public string InvoiceCode { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public double Net { get; set; }
        public double Outstanding { get; set; }
        public double ExpectedPayment { get; set; }
        public double Amountpaid { get; set; }
        public DateTime NextPayment { get; set; }
    }
}
