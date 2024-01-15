using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.models
{
    public class Bank:BaseEntity
    {
        public string Name { get; set; }

        [Column(TypeName= "decimal(18,2)")]
        public decimal Balance { get; set; }


        public ICollection<UserBank>? Accounts { get; set; }=new LinkedList<UserBank>();


    }
}
