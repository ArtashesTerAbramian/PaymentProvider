using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProvider.Models.Requests
{
    public class CreatePayment
    {
        public string OrderId { get; set; }
        public string Number { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string CardExpiryDate { get; set; }
        public string Cvv { get; set; }
    }
}
