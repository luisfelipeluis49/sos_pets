using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Agendum
    {
        public Agendum()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int Tutor { get; set; }

        public virtual Tutor TutorNavigation { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
