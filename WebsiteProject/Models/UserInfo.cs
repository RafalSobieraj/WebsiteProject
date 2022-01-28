using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteProject.Models
{
    public class UserInfo
    {
        [Key]
        public int id { get; set; }
        [DataType(DataType.Text)]
        public int age { get; set; }
        [EmailAddress]
        [MaxLength(10)]
        public string email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int phoneNumber  { get; set; }
        public ICollection<User> Users { get; set; }
    }

}