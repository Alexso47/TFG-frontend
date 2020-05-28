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
    public class ArrivalService : IArrivalService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public ArrivalService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = $"{settings.Value.AdministrationURL}/";
        }

        async public Task<string> Register(Arrival arrival)
        { 
            var arrivalDTO = new ArrivalDTO()
            {
                RequestHeader = new RequestHeader()
                {
                    RequestId = Guid.NewGuid().ToString()
                },
                Reference = new Arrival2FacilityReference()
                {
                    FacilityID = arrival.Facility,
                    EventTime = DateTime.UtcNow
                },
                Comments = arrival.Comments,
                Serials = arrival.SerialList
            };

            var jsonInString = JsonConvert.SerializeObject(arrivalDTO);
            var uri = API.Arrival.RegisterArrival(_remoteServiceBaseUrl);
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error registrando la llegada");
            }

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseString);
        }
    }
}
