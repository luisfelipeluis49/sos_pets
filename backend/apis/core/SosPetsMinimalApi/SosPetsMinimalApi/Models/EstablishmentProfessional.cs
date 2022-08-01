using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class EstablishmentProfessional
    {
        public int Id { get; set; }
        public int Establishment { get; set; }
        public int Professional { get; set; }

        public virtual Establishment EstablishmentNavigation { get; set; } = null!;
        public virtual Professional ProfessionalNavigation { get; set; } = null!;
    }
}
