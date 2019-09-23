using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.Models.ViewModels
{
    public class PessoaFormViewModel
    {
        public Pessoa Pessoa { get; set; }
        public ICollection<Produto> Produtos { get; set; }

    }
}
