using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ItemDto
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Price")]
        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        [Required]
        [MinLength(3), MaxLength(30)]
        [XmlAttribute("Category")]
        public string Category { get; set; }
    }
}
