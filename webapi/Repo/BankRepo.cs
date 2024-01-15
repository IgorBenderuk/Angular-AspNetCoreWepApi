using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.models;
using webapi.models.DTOS;

namespace webapi.Repo
{
    public class BankRepo
    {
        private readonly AppDbContext appDbContext;

        public BankRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Bank> CreateBank(BankDTO bankDTO)
        {
            Bank newBank = new()
            {
                Balance = bankDTO.Balance,
                Name = bankDTO.Name,

            };
            await appDbContext.Banks.AddAsync(newBank);
            await appDbContext.SaveChangesAsync();
            return newBank;
        }

        public async Task<Bank> CreateMockBank(){
            Bank newBank = new()
            {
                Name = "test",
                Balance = 0
            };
            await this.appDbContext.Banks.AddAsync(newBank);
            await this.appDbContext.SaveChangesAsync();
            return newBank;

        }



        public async Task<List<Bank>> GetBanks()
        {
          var banks = await this.appDbContext.Banks.ToListAsync();

            return banks;
        }

        public async Task<Bank> GetBankAsync(int bankId)
        {
            if (bankId == 0) {
                return null;
            }

            var bank = await appDbContext.Banks.FindAsync(bankId);
            return bank;

        }

        public async Task<Bank> UpdateBank(BankDTO bankDTO, int bankId)
        {
            if (bankId == 0 || bankDTO.Name == "string")
            {
                return null;

            }

            var bank = await GetBankAsync(bankId);
            if (bank != null)
            {
                bank.Balance = bankDTO.Balance;
                bank.Name = bankDTO.Name;
                return bank;
            }
            return null;

        }

        public async Task<bool> DeleteBankAccount(int bankid)
        {
            var bank = await GetBankAsync(bankid);

            if(bank == null)
            {
                return false;
            }


            try
            {
                this.appDbContext.Banks.Remove(bank);
                await appDbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ) { }
            {
                await Console.Out.WriteLineAsync($"An error occurred while deleting the bank:");

                return false;
            }
        }

    }
}
