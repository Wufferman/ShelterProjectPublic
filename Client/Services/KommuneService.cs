using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Client.Services.Interfaces;
using SharedProject;
using SharedProject.cs;
using System.Net.Http.Json;

namespace Client.Services
{
    public class KommuneService : IKommuneService
    {
        HttpClient _httpClient;
        string url = UrlDirectory.localhostServerUrl;
        public KommuneService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Kommune>> GetAllKommuner()
        {
           return _httpClient.GetFromJsonAsync<List<Kommune>>(url + $"/api/kommune");
        }
    }

}
