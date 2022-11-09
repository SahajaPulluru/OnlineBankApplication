﻿using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public char TransactionType { get; set; }
        [Required]
        public DateTime TransDate { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}