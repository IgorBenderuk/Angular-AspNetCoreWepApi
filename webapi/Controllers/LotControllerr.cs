using Microsoft.AspNetCore.Mvc;
using webapi.models;
using webapi.models.DTOS;
using webapi.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/Lot")]
    [ApiController]
    public class LotControllerr : ControllerBase
    {
        private readonly LotRepo lotRepo;

        public LotControllerr(LotRepo lotRepo)
        {
            this.lotRepo = lotRepo;
        }

        // GET: api/<LotControllerr>
        [HttpGet]
        public async Task<IActionResult> GetAllLots()
        {
            var lots = await lotRepo.GetLotsAsync();
            if (lots == null)
            {
                return BadRequest();
            }
            return Ok(lots);

        }

        // GET api/<LotControllerr>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLotById(int id)
        {
            var lot = await lotRepo.GetlotById(id);
            if (lot == null)
            {
                return BadRequest();
            }
            return Ok(lot);

        }


        // PUT api/<LotControllerr>/5
        [HttpPut]
        public async Task<IActionResult> UpdateLot(int lotid, [FromBody] LotDTO lotDTO)
        {
            var lot = await lotRepo.UpdateLot(lotid, lotDTO);

            if (lot == null)
            {
                return BadRequest();
            }
            return Ok(lot);
        }

        [HttpPut("setNewOwner")]
        public async Task<IActionResult> SetNewOwner(int lotId, int newUserId)
        {
            string mesege = await lotRepo.ChangeLotOwner(lotId, newUserId);
            return Ok(mesege);
        }


        // DELETE api/<LotControllerr>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLot(int id)
        {
            var lot = await lotRepo.DeleteLot(id);
            if (lot == null)
            {
                return BadRequest();
            }
            return Ok(lot);
        }
    }
}
