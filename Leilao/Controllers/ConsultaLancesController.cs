using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leilao.Models;
using Leilao.Services;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.Controllers
{
    public class ConsultaLancesController : Controller
    {
        private readonly PessoaService _pessoaService;

        private readonly LeilaoContext _context;

        public ConsultaLancesController(LeilaoContext context, PessoaService pessoaService)
        {
            _context = context;
            _pessoaService = pessoaService;
        }

        public async Task<IActionResult> Index(string Pesquisa = "")
        {
            var list = await _pessoaService.FindAllasync();

            if (!string.IsNullOrEmpty(Pesquisa))
            {
                list = list.Where(p => p.Produto.Nome.ToUpper().Contains(Pesquisa.ToUpper())).OrderBy(p => p.Produto.Nome.ToUpper()).ToList();
              
            }
            return View(list);


        }
    }
}