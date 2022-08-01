using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class AnamnesisMedicine
    {
        public int Id { get; set; }
        public int Anamnesis { get; set; }
        public int Medicine { get; set; }
        public int Dose { get; set; }
        public TimeSpan Interval { get; set; }
        public string? Details { get; set; }

        public virtual Anamnesi AnamnesisNavigation { get; set; } = null!;
        public virtual Medicine MedicineNavigation { get; set; } = null!;
    }
}
