using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlataformaWEB.Configuration;
using PlataformaWEB.Dto;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Infrastructure;
using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests.Arrival;
using PlataformaWEB.Models.ReportToEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public class ReportEmailService : IReportEmailService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl; 
        private static string _connectionOptions;


        public ReportEmailService(HttpClient httpClient, IOptions<AppSettings> settings, ConnectionOptions connectionOptions)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = connectionOptions.apiDevelop;
        }

        public async Task<string> CreateArrivalReportToEmail(ArrivalReportToEmail results)
        {
            var jsonInString = JsonConvert.SerializeObject(results);
            var uri = API.EmailReport.CreateArrivalReportToEmail();

            await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            return "OK";
        }

        public async Task<string> UpdateArrivalReportToEmail(ArrivalReportToEmail results)
        {
            var jsonInString = JsonConvert.SerializeObject(results);
            var uri = API.EmailReport.UpdateArrivalReportToEmail();

            await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            return "OK";
        }

        public async Task<string> CreateDispatchReportToEmail(DispatchReportToEmail results)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateDispatchReportToEmail(DispatchReportToEmail results)
        {
            var jsonInString = JsonConvert.SerializeObject(results);
            var uri = API.EmailReport.UpdateDispatchReportToEmail();

            await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            return "OK";
        }

        public async Task<string> CreateInvoiceReportToEmail(InvoiceReportToEmail results)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateInvoiceReportToEmail(InvoiceReportToEmail results)
        {
            //var filterUri = API.Invoice.GetFilteredInvoicesLA(_remoteServiceBaseUrl + "/api/invoice", filters);
            var jsonInString = JsonConvert.SerializeObject(results);
            var uri = API.EmailReport.UpdateInvoiceReportToEmail();

            await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            return "OK";
        }

        public async Task<string> CreateSerialReportToEmail(SerialReportToEmail results)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateSerialReportToEmail(SerialReportToEmail results)
        {
            var jsonInString = JsonConvert.SerializeObject(results);
            var uri = API.EmailReport.UpdateSerialReportToEmail();

            await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            return "OK";
        }
    }
}
