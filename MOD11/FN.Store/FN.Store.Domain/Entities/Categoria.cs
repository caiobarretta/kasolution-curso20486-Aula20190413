using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    [Table(nameof(Categoria))]
    public class Categoria : Entity
    {
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
