using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Pet
    {
        public Pet()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Tutor { get; set; }
        public DateTime Bithdate { get; set; }
        public int Specie { get; set; }
        public int Breed { get; set; }
        public string? Gender { get; set; }
        public int Anamnesis { get; set; }

        public virtual Anamnesi AnamnesisNavigation { get; set; } = null!;
        public virtual Breed BreedNavigation { get; set; } = null!;
        public virtual Specie SpecieNavigation { get; set; } = null!;
        public virtual Tutor TutorNavigation { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
