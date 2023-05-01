using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Microsoft.AspNetCore.Components;
using SharedProject.cs;
using SharedProject;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using Client.Services.Interfaces;

namespace Client.Pages
{
    public partial class KommuneSelection
    {
        private int kommuneid;

        [Inject]
        private IKommuneService KommuneValg { get; set; }

        public List<Kommune> kommune { get; set; } = new List<Kommune>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                kommune = await KommuneValg.GetAllKommuner();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Empty List");
            }
        }

        private void submitSelection()
        {
            NavManager.NavigateTo("/shelterList/" + kommuneid);
        }

    }
}
