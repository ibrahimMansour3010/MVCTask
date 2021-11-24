using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Token")]
    public class Token:BaseModel
    {
        [Required]
        public string Code { get; set; }
        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User{ get; set; }
    }
}
