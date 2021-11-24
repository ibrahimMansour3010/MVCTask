using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserAddModel
    {
        [Required]
        [MaxLength(50,ErrorMessage = "Firstname Maximum number of length 50")]
        [MinLength(3,ErrorMessage = "Firstname Minimum number of length 3")]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Lastname Maximum number of length 50")]
        [MinLength(3, ErrorMessage = "Lastname Minimum number of length 3")]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Username Maximum number of length 50")]
        [MinLength(3, ErrorMessage = "Username Minimum number of length 3")]
        public string Username { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Password Minimum number of length 5")]
        public string Password { get; set; }
        public Gender Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20),MinLength(13)]
        public string Phone { get; set; }
    }
    public static class UserAddModelExtensions
    {
        public static User ToUser(this UserAddModel userAdd)
        {
            return new User()
            {
                Firstname = userAdd.Firstname,
                Lastname = userAdd.Lastname,
                Username = userAdd.Username,
                Password = userAdd.Password,
                Gender = userAdd.Gender,
                Email = userAdd.Email,
                Phone = userAdd.Phone
            };
        }
        public static UserAddModel ToAddModel(this User user)
        {
            return new UserAddModel()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Username = user.Username,
                Password = user.Password,
                Gender = user.Gender,
                Email = user.Email,
                Phone = user.Phone
            };
        }
    }
}
