using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProvider.Models.Responses
{
    public class CreatePaymentResponse
    {
        public string TransactionId { get; set; }
        public string TransactionStatus { get; set; }
        public string PaReq { get; set; }
        public string Url { get; set; }
    }
}
