using SharedProject.cs;

namespace Server.Repositories.Interfaces
{
    public interface IKommuneRepository
    {
        List<Kommune> GetAllKommuner();
        Kommune GetKommune(int id);
    }
}
