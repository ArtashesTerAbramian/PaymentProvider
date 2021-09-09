using PaymentProvider.Data.Repositories.Interfaces;
using PaymentProvider.Models;
using PaymentProvider.Models.Requests;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PaymentProvider.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        Log log;
        public PaymentRepository()
        {
            log = new Log();
        }

        public async Task<string> CreatePayment(CreatePaymentRequest model)
        {
            try
            {
                var baseAddress = new Uri("https://dumdumpay.site/api/");

                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {


                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("6fc3aa31-7afd-4df1-825f-192e60950ca1", "<merchant identifier>");

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("secret-key", "<merchant secret key>");

                    using (var content = new StringContent("{  \"orderId\": \"DBB99946-A10A-4D1B-A742-577FA026BC57\",  \"amount\": 12312,  \"currency\": \"USD\",  \"country\": \"CY\",  \"cardNumber\": \"4111111111111111\",  \"cardHolder\": \"TEST TESTER\",  \"cardExpiryDate\": \"1123\",  \"cvv\": \"111\"}", System.Text.Encoding.Default, "application/json"))
                    {
                        using (var response = await httpClient.PostAsync("payment/create", content))
                        {
                            string responseData = await response.Content.ReadAsStringAsync();
                           
                            return responseData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               log.Write(ex);
            }
            return null;
        }

        public async Task<string> ConfirmPayment(ConfirmPaymentRequest model)
        {
            try
            {
                var baseAddress = new Uri("https://dumdumpay.site/api/");

                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {


                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("6fc3aa31-7afd-4df1-825f-192e60950ca1", "<merchant identifier>");

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("53cr3t", "<merchant secret key>");

                    using (var content = new StringContent("{  \"transactionId\": \"94ac5a85-8b81-4aaa-89dd-00e968f05d01\",  \"paRes\": \"MzgxMmYwNjItODY4MC00ZTQzLTkxMjUtMDQzNTU4Zjc4Yjc4\"}", System.Text.Encoding.Default, "application/json"))
                    {
                        using (var response = await httpClient.PostAsync("payment/confirm", content))
                        {
                            string responseData = await response.Content.ReadAsStringAsync();
                            return responseData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Write(ex);
            }
            return null;
        }

        public async Task<string> GetTransactionStatus(string transactionId)
        {
            try
            {
                var baseAddress = new Uri("https://dumdumpay.site/api/");

                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("6fc3aa31-7afd-4df1-825f-192e60950ca1", "<merchant identifier>");

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("53cr3t", "<merchant secret key>");

                    using (var response = await httpClient.GetAsync($"payment/{transactionId}/status"))
                    {

                        string responseData = await response.Content.ReadAsStringAsync();
                        return responseData;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Write(ex);
            }
            return null;
        }



    }
}
