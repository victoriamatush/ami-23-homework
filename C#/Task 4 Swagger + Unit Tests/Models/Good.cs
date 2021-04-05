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

        [Required(ErrorMessage = "Code bad format")]
        [RegularExpression("^[0-9]{3}[-][0-9]{3}[-][0-9]{3}$")]
        public string Code { get; set; }

        [Required]
        [TitleValidation(ErrorMessage = "Only letters")]
        public string Title { get; set; }

        [Required]
        [TypeValidation(ErrorMessage = "Only box or letter")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Not int")]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        [Required]
        [PriceValidation(ErrorMessage = "Price should be > 0 ")]
        public double Price { get; set; }

        [Required]
        [TitleValidation(ErrorMessage = "Only letters")]
        public string Data { get; set; }
    }
}