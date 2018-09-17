using PetClinic.Dto.ExportDto;
using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetClinic.Dto.ImportDto
{
    public class AnimalDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }
        [Required]
        public AnimalPassportDto Passport { get; set; }
    }
}
