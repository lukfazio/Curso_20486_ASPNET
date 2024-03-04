using Fazsoft.Store.Domain.Contracts.Data;
using Fazsoft.Store.Domain.Contracts.Repositories;
using Fazsoft.Store.Domain.Entities;
using Fazsoft.Store.Domain.Helpers;
using Fazsoft.Store.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fazsoft.Store.UI.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUnitOfWork _uow;

        public UsuariosController(
            IUsuarioRepository usuarioRepository
            , IPerfilRepository perfilRepository
            , IUnitOfWork uow)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var model = (await _usuarioRepository.GetAllWithPerfisAsync())
                                .Select(x => x.ToUsuarioIndexVM());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            var model = new UsuarioAddEditVM { };

            if (id > 0)
            {
                var data = await _usuarioRepository.GetByIDWithPerfisAsync(id);
                model = data.ToUsuarioAddEditVM();
                model.PerfisId = data.Perfis?.Select(x => x.Id).ToList();
            }
            await GetPerfisAsync(model);

            return View(model);
        }

        private async Task GetPerfisAsync(UsuarioAddEditVM model)
        {
            model.Perfis = (await _perfilRepository.GetAsync())
                            .Select(x => new SelectListItem { Text = x.Nome, Value = x.Id.ToString() });
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(int id, UsuarioAddEditVM model)
        {
            if (!ModelState.IsValid)
            {
                await GetPerfisAsync(model);
                return View(model);
            }

            if (id == 0)
            {
                var usuario = model.ToData();
                usuario.Senha.Encrypt();
                usuario.Perfis = await MontarPerfisAsync(model.PerfisId);
                _usuarioRepository.Add(usuario);
            }
            else
            {
                var usuario = await _usuarioRepository.GetByIDWithPerfisAsync(id);
                usuario.Id = id;
                usuario.Nome = model.Nome;
                usuario.DataAlteracao = DateTime.Now;
                usuario.Perfis = await MontarPerfisAsync(model.PerfisId);
                _usuarioRepository.Update(usuario);
            }

            await _uow.CommitAsync();

            return RedirectToAction("Index");
        }

        private async Task<IEnumerable<Perfil>> MontarPerfisAsync(IEnumerable<int> perfisId)
        {
            if (perfisId == null)
            {
                return null;
            }
            return await _perfilRepository.GetByIdsAsync(perfisId);
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            var prod = await _usuarioRepository.GetAsync(id);

            if (prod == null)
            {
                return BadRequest();
            }
            _usuarioRepository.Delete(prod);

            await _uow.CommitAsync();

            return NoContent();

        }
    }
}
