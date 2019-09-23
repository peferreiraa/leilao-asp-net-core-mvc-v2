using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Leilao.Models;
using Leilao.Models.ViewModels;
using Leilao.Services;
using Leilao.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Controllers
{
    public class PessoasController : Controller
    {
        private readonly PessoaService _pessoaService;
        private readonly ProdutoService _produtoService;

        public PessoasController(PessoaService pessoaService, ProdutoService produtoService)
        {
            _pessoaService = pessoaService;
            _produtoService = produtoService;
        }

        public async Task<IActionResult> Index(string Pesquisa = "")
        {
            var list = await _pessoaService.FindAllasync();

            if (!string.IsNullOrEmpty(Pesquisa))
            {
                list = list.Where(c => c.Nome.ToUpper().Contains(Pesquisa.ToUpper())).OrderBy(c => c.Nome.ToUpper()).ToList();
            }
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            //Buscar do banco de dados todos os produtos
            var produtos = await _produtoService.FindAllAsync();
            var viewModel = new PessoaFormViewModel { Produtos = produtos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            List<Produto> list = await _produtoService.FindAllAsync();
            foreach (Produto p in list)
            {
                if (p.Id == pessoa.ProdutoId)
                {
                    if (p.Preco >= pessoa.Lance)
                    {
                        return RedirectToAction(nameof(Error), new { message = "O valor não pode ser menor ou igual ao lance atual!" });

                    }

                    
                }

            }
            try
            {

                double novoPreco = list.Where(p => p.Id == pessoa.ProdutoId).Select(p => p.Preco).Aggregate(0.0, (x, y) => pessoa.Lance);
                foreach (Produto p in list)
                {
                    if (p.Id == pessoa.ProdutoId)
                    {
                        p.Preco = novoPreco;
                    }
                }

                await _pessoaService.InsertAsync(pessoa);
               
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}