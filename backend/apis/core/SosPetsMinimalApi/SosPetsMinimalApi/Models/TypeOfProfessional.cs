using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class TypeOfProfessional
    {
        public TypeOfProfessional()
        {
            Professionals = new HashSet<Professional>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Professional> Professionals { get; set; }
    }
}
