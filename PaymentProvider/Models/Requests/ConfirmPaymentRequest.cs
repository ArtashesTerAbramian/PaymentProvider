using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProvider.Models.Requests
{
    public class ConfirmPaymentRequest
    {
        [Required]
        public string TransactionId { get; set; }
        [Required]
        public string PaRes { get; set; }
    }
}
