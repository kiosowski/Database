using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.Dto.ImportDto
{
        [XmlType("Procedure")]
        public class ProcedureDto
        {
            [Required]
            [StringLength(40, MinimumLength = 3)]
            [XmlElement("Vet")]
            public string VetName { get; set; }

            [Required]
            [RegularExpression("^([A-Za-z]{7}[0-9]{3})$")]
            [XmlElement("Animal")]
            public string AnimalSerialNumber { get; set; }

            [Required]
            [XmlElement("DateTime")]
            public string ProcedureDate { get; set; }

            public ProcedureAnimalAidDto[] AnimalAids { get; set; }
        }
}
