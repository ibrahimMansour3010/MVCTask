using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum Gender{
        Male,
        Female
    }
    [Table("User")]
    public class User:BaseModel
    {
        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(20)]
        public string Lastname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public virtual List<Token> Tokens { get; set; }
    }
}
