namespace SharedProject.cs
{
    public class Accounttypes
    {
        public int accounttypeid;
        public string name;

        public Accounttypes(int accounttypeid, string name)
        {
            this.accounttypeid = accounttypeid;
            this.name = name;
            //Console.WriteLine($"Accounttype id: {this.accounttypeid}, name: {name} Oprettet.");
        }

        public int Accounttypeid { get => this.accounttypeid; }
        public string Name { get => this.name; }
    }
}
