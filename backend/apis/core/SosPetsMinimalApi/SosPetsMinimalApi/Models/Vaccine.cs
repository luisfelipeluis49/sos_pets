using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Vaccine
    {
        public Vaccine()
        {
            AnamnesisVaccines = new HashSet<AnamnesisVaccine>();
            AppointmentVaccines = new HashSet<AppointmentVaccine>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AnamnesisVaccine> AnamnesisVaccines { get; set; }
        public virtual ICollection<AppointmentVaccine> AppointmentVaccines { get; set; }
    }
}
