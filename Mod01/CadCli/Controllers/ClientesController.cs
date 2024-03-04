using CadCli.Core.Contracts;
using CadCli.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CadCli.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IRepository _repository;

        public ClientesController(IRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            var clientes = _repository.Get();

            return View(clientes);
        }

        public IActionResult Adicionar() => View();

        public IActionResult Editar(int id)
        {
            var cliente = _repository.Get(id);

            return View(cliente);
        }

        public IActionResult Excluir(int id)
        {
            var cliente = _repository.Get(id);

            return View(cliente);
        }

        public IActionResult ConfirmarDel(int id)
        {
            var cliente = _repository.Get(id);
            _repository.Delete(cliente);

            return RedirectToAction("Index");
        }

        public IActionResult Salvar(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                _repository.Add(cliente);
            }
            else
            {
                _repository.Update(cliente);
            }

            return RedirectToAction("Index");
        }

    }
}
