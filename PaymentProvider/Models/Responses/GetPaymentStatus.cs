using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProvider.Models.Responses
{
    public class GetPaymentStatus 
    {
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string OrderID{ get; set; }
        public string LastFourDigits { get; set; }
    }
}
