using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Establishment
    {
        public Establishment()
        {
            Appointments = new HashSet<Appointment>();
            EstablishmentProfessionals = new HashSet<EstablishmentProfessional>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Crmv { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string? AddressComplement { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<EstablishmentProfessional> EstablishmentProfessionals { get; set; }
    }
}
