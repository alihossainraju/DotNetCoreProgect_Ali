using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetCoreProgect_Ali.CustomValidation
{
    public class MyValidation2 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string message = value.ToString();
                if (message.Contains("Good"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Must be use Good / Most Good / More Good");
        }
    }
}