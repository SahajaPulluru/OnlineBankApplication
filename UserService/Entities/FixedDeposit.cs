using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Entities
{
    [Table("Tbl_FixedDeposits")]
    public class FixedDeposit
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string Product { get; set; }
        [Required]
        public int FdPeriod { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
