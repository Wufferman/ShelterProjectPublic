namespace SharedProject.cs
{
    public class Userkommune
    {
        Users User;
        Kommune Kommune;
        public Userkommune(Users User, Kommune Kommune)
        {
            this.User = User;
            this.Kommune = Kommune;
            //Console.WriteLine($"UserKommune User: {this.User} Kommune: {this.Kommune} Oprettet.");
        }

    }
}