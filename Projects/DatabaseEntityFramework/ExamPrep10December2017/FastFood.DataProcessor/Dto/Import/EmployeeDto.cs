using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    public class EmployeeDto
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [Required]
        [Range(15, 80)]
        [XmlAttribute("Age")]
        public int Age { get; set; }
        [Required]
        [MinLength(3), MaxLength(30)]
        [XmlAttribute("Position")]
        public string Position { get; set; }
    }
}
