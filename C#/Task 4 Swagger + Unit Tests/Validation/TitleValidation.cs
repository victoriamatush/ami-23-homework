using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Validation
{
    public class TitleValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            foreach (char c in value.ToString())
                if (!(char.IsLetter(c) || char.IsWhiteSpace(c)))
                    return false;
            return true;
        }
    }
}