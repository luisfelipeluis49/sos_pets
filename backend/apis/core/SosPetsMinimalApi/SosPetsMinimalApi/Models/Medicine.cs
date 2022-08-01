using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            AnamnesisMedicines = new HashSet<AnamnesisMedicine>();
            AppointmentMedicines = new HashSet<AppointmentMedicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ActiveIngredient { get; set; }

        public virtual ActiveIngredient ActiveIngredientNavigation { get; set; } = null!;
        public virtual ICollection<AnamnesisMedicine> AnamnesisMedicines { get; set; }
        public virtual ICollection<AppointmentMedicine> AppointmentMedicines { get; set; }
    }
}
