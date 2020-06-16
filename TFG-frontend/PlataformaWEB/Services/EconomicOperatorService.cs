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
using PlataformaWEB.Models.PostRequests.EO;

namespace PlataformaWEB.Services
{
    public class EconomicOperatorService : IEconomicOperatorService
    {
        private HttpClient _httpClient;
        private  string _remoteServiceBaseUrl;
        private static string _connectionOptions;

        public EconomicOperatorService(HttpClient httpClient, IOptions<AppSettings> settings, ConnectionOptions connectionOptions)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = connectionOptions.apiLocal + "/api/eo";
        } 

        async public Task<EOResponse> Create(EconomicOperator economicOperator)
        {
            var uri = API.EconomicOperator.CreateEconomicOperator(_remoteServiceBaseUrl);
            var economicOperatorDto = EconomicOperatorViewModelToDto(economicOperator);
            var jsonInString = JsonConvert.SerializeObject(economicOperatorDto);
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creando el economic operator");
            }
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EOResponse>(responseString);

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

        async public Task<List<string>> GetEOIDS()
        {
            var uri = API.EconomicOperator.GetEOIDS(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo los Economic Operators IDs");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(jsonResult);
            return result;
        }

        public async Task<EOResult> GetEconomicOperatorByEOID(string eoid)
        {
            var uri = API.EconomicOperator.GetEOInfo(_remoteServiceBaseUrl, eoid);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo Economic Operators");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EOResult>(jsonResult);
            return result;
        }

        private EconomicOperatorDto EconomicOperatorViewModelToDto(EconomicOperator economicOperator)
        {
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.DateRequest = DateTimeOffset.UtcNow.ToString("yyyyMMdd");
            requestHeader.TimeRequest = DateTimeOffset.UtcNow.ToString("hhmmss");
            requestHeader.RequestId = Guid.NewGuid().ToString();

            return new EconomicOperatorDto()
            {
                Id = economicOperator.Id,
                Name = economicOperator.Name,
                ActiveFrom = economicOperator.ActiveFrom,
                Address = economicOperator.Address,
                City = economicOperator.City,
                ZipCode = economicOperator.ZipCode,
                Country = economicOperator.Country,
                Description = economicOperator.Description,
                RequestHeader = requestHeader
            };
        }

        
    }
}
