using Microsoft.Data.Sqlite;
using MongoDB.Driver.Core.Configuration;
using Server.Repositories.Interfaces;
using SharedProject.cs;

namespace Server.Repositories
{
    public class UserRepositorySQLite : IUserRepository
    {
        private readonly string connectionString = $"DataSource= C:\\Users\\JeffS\\source\\repos\\ShelterProjectFolder\\ShelterProject\\SQLIteData\\Shelter_Users.db";

        public void CreateUser(Users user)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"INSERT INTO Users (username, email, name, phone, phoneAreaCode, accounttypeId) VALUES ($Username, $Email,$Name, $Phone, $Phoneareacode, $accounttypeId)";
                command.Parameters.AddWithValue("$Username", user.username);
                command.Parameters.AddWithValue("$Email", user.email);
                command.Parameters.AddWithValue("$Name", user.name);
                command.Parameters.AddWithValue("$Phone", user.phone);
                command.Parameters.AddWithValue("$Phoneareacode", user.phoneAreaCode);
                command.Parameters.AddWithValue("$accounttypeId", user.accounttype.Accounttypeid);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(Users user)
        {
           
        }

        public void DeleteUser(int userID)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"DELETE FROM Users WHERE id = $id";
                command.Parameters.AddWithValue("$id", userID);
                command.ExecuteNonQuery();
            }

        }

        public bool UserExists(Users user)
        {
            
            return false; 
        }

        public Users GetUser(int userID)
        {
            
            return null; 
        }

        public List<Users> GetAllUsers()
        {

                var result = new List<Users>();
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM Users";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        result.Add(
                            new Users {
                                id = reader.GetInt32(0),
                                username = reader.GetString(1),
                                email = reader.GetString(2),
                                name = reader.GetString(3),
                                phone = reader.GetInt32(4),
                                phoneAreaCode = reader.GetInt32(5),
                                accounttype = GetAccounttype(reader.GetInt32(6))
                            }
                        );
                        }
                    }
                }
                return result;
            
        }

        public void CreateAdmin(int userID, string password)
        {
            
        }

        public void DeleteAdmin(int userID)
        {
            
        }

        public bool ValidateUser(string username, int password)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT COUNT(*) FROM Users WHERE email = $email AND phone = $phone";
                command.Parameters.AddWithValue("$email", username);
                command.Parameters.AddWithValue ("$phone", password);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine(reader.GetInt32(0));
                        if (reader.GetInt32(0) == 1) return true;
                    }
                }
            }


            return false; 
        }

        public Accounttypes GetAccounttype(int accounttypeid)
        {
            Accounttypes result = new Accounttypes(0, "");
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Accounttypes WHERE id = $id";
                command.Parameters.AddWithValue("$id", accounttypeid);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new Accounttypes(reader.GetInt32(0), reader.GetString(1));
                        
                    }
                }
            }
            return result;
        }

        public Users GetUserFromEmail(string email)
        {
            Users result = new Users();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Users WHERE email = $email";
                command.Parameters.AddWithValue("$email", email);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new Users
                        {
                            id = reader.GetInt32(0),
                            username = reader.GetString(1),
                            email = reader.GetString(2),
                            name = reader.GetString(3),
                            phone = reader.GetInt32(4),
                            phoneAreaCode = reader.GetInt32(5),
                            accounttype = GetAccounttype(reader.GetInt32(6))
                        };

                    }
                }
            }
            return result;
        }
    }
}
