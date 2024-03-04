using Fazsoft.Store.Domain.Contracts.Data;
using Fazsoft.Store.Domain.Contracts.Repositories;
using Fazsoft.Store.Domain.Entities;
using Fazsoft.Store.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fazsoft.Store.UI.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _uow;

        public CategoriasController(
            ICategoriaRepository categoriaRepository
            , IUnitOfWork uow)
        {
            _categoriaRepository = categoriaRepository;
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var model = (await _categoriaRepository.GetAllWithProdutos())
                            .Select(x => x.ToCategoriaIndexVM());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            // ViewBag.Categorias = categorias;
            var model = new CategoriaAddEditVM { };

            if (id > 0)
            {
                var data = await _categoriaRepository.GetAsync(id);
                model = data.ToCategoriaAddEditVM();
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddEdit(int id, CategoriaAddEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var categoria = model.ToData();

            if (id == 0)
            {
                _categoriaRepository.Add(categoria);
            }
            else
            {
                categoria.Id = id;
                categoria.DataAlteracao = DateTime.Now;
                _categoriaRepository.Update(categoria);
            }

            await _uow.CommitAsync();

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            var categoria = await _categoriaRepository.GetAsync(id);

            if (categoria == null)
            {
                return BadRequest($"Item {id} não encontrado!");
            }
            var countprod = await CountProdAsync(categoria.Id);
            if ( countprod > 0)
            {
                return BadRequest($"Essa categoria possui {countprod} produtos!");
            }
            _categoriaRepository.Delete(categoria);

            await _uow.CommitAsync();

            return NoContent();

        }

        private async Task<int> CountProdAsync(int categoriaId)
        {
            return await _categoriaRepository.CountProdAsync(categoriaId);
        }
    }
}
