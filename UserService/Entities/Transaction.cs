using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Entities
{
    [Table("Tbl_Transactions")]
    public class Transaction
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public DateTime TransDate { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}