using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FN.Store.Domain.Entities
{
    [Table(nameof(Produto))]
    public class Produto : Entity
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Limite excedido")]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Column(TypeName = "money")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Categoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Opção Inválida!")]
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }
    }
}
