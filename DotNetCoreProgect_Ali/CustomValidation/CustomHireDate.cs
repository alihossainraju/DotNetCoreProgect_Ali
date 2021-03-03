using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DotNetCoreProgect_Ali.CustomValidation
{
    public class CustomHireDate : ValidationAttribute
    {

        public CustomHireDate():base("{0} Should Less Than Current Date")
        {

        }
        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);
            if (propValue <= DateTime.Now)
                return true;
            else
                return false;
        }

    }
}