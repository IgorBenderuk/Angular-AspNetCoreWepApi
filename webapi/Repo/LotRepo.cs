using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.models.DTOS;
using webapi.models;


namespace webapi.Repo
{
    public class LotRepo
    {
        private readonly AppDbContext appDbContext;
        private readonly UserRepo userRepo;

        public LotRepo( AppDbContext appDbContext,UserRepo userRepo)
        {
            this.appDbContext = appDbContext;
            this.userRepo = userRepo;
        }


        public async Task<IEnumerable<Lot>> GetLotsAsync()
        {
            var lots = await appDbContext.Lots.ToListAsync();

            return lots; 
        } 
        
        public async Task<IEnumerable<Lot>> GetLotыByUser( int userid)
        {
            var lots =  await appDbContext.Lots.Where(
                lots=>lots.OwnerId == userid)
                .ToListAsync();

            return lots;

        }
    
       public async Task<string> ChangeLotOwner(int lotId,int newOwnerId)
        {

           Lot lot= await appDbContext.Lots.FindAsync(lotId);
            var newUsser = await userRepo.GetById(newOwnerId);

            lot.OwnerId= newOwnerId;
            lot.Owner = newUsser; 

            string messege = $"owner of lot :${lotId} were changed to new owner {newOwnerId}";
            return messege ;
        }  

        public async Task<Lot> GetlotById(int lotId)
        {

            Lot lot = await appDbContext.Lots.FindAsync(lotId);
            return lot;
        }
        
        public async Task<Lot> UpdateLot(int lotId, LotDTO lotDto)
        {
            var lot =await GetlotById(lotId);

            if(lot == null)
            {
                return null;
            }
            lot.Model = lotDto.Model;   
            lot.Brand = lotDto.Brand;
            lot.VIN = lotDto.VIN;
            return lot;
        }

        public async Task<Lot> DeleteLot(int lotId)
        {
            var lot = await GetlotById(lotId);
            if (lot != null)
            {
            appDbContext.Lots.Remove(lot);
            await appDbContext.SaveChangesAsync();
            return lot;

            }
            return null;
        }


    }
}
