using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class ParasiteControl
    {
        public ParasiteControl()
        {
            Anamnesis = new HashSet<Anamnesi>();
        }

        public int Id { get; set; }
        public DateTime Prevention { get; set; }
        public string? PreventionDetails { get; set; }
        public DateTime CheckUp { get; set; }
        public DateTime Bath { get; set; }
        public bool? OnDay { get; set; }

        public virtual ICollection<Anamnesi> Anamnesis { get; set; }
    }
}
