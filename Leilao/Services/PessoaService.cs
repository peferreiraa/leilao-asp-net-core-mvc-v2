using System;
using Leilao.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Leilao.Services.Exceptions;

namespace Leilao.Services
{
    public class PessoaService
    {
        private readonly LeilaoContext _context;

        public PessoaService(LeilaoContext context)
        {
            _context = context;
        }

        //Buscar todas as pessoas da DB
        public async Task<List<Pessoa>> FindAllasync()
        {
            return await _context.Pessoa.Include(obj => obj.Produto).ToListAsync();
        }

        public async Task InsertAsync(Pessoa obj)
        {
            try
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }

        public async Task<Pessoa> FindByIdAsync(int id)
        {
            return await _context.Pessoa.Include(obj => obj.Produto).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<Pessoa> FindByNameAsync(string name)
        {
            return await _context.Pessoa.Include(obj => obj.Produto).FirstOrDefaultAsync(obj => obj.Nome.ToUpper() == name.ToUpper());
        }
    }
}
