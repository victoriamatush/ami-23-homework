using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Validation
{
    public class TypeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!value.ToString().Equals("box") && !value.ToString().Equals("letter"))
                return false;
            return true;
        }
    }
}