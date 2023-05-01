namespace SharedProject.cs
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public Accounttypes accounttype { get; set; }
        public int phone { get; set; }
        public int phoneAreaCode { get; set; } 
    
    
        public Users(int id = 0, string username = "", string email = "", string name = "", int phone = 0, int phoneAreacode = 0)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.name = name;
            this.phone = phone;
            this.phoneAreaCode = phoneAreacode;
        }
    }


}