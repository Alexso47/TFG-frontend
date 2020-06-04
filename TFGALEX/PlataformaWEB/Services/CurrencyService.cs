using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlataformaWEB.Infrastructure;
using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlataformaWEB.Configuration;
using PlataformaWEB.Dto;
using PlataformaWEB.Exceptions;
using System.IO;
using System.Xml.Linq;

namespace PlataformaWEB.Services
{
    public class CurrencyService : ICurrencyService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public CurrencyService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl ="http://localhost:5001/";
        }

        async public Task<PaginatedList<string>> GetCurrencies()
        {
            var uri = API.Currency.GetCurrencies(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error getting Currencies");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<string>>(jsonResult);
            return result;
        }
    }
}
