using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Dto.ImportDto
{
    public class PassportDto
    {
        [RegularExpression("^([A-Za-z]{7}[0-9]{3})$")]
        public string SerialNumber { get; set; }

        [MinLength(3), MaxLength(30)]
        public string OwnerName { get; set; }

        [RegularExpression(@"^(\+359|0)[0-9]{9}$")]
        public string OwnerPhoneNumber { get; set; }
     
        [Required]
        public string RegistrationDate { get; set; }
    }
}