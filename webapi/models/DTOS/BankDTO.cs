using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.models.DTOS
{
    public class BankDTO
    {
        public string Name { get; set; }
         
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }




    }
}
