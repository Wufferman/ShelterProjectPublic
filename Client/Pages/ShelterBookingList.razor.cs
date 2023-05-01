using Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using SharedProject;
using SharedProject.cs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Client.Pages
{

    public partial class ShelterBookingList
    {

        string url = UrlDirectory.localhostServerUrl;
        public ShelterBookingList()
        {
        }
        public List<Shelterbooking> ShelterBookings { get; set; } = new List<Shelterbooking>();

        [Inject]
        private IShelterBookingService SBService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShelterBookings = await SBService.GetAllShelterBooking();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Empty List");
            }

            //Console.WriteLine(Directory.GetCurrentDirectory() + "Test");
        }
        public async void DeleteShelterBooking(int bookingid)
        {
            await SBService.DeleteShelterBooking(bookingid);
            ShelterBookings.Remove(ShelterBookings.Find(x => x.bookingid == bookingid));
            StateHasChanged();
        }
        
    }
}
