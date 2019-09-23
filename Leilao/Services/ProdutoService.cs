using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Services
{
    public class ProdutoService
    {
        private readonly LeilaoContext _context;

        public ProdutoService(LeilaoContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produto.Include(x => x.Pessoas).ToListAsync();
        }
    }
}
