using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class AppointmentVaccine
    {
        public int Id { get; set; }
        public int Appointment { get; set; }
        public int Vaccine { get; set; }
        public DateTime? Expiration { get; set; }

        public virtual Appointment AppointmentNavigation { get; set; } = null!;
        public virtual Vaccine VaccineNavigation { get; set; } = null!;
    }
}
