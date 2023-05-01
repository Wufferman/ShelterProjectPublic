using SharedProject.cs;

namespace Client.Services.Interfaces
{
    public interface IShelterService
    {
        Task<List<Shelter>> GetShelters();
        Task<List<Shelter>> GetShelterFromKommuneId(int kommuneid);

        Task<Shelter> GetShelterFromId(string shelterid);


    }
}
