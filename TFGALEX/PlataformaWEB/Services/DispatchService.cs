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
    public class DispatchService : IDispatchService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public DispatchService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = "http://localhost:5001/api/dispatch";
        }

        public async Task<string> RegisterDispatch(Dispatch dispatch)
        {
            var uri = API.Dispatch.RegisterDispatch(_remoteServiceBaseUrl);
            var dispatchRequestDto = dispatchToDispatchRequestDto(dispatch);
            var jsonInString = JsonConvert.SerializeObject(dispatchRequestDto);
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception($"Error registrando el envío");
            }
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<string>(responseString);
        }

        public async Task<List<DispatchReport>> GetDispatches()
        {
            var uri = API.Dispatch.GetDispatches(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo los envíos");
            }

            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<DispatchReport>>(jsonResult);
            return result;
        }

        public async Task<PaginatedList<DispatchReport>> GetFilteredDispatches(DispatchFilters filters)
        {
            var uri = API.Dispatch.GetFilteredDispatches(_remoteServiceBaseUrl, filters);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error obteniendo los envíos");
            }

            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<DispatchReport>>(jsonResult);
            return result;
        }

        private DispatchDto dispatchToDispatchRequestDto(Dispatch dispatch)
        {
            double hours = 0.0;
            double.TryParse(dispatch.DispatchHour, out hours);
            var dispatchDateTime = dispatch.DispatchDate.AddHours(hours).DateTime;
            var DispatchDateOffset = new DateTimeOffset(dispatchDateTime, TimeSpan.FromMinutes(0)).AddMinutes(dispatch.UTCminutes);
            return new DispatchDto()
            {
                DestinationAddress = dispatch.DestinationAddress,
                DestinationCity = dispatch.DestinationCity,
                DestinationZipCode = dispatch.DestinationZipCode,
                DestinationCountry = dispatch.DestinationCountry,
                DestinationName = dispatch.DestinationName,
                DestinationEU = Convert.ToInt32(dispatch.DestinationEU),
                Facility = dispatch.Facility,
                DestinationFacilities = dispatch.DestinationFacilitiesList,
                Serials = dispatch.SerialList,
                TransportMode = dispatch.TransportMode,
                Vehicle = dispatch.Vehicle,
                DispatchDate = DispatchDateOffset
            };
        }

        
    }
}
