using System.Xml.Serialization;

namespace PetClinic.Dto.ExportDto
{
    [XmlType("AnimalAid")]
    public class ProcedureExportAnimalAidDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}