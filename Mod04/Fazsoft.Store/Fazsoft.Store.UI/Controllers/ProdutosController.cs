using Fazsoft.Store.Data.EF;
using Fazsoft.Store.Domain.Contracts.Data;
using Fazsoft.Store.Domain.Contracts.Repositories;
using Fazsoft.Store.Domain.Entities;
using Fazsoft.Store.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fazsoft.Store.UI.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _uow;

        public ProdutosController(
            IProdutoRepository produtoRepository
            , ICategoriaRepository categoriaRepository
            , IUnitOfWork uow)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _uow = uow;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {            
            var produtos = (await _produtoRepository.GetAllWithCategoriaAsync())
                            .Select(x => x.ToProdutoIndexVM());

            return View(produtos);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            // ViewBag.Categorias = categorias;
            var model = new ProdutoAddEditVM { };

            if (id > 0)
            {
                var data = await _produtoRepository.GetAsync(id);
                model = data.ToProdutoAddEditVM();
            }

            await addCategoriasToModelAsync(model);

            return View(model);
        }

        private async Task addCategoriasToModelAsync(ProdutoAddEditVM model)
        {
            var categorias = await _categoriaRepository.GetAsync();
            model.Categorias = categorias.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });
        }


        [HttpPost]
        public async Task<IActionResult> AddEdit(int id, ProdutoAddEditVM model)
        {
            if (!ModelState.IsValid)
            {
                await addCategoriasToModelAsync(model);
                return View(model);
            }

            var produto = model.ToData();

            if (id == 0)
            {
                _produtoRepository.Add(produto);
            }
            else
            {
                produto.Id = id;
                produto.DataAlteracao = DateTime.Now;
                _produtoRepository.Update(produto);
            }

            await _uow.CommitAsync();

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            var prod = await _produtoRepository.GetAsync(id);

            if (prod == null)
            {
                return BadRequest();
            }
            _produtoRepository.Delete(prod);

           await  _uow.CommitAsync();

            return NoContent();

        }
    }
}