using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentMedicines = new HashSet<AppointmentMedicine>();
            AppointmentSurgeries = new HashSet<AppointmentSurgery>();
            AppointmentVaccines = new HashSet<AppointmentVaccine>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Agenda { get; set; }
        public int Pet { get; set; }
        public int Establishment { get; set; }
        public int Professional { get; set; }

        public virtual Agendum AgendaNavigation { get; set; } = null!;
        public virtual Establishment EstablishmentNavigation { get; set; } = null!;
        public virtual Pet PetNavigation { get; set; } = null!;
        public virtual Professional ProfessionalNavigation { get; set; } = null!;
        public virtual ICollection<AppointmentMedicine> AppointmentMedicines { get; set; }
        public virtual ICollection<AppointmentSurgery> AppointmentSurgeries { get; set; }
        public virtual ICollection<AppointmentVaccine> AppointmentVaccines { get; set; }
    }
}
