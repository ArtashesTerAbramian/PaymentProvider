using Newtonsoft.Json;
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

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("53cr3t", "<merchant secret key>");
                    string jsonString = JsonConvert.SerializeObject(model);
                    using (var content = new StringContent(jsonString, System.Text.Encoding.Default, "application/json"))
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

                    string jsonModel = JsonConvert.SerializeObject(model);

                    using (var content = new StringContent(jsonModel, System.Text.Encoding.Default, "application/json"))
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
