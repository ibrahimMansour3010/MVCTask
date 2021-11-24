using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserViewModel
    {

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
    }

    public static class UserViewModelExetensions
    {
        public static UserViewModel ToModel (this User model)
        {
            return new UserViewModel()
            {
                ID = model.ID,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Phone = model.Phone,
                Gender = model.Gender
            };
        }
    }

}
