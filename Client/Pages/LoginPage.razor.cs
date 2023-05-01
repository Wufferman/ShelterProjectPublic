using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using SharedProject.cs;
using Client.Shared;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using SharedProject;
using System.Runtime.InteropServices;
using Client.Services.Interfaces;

namespace Client.Pages
{
    public partial class LoginPage
    {

        //Add localstorage and sessionstorage and create a login system using the Usercontroller
        //Add a login page and a logout button



        public LoginPage() { }

        private string url = UrlDirectory.localhostServerUrl;

        public string Email { get; set; } = "";

        public int Phone { get; set; } = 0;

        public string Message { get; set; } = "Not logged in";

        public static bool IsLoggedIn { get; set; }

        public bool Role { get; set; }

        [Inject]
        private IUserService UService { get; set; }

        protected override async Task OnInitializedAsync()
        {

                if(await LocalStorage.ContainKeyAsync("User"))
                {
                    IsLoggedIn = true;
                    Message = "Logged in";
                    //Console.WriteLine();
                    //Console.WriteLine("Logged In");
                    NavMenu.isLoggedIn = true;
                    StateHasChanged();
                    //Console.WriteLine("UserID Isnt -5");
                    Users user = await LocalStorage.GetItemAsync<Users>("User");
                    Email = user.email;
                    Phone = user.phone;
                    if(user.accounttype.accounttypeid == 1)
                    {
                        NavMenu.isAdmin = true;
                    }
                }
                else
                {
                    IsLoggedIn = false;
                    //Console.WriteLine("UserID is -5");
                    NavMenu.isAdmin = false;
                }

        }



        public async Task Login()
        {
            
            try
            {

                    if (await UService.ValidateFromEmailAndPhone(Email, Phone))
                    {
                        IsLoggedIn = true;
                        Message = "Logged in";
                        await LocalStorage.SetItemAsync<Users>("User", await UService.GetFromEmail(Email));
                        Users user = await LocalStorage.GetItemAsync<Users>("User");
                        //Console.WriteLine();
                        //Console.WriteLine("Logged In");
                        NavMenu.isLoggedIn = true;
                        StateHasChanged();
                        if (user.accounttype.accounttypeid == 1)
                        {
                            NavMenu.isAdmin = true;
                        }
                        else
                        {
                            NavMenu.isAdmin = false;
                        }
                }
                    else
                    {
                        IsLoggedIn = false;
                        Message = "Wrong Email or Phone";
                        await LocalStorage.RemoveItemAsync("User");
                        NavMenu.isLoggedIn = false;
                        NavMenu.isAdmin = false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async Task Logout()
        {
            IsLoggedIn = false;
            Message = "Logged Out";
            await LocalStorage.RemoveItemAsync("User");
            NavMenu.isLoggedIn = false;
            NavMenu.isAdmin = false;
        }

    }
}
