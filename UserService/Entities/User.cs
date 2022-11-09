using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;
using System.Xml.Linq;
namespace UserService.Entities
{
    public enum AccountTypeId
    {
        Checking = 'C',
        Saving = 'S'
    }
    [Table("Tbl_Users")]
    public class User
    {
        [Key]
        public string AccountNumber { get; set; } 
        [Required]
        public string FirstName { get; set; } 
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public char AccountTypeId{ get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        public int Balance { get; set; }
      


    }
}
