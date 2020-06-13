using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
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
    public class RequestService : IRequestService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public RequestService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = "https://apitfgalex.azurewebsites.net/";
        }

        async public Task<int> Create(Request request)
        {
            var uri = API.Request.CreateRequest(_remoteServiceBaseUrl);
            var machineDto = RequestViewModelToDto(request);
            var jsonInString = JsonConvert.SerializeObject(machineDto);
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creating request");
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
            var createdmachine = JsonConvert.DeserializeObject<RequestDto>(responseString);
            return Int32.Parse(createdmachine.Id);
        }

        private RequestDto RequestViewModelToDto(Request request)
        {
            return new RequestDto()
            {
                Id = request.Id,
                EOID = request.EOID,
                FID = request.FID,
                MID = request.MID,
                Description = request.Description,
                Type = request.Type,
                ProductName = request.ProductName,
                Market = request.Market,
                Route = request.Route,
                Quantity = request.Quantity,
                MLine = request.MLine,
                Comments = request.Comments
            };
        }
    }
}
