using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Anamnesi
    {
        public Anamnesi()
        {
            AnamnesisMedicines = new HashSet<AnamnesisMedicine>();
            AnamnesisSurgeries = new HashSet<AnamnesisSurgery>();
            AnamnesisVaccines = new HashSet<AnamnesisVaccine>();
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public bool? Castrated { get; set; }
        public int ReproductionStage { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string? Diet { get; set; }
        public int ParasiteControl { get; set; }

        public virtual ParasiteControl ParasiteControlNavigation { get; set; } = null!;
        public virtual ReproductionStage ReproductionStageNavigation { get; set; } = null!;
        public virtual ICollection<AnamnesisMedicine> AnamnesisMedicines { get; set; }
        public virtual ICollection<AnamnesisSurgery> AnamnesisSurgeries { get; set; }
        public virtual ICollection<AnamnesisVaccine> AnamnesisVaccines { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
