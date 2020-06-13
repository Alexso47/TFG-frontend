using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlataformaWEB.Configuration;
using PlataformaWEB.Dto;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Infrastructure;
using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests.Arrival;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaWEB.Services
{
    public class ArrivalService : IArrivalService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        private static string _connectionOptions;

        public ArrivalService(HttpClient httpClient, IOptions<AppSettings> settings, ConnectionOptions connectionOptions)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = connectionOptions.apiLocal + "/api/arrival";
        }

        async public Task<ArrivalResponse> Register(Arrival arrival)
        {
            var arrivalDTO = arrivalToArrivalRequestDto(arrival);
            var jsonInString = JsonConvert.SerializeObject(arrivalDTO);
            var uri = API.Arrival.RegisterArrival(_remoteServiceBaseUrl);

            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error registrando la llegada");
            }
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ArrivalResponse>(responseString);

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

        public async Task<PaginatedList<ArrivalReport>> GetArrivals()
        {
            var uri = API.Arrival.GetArrivals(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo los envíos");
            }

            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<ArrivalReport>>(jsonResult);
            return result;
        }

        public async Task<PaginatedList<ArrivalReport>> GetFilteredArrivals(ArrivalFilters filters)
        {
            var uri = API.Arrival.GetFilteredArrivals(_remoteServiceBaseUrl, filters);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo los envíos");
            }

            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<ArrivalReport>>(jsonResult);
            return result;
        }

        private ArrivalDTO arrivalToArrivalRequestDto(Arrival arrival)
        {

            RequestHeader requestHeader = new RequestHeader();
            requestHeader.DateRequest = DateTimeOffset.UtcNow.ToString("yyyyMMdd");
            requestHeader.TimeRequest = DateTimeOffset.UtcNow.ToString("hhmmss");
            requestHeader.RequestId = Guid.NewGuid().ToString();

            return new ArrivalDTO()
            {
                Comments = arrival.Comments,
                FID = arrival.Facility,
                ArrivalDate = arrival.ArrivalDate,
                RequestHeader = requestHeader,
                Serials = arrival.SerialList
            };
        }
    }
}
