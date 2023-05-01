using Client.Pages;
using Client.Services.Interfaces;
using SharedProject;
using SharedProject.cs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Web;

namespace Client.Services
{
    public class ShelterBookingService : IShelterBookingService
    {
        HttpClient _httpClient;
        string url = UrlDirectory.localhostServerUrl;
        public ShelterBookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Shelterbooking>> GetAllShelterBooking()
        {
            return _httpClient.GetFromJsonAsync<List<Shelterbooking>>(url + "/api/shelterbooking");
            
        }

        public Task DeleteShelterBooking(int bookingid)
        {
            return _httpClient.DeleteAsync(url + "/api/shelterbooking/" + bookingid);
        }

        public Task<bool> IsShelterAvailable(Shelterbooking booking)
        {
            return _httpClient.GetFromJsonAsync<bool>(url + "/api/shelterbooking/availability/" + HttpUtility.UrlEncode(JsonSerializer.Serialize(booking)));
        }

        public Task SubmitBooking(Shelterbooking booking)
        {
            return _httpClient.PostAsJsonAsync(url + "/api/shelterbooking", booking);
        }
    }
}
