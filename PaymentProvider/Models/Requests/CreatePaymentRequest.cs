using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProvider.Models.Requests
{
    public class CreatePaymentRequest
    {
        [Required]
        public string OrderId { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        public string CardExpiryDate { get; set; }
        [Required]
        public string Cvv { get; set; }
    }
}
