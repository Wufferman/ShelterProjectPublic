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
    [Route("api/kommune")]
    public class KommuneController
    {
        IKommuneRepository myRepo;
        public KommuneController(IKommuneRepository kommuneRepository)
        {
            myRepo = kommuneRepository;
        }

        [HttpGet]
        public List<Kommune> GetKommunes()
        {
            var x = myRepo.GetAllKommuner();

            //Console.WriteLine($"Kommunecount = {x.Count}");

            return x;
        }
        [HttpGet("/kommune/{id}")]
        public Kommune GetKommune(int id)
        {
            return myRepo.GetKommune(id);
        }

    }
}
