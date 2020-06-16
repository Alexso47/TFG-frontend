using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlataformaWEB.Configuration;
using PlataformaWEB.Dto;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Infrastructure;
using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests.Facility;
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

        private static string _connectionOptions;

        public FacilityService(HttpClient httpClient, IOptions<AppSettings> settings, ConnectionOptions connectionOptions)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = connectionOptions.apiDevelop + "/api/facility";
        }

        async public Task<FacilityResponse> Create(Facility facility)
        {
            var uri = API.Facility.CreateFacility(_remoteServiceBaseUrl);
            var facilityDto = FacilityViewModelToDto(facility);
            var jsonInString = JsonConvert.SerializeObject(facilityDto);

            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creando la facility");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FacilityResponse>(responseString);

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

        async public Task<List<string>> GetFIDs()
        {
            var uri = API.Facility.GetFIDs(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo FIDS");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(jsonResult);
            return result;
        }

        async public Task<List<string>> GetFIDsByEOID(string eoid)
        {
            var uri = API.Facility.GetFIDsByEOID(_remoteServiceBaseUrl, eoid);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo los FID");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(jsonResult);
            return result;
        }

        private FacilityDto FacilityViewModelToDto(Facility facility)
        {
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.DateRequest = DateTimeOffset.UtcNow.ToString("yyyyMMdd");
            requestHeader.TimeRequest = DateTimeOffset.UtcNow.ToString("hhmmss");
            requestHeader.RequestId = Guid.NewGuid().ToString();

            return new FacilityDto()
            {
                Id = facility.Id,
                EOID = facility.EOID,
                Name = facility.Name,
                ActiveFrom = facility.ActiveFrom,
                Address = facility.Address,
                City = facility.City,
                ZipCode = facility.ZipCode,
                Country = facility.Country,
                Description = facility.Description,
                RequestHeader = requestHeader
            };
        }

        public async Task<FacilityResult> GetFacilityByFID(string fid)
        {
            var uri = API.Facility.GetFacilityInfo(_remoteServiceBaseUrl, fid);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo los FID");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FacilityResult>(jsonResult);
            return result;
        }
    }
}
