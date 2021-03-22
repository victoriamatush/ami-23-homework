using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Validation
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(decimal.TryParse(Convert.ToString(value), out decimal d) &&
                d >= 0 && d * 100 == Math.Floor(d * 100)))
                return false;
            return true;
        }
    }
}
