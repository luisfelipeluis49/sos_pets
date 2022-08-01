using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class ReproductionStage
    {
        public ReproductionStage()
        {
            Anamnesis = new HashSet<Anamnesi>();
        }

        public int Id { get; set; }
        public string Stage { get; set; } = null!;

        public virtual ICollection<Anamnesi> Anamnesis { get; set; }
    }
}
