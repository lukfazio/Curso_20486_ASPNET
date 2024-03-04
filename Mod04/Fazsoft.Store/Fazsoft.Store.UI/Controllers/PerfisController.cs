using Fazsoft.Store.Domain.Contracts.Data;
using Fazsoft.Store.Domain.Contracts.Repositories;
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
    public class PerfisController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUnitOfWork _uow;

        public PerfisController(
            IPerfilRepository perfilRepository
            , IUnitOfWork uow)
        {
            _perfilRepository = perfilRepository;
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var model = (await _perfilRepository.GetAllWithUsuarioAsync())
                            .Select(x => x.ToPerfilIndexVM());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            var model = new PerfilAddEditVM { };

            if (id > 0)
            {
                var data = await _perfilRepository.GetAsync(id);
                model = data.ToPerfilAddEditVM();
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddEdit(int id, PerfilAddEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var perfil = model.ToData();

            if (id == 0)
            {
                _perfilRepository.Add(perfil);
            }
            else
            {
                perfil.Id = id;
                perfil.DataAlteracao = DateTime.Now;
                _perfilRepository.Update(perfil);
            }

            await _uow.CommitAsync();

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            var perfil = await _perfilRepository.GetAsync(id);

            if (perfil == null)
            {
                return BadRequest();
            }
            _perfilRepository.Delete(perfil);

            await _uow.CommitAsync();

            return NoContent();

        }
    }
}
