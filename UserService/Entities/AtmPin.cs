using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Entities
{
    [Table("Tbl_Atmdtls")]
    public class AtmPin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public int Atmpin { get; set; }    
    }
}
