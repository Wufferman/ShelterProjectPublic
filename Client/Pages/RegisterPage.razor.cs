using Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using SharedProject;
using SharedProject.cs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Client.Pages
{
    public partial class RegisterPage
    {
            string url = UrlDirectory.localhostServerUrl;

            public string Email { get; set; } = "";

            public int Phone { get; set; }

            public string Name { get; set; } = "";

            public string Username { get; set; } = "";

            public int PhoneAreaCode { get; set; }

            [Inject]
            private IUserService UService { get; set; }


        public async void Register()
        {

            Accounttypes accounttype = new Accounttypes(0, "Not Specified");
            if (Name.Contains("Admin"))
            {
                accounttype = new Accounttypes(1, "Admin");
                //Console.WriteLine("Admin");
            }

            var newUser = new Users
            {
                email = this.Email,
                phone = this.Phone,
                name = this.Name,
                username = this.Username,
                phoneAreaCode = this.PhoneAreaCode
            };
            newUser.accounttype = accounttype;
            await UService.CreateUser(newUser);

            //Console.WriteLine(JsonSerializer.Serialize(newUser));
            NavManager.NavigateTo("/loginPage");
        }
            


        }
}
