using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class AnamnesisVaccine
    {
        public int Id { get; set; }
        public int Anamnesis { get; set; }
        public int Vaccine { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Expiration { get; set; }

        public virtual Anamnesi AnamnesisNavigation { get; set; } = null!;
        public virtual Vaccine VaccineNavigation { get; set; } = null!;
    }
}
