using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Breed
    {
        public Breed()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Breed1 { get; set; } = null!;

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
