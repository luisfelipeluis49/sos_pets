using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class ActiveIngredient
    {
        public ActiveIngredient()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
