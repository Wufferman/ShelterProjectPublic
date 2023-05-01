using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Client.Services.Interfaces;
using SharedProject;
using SharedProject.cs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    public class ShelterService : IShelterService
    {
        HttpClient _httpClient;
        string url = UrlDirectory.localhostServerUrl;
        public ShelterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Shelter>> GetShelters()
        {
            throw new NotImplementedException();
        }

        public Task<List<Shelter>> GetShelterFromKommuneId(int kommuneid)
        {
            return _httpClient.GetFromJsonAsync<List<Shelter>>(url + $"/api/shelter/kommune/{kommuneid}");
        }

        public Task<Shelter> GetShelterFromId(string shelterid)
        {
            return _httpClient.GetFromJsonAsync<Shelter>(url + $"/api/shelter/shelter/{shelterid}");
        }
    }
}
