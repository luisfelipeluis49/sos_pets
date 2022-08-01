using System;
using System.Collections.Generic;

namespace SosPetsMinimalApi.Models
{
    public partial class Tutor
    {
        public Tutor()
        {
            Agenda = new HashSet<Agendum>();
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Bithdate { get; set; }
        public string? Cpf { get; set; }
        public string? Crmv { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Agendum> Agenda { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
