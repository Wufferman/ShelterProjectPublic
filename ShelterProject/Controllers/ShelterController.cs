using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using SharedProject.cs;
using System.Text.Json;

namespace Server.Controllers
{
    [ApiController]
    [EnableCors("policy")]
    [Route("api/shelter")]
    public class ShelterController
    {
        IShelterRepository myRepo;
        public ShelterController(IShelterRepository shelterRepository)
        {
            myRepo = shelterRepository;
        }

        

        [HttpGet]
        public List<Shelter> GetAllShelters()
        {
            return myRepo.GetAllShelters();
        }

        [HttpGet("kommune/{kid}")]
        public List<Shelter> GetKommuneShelters(int kid)
        {
            var x = myRepo.GetKommuneShelters(kid);
            return x;
        }

        [HttpGet("shelter/{shelter}")]
        public Shelter GetShelter(string shelter)
        {
            return myRepo.GetShelter(shelter);
        }
        [HttpPost]
        public void CreateShelter(Shelter shelter)
        {
            myRepo.CreateShelter(shelter);
        }

        [HttpPut]
        public void UpdateShelter(Shelter shelter)
        {
            myRepo.UpdateShelter(shelter);
        }
        [HttpDelete]
        public void DeleteShelter(Shelter shelter)
        {
            myRepo.DeleteShelter(shelter);
        }
        [HttpGet("exists/{shelter}")]
        public bool ShelterExists(Shelter shelter)
        {
            return myRepo.ShelterExists(shelter);
        }



    }
}
