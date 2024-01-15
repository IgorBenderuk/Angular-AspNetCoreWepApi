using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.models
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
    }
}
