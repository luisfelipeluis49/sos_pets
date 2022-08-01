using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Specie
    {
        public Specie()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Specie1 { get; set; } = null!;

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
