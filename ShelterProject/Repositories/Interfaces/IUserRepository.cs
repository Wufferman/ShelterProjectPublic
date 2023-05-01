using SharedProject.cs;
namespace Server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        
            void CreateUser(Users user);

            void UpdateUser(Users user);

            void DeleteUser(int userID);

            bool UserExists(Users user);

            Users GetUser(int userID);

            List<Users> GetAllUsers();

            void CreateAdmin(int userID, string password);

            void DeleteAdmin(int userID);

            bool ValidateUser(string username, int password);

            // Add method that uses Accounttypes class
            Accounttypes GetAccounttype(int accounttypeid);
            Users GetUserFromEmail(string email);
        }
    }


