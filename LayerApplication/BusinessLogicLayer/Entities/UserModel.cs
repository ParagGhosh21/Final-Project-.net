using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer.Entities
{
    public class UserModel
    {
        public int Id { get; set; }
       // [Required(ErrorMessage = "Please Provide Email")]
       // [EmailAddress(ErrorMessage = "Provide Valid Email")]
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
    }
}
