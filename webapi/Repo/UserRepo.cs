using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.models;
using webapi.models.DTOS;
using webapi.models.UserDTOS;

namespace webapi.Repo
{
    public class UserRepo
    {
        private readonly AppDbContext appDbContext;
        private readonly BankRepo bankRepo;

        public UserRepo(AppDbContext appDbContext, BankRepo bankRepo)
        {
            this.appDbContext = appDbContext;
            this.bankRepo = bankRepo;
        }

        public async Task<bool> EmailExists(string email)
        {
            if (  await appDbContext.Users.AnyAsync(user =>  user.Email == email))
            {
                return true;
            }
            return false;
        }

        public async Task<User> CreateAsync(UserCreateDTO userDTO)
        {

            bool userExixts = await appDbContext.Users.AnyAsync(u => u.Email == userDTO.Email);
            if (userExixts)
            {
                return null;
            }

            User newUser = new()
            {
                FirstName = userDTO.FirstName,
                Password = userDTO.Password,
                Email = userDTO.Email,
                Age = userDTO.Age,
            };
            await appDbContext.Users.AddAsync(newUser);
            await appDbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync((user)=>user.Email==email);

            if(user != null  ) {
                return user;
            }
            return null;

        }

        public async Task<User> DeleteAsync(int id)
        {
            var user =  await this.GetById(id);
            if (user != null)
            {
                this.appDbContext.Remove(user);
                await this.appDbContext.SaveChangesAsync();
            return user;
            }
            return null;
        }

        public async Task<bool> DeleteAllUsers(string word)
        {
            string secretWord = "administrator";
            if (word != secretWord)
            {
            return false;
            }
            var users = await appDbContext.Users.ToListAsync();
            appDbContext.Users.RemoveRange(users);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await appDbContext.Users.ToListAsync();
            return users;

        }

        public async Task<User> GetById(int id)
        {
            var user = await appDbContext.Users.FindAsync(id);
            return user ;
        }

        public async Task<User> UpdateAsync(UserUpdateDTO userDTO, int id)
        {
            User updatedUser = await this.GetById(id);

            if (updatedUser != null&& userDTO !=null)
            {
                updatedUser.FirstName = userDTO.FirstName;
                updatedUser.Email = userDTO.Email;
                updatedUser.Age = userDTO.Age;

                await appDbContext.SaveChangesAsync();

                return updatedUser; 
            }
            return null;
        }

        public async Task<BankDTO> SetbankToUser( int userId,int? bankId)
        {
            var user = await GetById(userId);  
            if (user == null && bankId == null)
            {
                return null;
            }
            else 
            {
                var bank = await bankRepo.GetBankAsync((int)bankId);
                user.Banks.Add(new()
                {
                    AccountBank = bank,
                    AccountUser = user,
                    BankID = bank.id,
                    UserID = user.id
                });
                 await appDbContext.SaveChangesAsync();  
                BankDTO bankDTO = new ()
                {
                    Balance=bank.Balance ,
                    Name=bank.Name ,
                };
                return bankDTO;
            }

        }

        public async Task<Lot> CreateLotByUser(LotDTO lotDto, int userId)
        {
            var user = await GetById(userId);
            if (user == null && lotDto == null)
            {
            return null;
            }
            Lot lot = new()
            {
                Brand = lotDto.Brand,
                Model = lotDto.Model,
                VIN = lotDto.VIN,
                Owner = user,
                OwnerId = user.id
            };

            user.Lots.Add(lot);
               
            await appDbContext.SaveChangesAsync();
            return lot;

        }

    }
}
