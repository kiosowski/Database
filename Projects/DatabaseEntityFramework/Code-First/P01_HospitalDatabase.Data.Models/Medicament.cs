using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.Prescription = new HashSet<PatientMedicament>();
        }
        public int MedicamentId { get; set; }
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescription { get; set; }
    }
}
