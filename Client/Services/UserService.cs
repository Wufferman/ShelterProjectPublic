using Client.Services.Interfaces;
using Client.Pages;
using SharedProject.cs;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using static System.Net.WebRequestMethods;
using System.Numerics;
using System.Net.Http.Json;
using SharedProject;

namespace Client.Services
{
    public class UserService : IUserService
    {
        HttpClient _httpClient;
        string url = UrlDirectory.localhostServerUrl;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task DeleteUser(int id)
        {
            return _httpClient.DeleteAsync(url + "/api/user/delete/" + id);
        }

        public Task<List<Users>> GetAll()
        {
            return _httpClient.GetFromJsonAsync<List<Users>>(url + "/api/user");
        }

        public Task<Users> GetFromEmail(string email)
        {
            return _httpClient.GetFromJsonAsync<Users>(url + $"/api/user/GetfromEmail/{email}");
        }

        public Task<bool> ValidateFromEmailAndPhone(string email, int phone)
        {
            return _httpClient.GetFromJsonAsync<bool>(url + $"/api/user/validate/{email}/{phone}");
        }

        public Task CreateUser(Users user)
        {
            return _httpClient.PostAsJsonAsync(url + "/api/user/create", user);

        }




}
}
