
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteProject.Models
{

    public class Role
    {


        [Key]
        public int role_id { get; set; }

        public string name { get; set; }

        public ICollection<User> User { get; set; }
    }

}