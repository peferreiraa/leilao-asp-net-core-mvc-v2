using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido!")]
        [Display(Name = "Item")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre {0} e {1}! ")]
        public string Nome { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço")]

        [Required(ErrorMessage = "Valor inválido!")]

        public double Preco { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

              
        public Produto()
        {

        }

        public Produto(int id, string nome, double preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public void AddPessoa(Pessoa pessoa)
        {
            Pessoas.Add(pessoa);
        }
    }
}
