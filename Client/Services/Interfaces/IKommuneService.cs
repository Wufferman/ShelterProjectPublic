using SharedProject.cs;

namespace Client.Services.Interfaces
{
    public interface IKommuneService
    {
        Task<List<Kommune>> GetAllKommuner();
    }
}
