using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Entities
{
    public enum TransactionType
    {
        Deposit = 'D',
        Withdrawal = 'W',
        Transfer = 'T',
    }
    [Table("Tbl_Transactions")]
    public class Transaction
    {

        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; } 
        public char TransactionType { get; set; }
        public DateTime TransDate{ get; set; }
        public int Amount { get; set; }
    }
}
