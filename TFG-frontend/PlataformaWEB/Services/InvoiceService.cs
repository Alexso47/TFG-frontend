using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlataformaWEB.Configuration;
using PlataformaWEB.Dto;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Infrastructure;
using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests.Invoice;
using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public class InvoiceService : IInvoiceService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        private static readonly string _connectionOptions;

        public InvoiceService(HttpClient httpClient, IOptions<AppSettings> settings, ConnectionOptions connectionOptions)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = connectionOptions.apiLocal + "/api/invoice";
        }

        async public Task<InvoiceResponse> Register(Invoice invoice)
        {
            var uri = API.Invoice.RegisterInvoice(_remoteServiceBaseUrl);
            var invoiceDto = InvoiceRequestViewModelToDto(invoice);
            var jsonInString = JsonConvert.SerializeObject(invoiceDto);
            
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creando la factura");
            }
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<InvoiceResponse>(responseString);

            try
            {
                response.EnsureSuccessStatusCode();
                return result;
            }
            catch
            {
                return result;
            }
        }

        public async Task<PaginatedList<InvoiceReport>> GetInvoices()
        {
            var uri = API.Invoice.GetInvoices(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo las facturas");
            }

            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<InvoiceReport>>(jsonResult);
            return result;
        }

        public async Task<PaginatedList<InvoiceReport>> GetFilteredInvoices(InvoiceFilters filters)
        {
            var uri = API.Invoice.GetFilteredInvoices(_remoteServiceBaseUrl, filters);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo las facturas");
            }

            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<InvoiceReport>>(jsonResult);
            return result;
        }

        private InvoiceRequestDto InvoiceRequestViewModelToDto(Invoice invoice)
        {
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.DateRequest = DateTimeOffset.UtcNow.ToString("yyyyMMdd");
            requestHeader.TimeRequest = DateTimeOffset.UtcNow.ToString("hhmmss");
            requestHeader.RequestId = Guid.NewGuid().ToString();

            return new InvoiceRequestDto()
            {
                Id = invoice.Id,
                InvoiceDate = invoice.InvoiceDate,
                Price = invoice.Price,
                Currency = invoice.Currency,
                BuyerID = invoice.BuyerID,
                BuyerEU = invoice.BuyerEU ?  (byte) 1: (byte) 0,
                BuyerName = invoice.BuyerName,
                BuyerCity = invoice.BuyerCity,
                BuyerCountry = invoice.BuyerCountry,
                BuyerAddress = invoice.BuyerAddress,
                BuyerZipCode = invoice.BuyerZipCode,
                RequestHeader = requestHeader,
                Serials = invoice.SerialList
            };
        }
    }
}
