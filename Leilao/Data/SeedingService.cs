using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leilao.Models;

namespace Leilao.Data
{
    public class SeedingService
    {
        private LeilaoContext _context;

        public SeedingService(LeilaoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Produto.Any() || _context.Pessoa.Any())
            {
                return; //DB já foi populado
            }

            Produto produto1 = new Produto(1, "Carro", 2000.00);
            Produto produto2 = new Produto(2, "Moto", 800.00);

            Pessoa pessoa1 = new Pessoa(1, "Mary", produto1, 2500.00);
            Pessoa pessoa2 = new Pessoa(2, "Mary", produto2, 900.00);

            //Adicionar vários objetos de uma só vez.
            _context.Produto.AddRange(produto1, produto2);
            _context.Pessoa.AddRange(pessoa1, pessoa2);

            _context.SaveChanges();
            

        }
    }
}
