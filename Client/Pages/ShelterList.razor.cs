using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Microsoft.AspNetCore.Components;
using SharedProject.cs;
using SharedProject;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Client.Services.Interfaces;

namespace Client.Pages
{
    public partial class ShelterList
    {
        [Parameter]
        public int kommuneid { get; set; } = 751;
        //private string url = UrlDirectory.localhostServerUrl;

        [Inject]
        private IShelterService shelterService { get; set; }

        public List<Shelter> Shelters { get; set; }


        public string view = "listView";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //Shelters = await Http.GetFromJsonAsync<List<Shelter>>(url + $"/api/shelter/kommune/{kommuneid}");
                Shelters = await shelterService.GetShelterFromKommuneId(kommuneid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Empty ListView");
            }
        }
        public Task ChangeView()
        {
            if(view == "boxView")
            {
                view = "listView";
            }
            else
            {
                view = "boxView";
            }
            return Task.CompletedTask;
        }
    }
}
