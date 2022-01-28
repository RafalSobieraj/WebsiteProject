using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteProject.Models
{

    public class Cameras
    { 
        [Key]
        public int id { get; set; }
        [DisplayName("Camera Model")]
        [Required(ErrorMessage ="This field is required!")]
        public string camera_model { get; set; }
        [DisplayName("Resolution")]
        [Required(ErrorMessage = "This field is required!")]
        public int resolution { get; set; }
        [DisplayName("Camera Type")]
        [Required(ErrorMessage = "This field is required!")]
        public string camera_type { get; set; }
        [DisplayName("Camera Image")]
        public string image { get; set; }
        public bool enabled { get; set; }



        public String GetImagePath()
        {
            if (image == null || id == null) return null;

            return "~/images/" + "cameras/" + id + "/" + image;
        }
    }

}