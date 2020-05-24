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
    public class MachineService : IMachineService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public MachineService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = $"{settings.Value.AdministrationURL}/";
        }

        async public Task<int> Create(Machine machine)
        {
            var uri = API.Machine.CreateMachine(_remoteServiceBaseUrl);
            var machineDto = MachineViewModelToDto(machine);
            var jsonInString = JsonConvert.SerializeObject(machineDto);
            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creating machine");
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
            var createdmachine = JsonConvert.DeserializeObject<MachineDto>(responseString);
            return Int32.Parse(createdmachine.Id);
        }

        async public Task<PaginatedList<string>> GetMIDs()
        {
            var uri = API.Machine.GetMIDs(_remoteServiceBaseUrl);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error getting machines IDs");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<string>>(jsonResult);
            return result;
        }

        async public Task<PaginatedList<string>> GetMIDsByFID(string fid)
        {
            var uri = API.Machine.GetMIDsByFID(_remoteServiceBaseUrl, fid);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error getting Machines IDs");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<string>>(jsonResult);
            return result;
        }

        async public Task<PaginatedList<string>> GetProductsNameByMID(string mid)
        {
            var uri = API.Machine.GetProductsNameByMID(_remoteServiceBaseUrl, mid);
            var response = await _httpClient.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error getting Machines IDs");
            }
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedList<string>>(jsonResult);
            return result;
        }

        private MachineDto MachineViewModelToDto(Machine machine)
        {
            return new MachineDto()
            {
                Id = machine.Id,
                Name = machine.Name,
                ActiveFrom = machine.ActiveFrom,
                Serial = machine.Serial,
                Producer = machine.Producer,
                Description = machine.Description
            };
        }
    }
}
