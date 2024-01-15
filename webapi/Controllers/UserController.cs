using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using webapi.models;
using webapi.models.DTOS;
using webapi.models.UserDTOS;
using webapi.Repo;

namespace webapi.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/User")]
    public class UserController : Controller
    {
        private readonly UserRepo userRepo;

        public UserController(UserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await this.userRepo.GetAllAsync();

            if (users == null)
            {
                return BadRequest();
            }
            return Ok(users);

        }

        [HttpPost("logIn")]
        public async Task<IActionResult> LogInUser([FromBody] UserLogIngDto userDTO)
        {

            var user = await userRepo.GetUserByEmail(userDTO.Email);

            if (user == null)
            {
                return NotFound("UserNotFound");
            }

            if(userDTO.Password != user.Password)
            {
                return BadRequest("password missmatch");
            }

            return Ok(user);

        }

        [HttpGet("CheckEmail")]
        public async Task<IActionResult> EmailExists(string email)
          {
            bool exists = await userRepo.EmailExists(email);

            if (exists != null )
            {
                return Ok(exists);
            }
            return BadRequest("something went wrong");

        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO  userDTO)
        {
         User newUser= await this.userRepo.CreateAsync(userDTO);
            if (newUser == null)
            {
                return BadRequest();
            }
            return Ok(newUser);
        }


        [HttpGet("byID")]
        public async Task<IActionResult> GetUserById(int id) {
            
            var user= await this.userRepo.GetById(id);

            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }


        [HttpPatch]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userDTO)
        {
         var user = await  this.userRepo.UpdateAsync(userDTO,id);

            return Ok(user);
        }


        [HttpPut("SetBankToUSer")]
        public async Task<IActionResult> SetUserAccount(int userId, int bankId)
        {
            var bank=await this.userRepo.SetbankToUser(userId, bankId);
            if(bank == null)
            {
                return BadRequest();
            }
            return Ok(bank);
        }

        [HttpPut("CreateLotForUser")]
        public async Task<IActionResult> CreateeLotForUser(LotDTO lotDTO, int userId)
        {
            var lot = await userRepo.CreateLotByUser(lotDTO, userId);
            if(lot == null) 
            { 
                return BadRequest();
            }
            return Ok(lotDTO);
        }

        [HttpDelete("Remove All Users")]
        public async Task<IActionResult> DeleteAllUSers(string secretWord)
        {
            var answer = await userRepo.DeleteAllUsers(secretWord );
            if(answer==true)
            {
                return Ok("success");
            }
            return BadRequest("Access is denied");
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user=await this.userRepo.DeleteAsync(id);
            return Ok(user);
        }
       
    }
}
