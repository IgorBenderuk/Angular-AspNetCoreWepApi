using Microsoft.AspNetCore.Mvc;
using webapi.Migrations;
using webapi.models.DTOS;
using webapi.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankRepo bankRepo;

        public BankController( BankRepo bankRepo)
        {
            this.bankRepo = bankRepo;
        }

        // GET: api/<BankController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var banks = await this.bankRepo.GetBanks();  
            if (banks == null) {
                return BadRequest();
            }
            return Ok(banks);
        }

        // GET api/<BankController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankBy(int id)
        {
          var bank=await  this.bankRepo.GetBankAsync(id);
            if (bank == null)
            {
                return BadRequest();
            }
            return Ok(bank);
            
        }

        // POST api/<BankController>
        [HttpPost]
        public async  Task<IActionResult> Createbank ([FromBody] BankDTO bankDTO)
        {
          var bank = await bankRepo.CreateBank(bankDTO);
            if (bank == null)
            {
                return BadRequest();
            }

            return Ok(bank);

        }

        // PUT api/<BankController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBank (int id, [FromBody] BankDTO bankDTO)
        {
            var bank = await bankRepo.UpdateBank(bankDTO,id);

            if(bank == null)
            {
                return BadRequest();

            }
            return Ok(bank);

        }

        // DELETE api/<BankController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
            var bank =await bankRepo.DeleteBankAccount(id);
                return Ok(bank);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
