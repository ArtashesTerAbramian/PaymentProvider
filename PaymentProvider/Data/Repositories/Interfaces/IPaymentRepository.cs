using PaymentProvider.Models;
using PaymentProvider.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProvider.Data.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<string> CreatePayment(CreatePaymentRequest model);
    }
}
