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
    public class EconomicOperatorService : IEconomicOperatorService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public EconomicOperatorService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl =$"{settings.Value.AdministrationURL}";
        } 

        async public Task<int> Create(EconomicOperator economicOperator)
        {
            var uri = API.EconomicOperator.CreateEconomicOperator(_remoteServiceBaseUrl);
            var economicOperatorDto = EconomicOperatorViewModelToDto(economicOperator);
            var jsonInString = JsonConvert.SerializeObject(economicOperatorDto);
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creating economic operator");
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                if (errorMessage.Contains("CodeAlreadyExists"))
                {
                    throw new RequestErrorException("Create");
                }
                if (errorMessage.Contains("CodeHasExisted"))
                {
                    throw new RequestErrorException("Create");
                }
            }
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var createdEconomicOperator = JsonConvert.DeserializeObject<EconomicOperatorDto>(responseString);
            return Int32.Parse(createdEconomicOperator.Id);
        }

        async public Task<PaginatedList<string>> GetEOIDs()
        {
            var uri = API.EconomicOperator.GetEOIDs(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error getting Economic Operators IDs");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<string>>(jsonResult);
            return result;
        }

        public async Task<EconomicOperator> GetEconomicOperatorByEOID(string eoid)
        {
            var uri = API.EconomicOperator.GetEOInfo(_remoteServiceBaseUrl, eoid);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error getting Economic Operators Info");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EconomicOperator>(jsonResult);
            return result;
        }

        private EconomicOperatorDto EconomicOperatorViewModelToDto(EconomicOperator economicOperator)
        {
            return new EconomicOperatorDto()
            {
                Id = economicOperator.Id,
                Name = economicOperator.Name,
                ActiveFrom = economicOperator.ActiveFrom,
                Address = economicOperator.Address,
                City = economicOperator.City,
                ZipCode = economicOperator.ZipCode,
                Country = economicOperator.Country,
                Description = economicOperator.Description
            };
        }

        
    }
}
