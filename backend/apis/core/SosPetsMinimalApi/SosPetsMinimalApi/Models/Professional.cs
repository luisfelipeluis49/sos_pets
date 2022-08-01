using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Professional
    {
        public Professional()
        {
            Appointments = new HashSet<Appointment>();
            EstablishmentProfessionals = new HashSet<EstablishmentProfessional>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Type { get; set; }
        public string Crmv { get; set; } = null!;

        public virtual TypeOfProfessional TypeNavigation { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<EstablishmentProfessional> EstablishmentProfessionals { get; set; }
    }
}
