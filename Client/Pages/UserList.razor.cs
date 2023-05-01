using SharedProject.cs;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using SharedProject;
using Microsoft.AspNetCore.Components;
using Client.Services.Interfaces;

namespace Client.Pages
{
    public partial class UserList
    {
        string url = UrlDirectory.localhostServerUrl;

        public List<Users> Users { get; set; } = new List<Users>();

        [Inject]
        public IUserService UService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Users = await UService.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Empty List");
            }
            
        }

        public async Task deleteUser(int userId)
        {
            await UService.DeleteUser(userId);
            StateHasChanged();
            Users = await UService.GetAll();
        }


    }
}
