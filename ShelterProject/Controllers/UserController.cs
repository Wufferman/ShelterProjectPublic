using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Server.Repositories.Interfaces;
using SharedProject.cs;

namespace Server.Controllers
{
    [ApiController]
    [EnableCors("policy")]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost("create")]
        public IActionResult CreateUser(Users user)
        {
            _userRepository.CreateUser(user);
            
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Users user)
        {
            _userRepository.UpdateUser(user);
            
            return Ok();
        }

        
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
           
            return Ok();
        }

        
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            
            return Ok(user);
        }
        [HttpGet("fromEmail/{email}")]
        public IActionResult GetUserFromEmail(string email)
        {
            var user = _userRepository.GetUserFromEmail(email);

            return Ok(user);
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            
            return Ok(users);
        }

        
        [HttpPost("admin")]
        public IActionResult CreateAdmin(int id, string password)
        {
            _userRepository.CreateAdmin(id, password);
            
            return Ok();
        }

        
        [HttpDelete("admin/{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            _userRepository.DeleteAdmin(id);
            
            return Ok();
        }

        
        [HttpGet("validate/{email}/{phone}")]
        public IActionResult ValidateUser(string email, int phone)
        {
            var isValid = _userRepository.ValidateUser(email, phone);
            
            return Ok(isValid);
        }
    }
}
