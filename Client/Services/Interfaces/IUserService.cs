using SharedProject.cs;

namespace Client.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<Users>> GetAll();
        Task<bool> ValidateFromEmailAndPhone(string email, int phone);

        Task<Users> GetFromEmail(string email);

        Task DeleteUser(int id);

        Task CreateUser(Users user);
    }
}
