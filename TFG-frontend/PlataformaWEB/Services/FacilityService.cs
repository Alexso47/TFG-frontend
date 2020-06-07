using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlataformaWEB.Configuration;
using PlataformaWEB.Dto;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Infrastructure;
using PlataformaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public class FacilityService : IFacilityService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public FacilityService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = "https://apitfgalex.azurewebsites.net/";
        }

        async public Task<int> Create(Facility facility)
        {
            var uri = API.Facility.CreateFacility(_remoteServiceBaseUrl);
            var facilityDto = FacilityViewModelToDto(facility);
            var jsonInString = JsonConvert.SerializeObject(facilityDto);
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creating facility");
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
            var createdfacility = JsonConvert.DeserializeObject<FacilityDto>(responseString);
            return Int32.Parse(createdfacility.Id);
        }

        async public Task<PaginatedList<string>> GetFIDs()
        {
            var uri = API.Facility.GetFIDs(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error getting facilities IDs");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<string>>(jsonResult);
            return result;
        }

        async public Task<PaginatedList<string>> GetFIDsByEOID(string eoid)
        {
            var uri = API.Facility.GetFIDsByEOID(_remoteServiceBaseUrl, eoid);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error getting Facilities IDs");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<string>>(jsonResult);
            return result;
        }

        private FacilityDto FacilityViewModelToDto(Facility facility)
        {
            return new FacilityDto()
            {
                Id = facility.Id,
                Name = facility.Name,
                ActiveFrom = facility.ActiveFrom,
                Address = facility.Address,
                City = facility.City,
                ZipCode = facility.ZipCode,
                Country = facility.Country,
                Description = facility.Description
            };
        }
    }
}
