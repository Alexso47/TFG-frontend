using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlataformaWEB.Configuration;
using PlataformaWEB.Dto;
using PlataformaWEB.Exceptions;
using PlataformaWEB.Infrastructure;
using PlataformaWEB.Models;
using PlataformaWEB.Models.PostRequests;
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
        private static string _connectionOptions;

        public DispatchService(HttpClient httpClient, IOptions<AppSettings> settings, ConnectionOptions connectionOptions)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = connectionOptions.apiDevelop + "/api/dispatch";
        }

        public async Task<DispatchResponse> RegisterDispatch(Dispatch dispatch)
        {
            var uri = API.Dispatch.RegisterDispatch(_remoteServiceBaseUrl);
            var dispatchRequestDto = dispatchToDispatchRequestDto(dispatch);
            var jsonInString = JsonConvert.SerializeObject(dispatchRequestDto);

            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception($"Error registrando el envío");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result =  JsonConvert.DeserializeObject<DispatchResponse>(responseString);

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
            RequestHeader requestHeader = new RequestHeader();
            requestHeader.DateRequest = DateTimeOffset.UtcNow.ToString("yyyyMMdd");
            requestHeader.TimeRequest = DateTimeOffset.UtcNow.ToString("hhmmss");
            requestHeader.RequestId = Guid.NewGuid().ToString();

            double hours = 0.0;
            double.TryParse(dispatch.DispatchHour, out hours);
            var dispatchDateTimeOffset = dispatch.DispatchDate.AddHours(hours).DateTime;
            var DispatchDateOffset = new DateTimeOffset(dispatchDateTimeOffset);

            return new DispatchDto()
            {
                DestinationAddress = dispatch.DestinationAddress,
                DestinationCity = dispatch.DestinationCity,
                DestinationZipCode = dispatch.DestinationZipCode,
                DestinationCountry = dispatch.DestinationCountry,
                DestinationName = dispatch.DestinationName,
                DestinationEU = dispatch.DestinationEU ? (byte) 1: (byte) 0,
                DestinationFacility = dispatch.DestinationFacility,
                Facility = dispatch.Facility,
                Serials = dispatch.SerialList,
                TransportMode = dispatch.TransportMode,
                Vehicle = dispatch.Vehicle,
                DispatchDate = DispatchDateOffset,
                RequestHeader = requestHeader
            };
        }        
    }
}
