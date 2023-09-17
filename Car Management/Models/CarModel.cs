using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_Management.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z0-9]{10}$", ErrorMessage = "Model Code must be 10 alphanumeric characters.")]
        public string ModelCode { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Features { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfManufacturing { get; set; }

        public bool Active { get; set; }

        public int SortOrder { get; set; }

        public string Image { get; set; }

        [NotMapped]

        public HttpPostedFileBase FileBase { get; set; }
    }
}
