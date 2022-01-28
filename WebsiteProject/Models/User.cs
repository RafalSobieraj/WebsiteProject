using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebsiteProject.Data;

namespace WebsiteProject.Models
{
    public class User 
    { 
    
        [Key]
        public int user_id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [ForeignKey("Role")]
        public int role_id { get; set; }
        public Role Role { get; set; }

        [ForeignKey("UserInfo")]
        public int UserInfoid { get; set; }
        public UserInfo UserInfo { get; set; }

    }

}