using System.Text.Json.Serialization;

using SharedProject.cs;

namespace Server.Repositories.Interfaces


{
    public interface IShelterRepository
    {
        List<Shelter> GetAllShelters();

        Shelter GetShelter(string shelter);

        List<Shelter> GetKommuneShelters(int id);

        void CreateShelter(Shelter shelter);

        void UpdateShelter(Shelter shelter);

        void DeleteShelter(Shelter shelter);

        bool ShelterExists(Shelter shelter);
    }
}
