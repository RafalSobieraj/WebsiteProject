
using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteProject.Data
{
    public class CustomValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}