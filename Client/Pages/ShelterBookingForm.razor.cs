using SharedProject.cs;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using System.Web;
using Amazon.Runtime.Internal;
using System.Text.Json;
using SharedProject;
using Client.Services.Interfaces;

namespace Client.Pages
{
    public partial class ShelterBookingForm
    {
        [Parameter]
        public string ShelterId
        { get; set; }

        string url = UrlDirectory.localhostServerUrl;
        static readonly Shelterbooking emptyBooking = new Shelterbooking(0, new Shelter("", "", "", 0, 0, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", 0, ""), DateTime.Now, DateTime.Now.AddDays(2), "", 2, new Users());
        private Shelterbooking Booking = emptyBooking;
        private EditContext EditContext;
        private List<Users> UserList = new List<Users>();
        private Users user = new Users();
        private bool isAvailable = true;
        private bool isSubmitted = false;
        private Shelter oldShelter;
        private string errorCode = "";
        private Shelter chosenShelter = new Shelter("", "", "", 0, 0, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", 0, "");

        [Inject]
        private IShelterService ShelterService { get; set; }

        [Inject]
        private IShelterBookingService SBService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EditContext = new EditContext(Booking);
            EditContext.OnFieldChanged += EditContext_OnFieldChanged;
            user = await localStorage.GetItemAsync<Users>("User");
            try
            {
                chosenShelter = await ShelterService.GetShelterFromId(ShelterId);

                if (chosenShelter.ansva_v == null) chosenShelter.ansva_v = "";
                if (chosenShelter.handicap == null) chosenShelter.handicap = "";
                if (chosenShelter.ansvar_org == null) chosenShelter.ansvar_org = "";
                if (chosenShelter.beskrivels == null) chosenShelter.beskrivels = "";
                if (chosenShelter.kontak_ved == null) chosenShelter.kontak_ved = "";
                if (chosenShelter.lang_beskr == null) chosenShelter.lang_beskr = "";
                if (chosenShelter.link == null) chosenShelter.link = "";
                Booking.shelter = chosenShelter;
            }
            catch
            {
                Console.WriteLine("Shelter not found");
            }
            errorCode = "";
        }
        public async void HandleValidSubmit()
        {
            try
            {
                isAvailable = await SBService.IsShelterAvailable(Booking);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
            }
            if (isAvailable)
            {
                isSubmitted = true;
                Booking.user = await localStorage.GetItemAsync<Users>("User");
                await SBService.SubmitBooking(Booking);
                oldShelter = Booking.shelter;
                Booking = emptyBooking;
                EditContext = new EditContext(Booking);
                NavManager.NavigateTo($"/gratz/{HttpUtility.UrlEncodeUnicode(oldShelter.coordinates)}");
            }
            else
            {
                errorCode = "Shelter is booked in period";
                Console.WriteLine("Shelter is booked in period");
                StateHasChanged();
            }
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("HandleInvalidSubmit Called...");
        }

        private void changeEndDate()
        {
            if (Booking.starttime > Booking.endtime) Booking.endtime = Booking.starttime;
        }
        private void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
        {
            changeEndDate();
        }
    }
}
