using RESTAPI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Models
{
    public class Good
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}[-][0-9]{3}[-][0-9]{3}$")]
        public string Code { get; set; }

        [Required]
        [TitleValidation]
        public string Title { get; set; }

        [Required]
        [TypeValidation]
        public string Type { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        [Required]
        [PriceValidation]
        public double Price { get; set; }

        [Required]
        [TitleValidation]
        public string Data { get; set; }
    }
}