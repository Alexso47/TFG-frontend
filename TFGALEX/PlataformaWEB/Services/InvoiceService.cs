using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlataformaWEB.Configuration;
using PlataformaWEB.Dto;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Infrastructure;
using PlataformaWEB.Models;
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

        public InvoiceService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = "http://localhost:5001/api/administration/invoice";
        }

        async public Task<string> Register(Invoice invoice)
        {
            var uri = API.Invoice.RegisterInvoice(_remoteServiceBaseUrl);
            var invoiceDto = InvoiceRequestViewModelToDto(invoice);
            var jsonInString = JsonConvert.SerializeObject(invoiceDto);
            
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creando la factura");
            }
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseString);
        }

        public async Task<List<InvoiceReport>> GetInvoices()
        {
            var uri = API.Invoice.GetInvoices(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo las facturas");
            }

            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<InvoiceReport>>(jsonResult);
            return result;
        }

        
        public async Task<List<InvoiceReport>> GetFilteredInvoices(DateFilters filters)
        {
            var uri = API.Invoice.GetFilteredInvoices(_remoteServiceBaseUrl, filters);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo las facturas");
            }

            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<InvoiceReport>>(jsonResult);
            return result;
        }

        private InvoiceRequestDto InvoiceRequestViewModelToDto(Invoice invoice)
        {
            InvoiceReferenceRequestDto invoiceReference = new InvoiceReferenceRequestDto();
            invoiceReference.Id = invoice.Id;
            invoiceReference.InvoiceDate = invoice.InvoiceDate;
            invoiceReference.Price = invoice.Price;
            invoiceReference.Currency = invoice.Currency;
            invoiceReference.BuyerEU = invoice.BuyerEU;
            invoiceReference.BuyerName = invoice.BuyerName;
            invoiceReference.BuyerCity = invoice.BuyerCity;
            invoiceReference.BuyerCountry = invoice.BuyerCountry;
            invoiceReference.BuyerAddress = invoice.BuyerAddress;
            invoiceReference.BuyerZipCode = invoice.BuyerZipCode;

            RequestHeader requestHeader = new RequestHeader();
            requestHeader.DateRequest = DateTime.UtcNow.ToString("yyyyMMdd");
            requestHeader.TimeRequest = DateTime.UtcNow.ToString("hhmmss");
            requestHeader.RequestId = Guid.NewGuid().ToString();

            return new InvoiceRequestDto()
            {
                RequestHeader = requestHeader,
                Invoice = invoiceReference,
                Id = invoice.Id,
                Serials = invoice.SerialList
            };
        }
    }
}
