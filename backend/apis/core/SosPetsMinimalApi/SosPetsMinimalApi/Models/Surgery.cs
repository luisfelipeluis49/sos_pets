using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Surgery
    {
        public Surgery()
        {
            AnamnesisSurgeries = new HashSet<AnamnesisSurgery>();
            AppointmentSurgeries = new HashSet<AppointmentSurgery>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AnamnesisSurgery> AnamnesisSurgeries { get; set; }
        public virtual ICollection<AppointmentSurgery> AppointmentSurgeries { get; set; }
    }
}
