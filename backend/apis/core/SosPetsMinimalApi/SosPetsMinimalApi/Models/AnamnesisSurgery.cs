using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class AnamnesisSurgery
    {
        public int Id { get; set; }
        public int Anamnesis { get; set; }
        public int Surgery { get; set; }
        public string? Details { get; set; }
        public DateTime? Date { get; set; }

        public virtual Anamnesi AnamnesisNavigation { get; set; } = null!;
        public virtual Surgery SurgeryNavigation { get; set; } = null!;
    }
}
