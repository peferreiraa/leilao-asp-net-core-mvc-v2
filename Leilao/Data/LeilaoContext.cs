using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Models
{
    public class LeilaoContext : DbContext
    {
        public LeilaoContext (DbContextOptions<LeilaoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
