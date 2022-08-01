using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class AppointmentSurgery
    {
        public int Id { get; set; }
        public int Appointment { get; set; }
        public int Surgery { get; set; }
        public string? Details { get; set; }

        public virtual Appointment AppointmentNavigation { get; set; } = null!;
        public virtual Surgery SurgeryNavigation { get; set; } = null!;
    }
}
