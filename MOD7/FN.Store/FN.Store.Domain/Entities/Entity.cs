using System;
using System.ComponentModel.DataAnnotations;

namespace FN.Store.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
