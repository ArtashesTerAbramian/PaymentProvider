using Microsoft.AspNetCore.Mvc;
using PaymentProvider.Data.Repositories;
using PaymentProvider.Data.Repositories.Interfaces;
using PaymentProvider.Models;
using PaymentProvider.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRep;

        public PaymentsController(IPaymentRepository paymentRep)
        {
            _paymentRep = paymentRep;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<string> CreatePayment([FromBody] CreatePaymentRequest payment)
        {
            var response =_paymentRep.CreatePayment(payment);

            if (response != null)
            {
                return response.Result.ToString();
            }
            return BadRequest();
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<string> ConfirmPayment([FromBody] ConfirmPaymentRequest payment)
        {
            var response = _paymentRep.ConfirmPayment(payment);

            if (response != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("[action]")]
        [HttpGet]
        public ActionResult<string> GetPaymentStatus(string transactionId)
        {

            var Status = _paymentRep.GetTransactionStatus(transactionId);
            if(Status != null)
            {
                Status.Result.ToString();
            }
            return BadRequest();
        }

    }
}
