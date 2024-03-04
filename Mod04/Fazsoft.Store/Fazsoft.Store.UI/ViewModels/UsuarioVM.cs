using Fazsoft.Store.Domain.Entities;
using Fazsoft.Store.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.UI.ViewModels
{
    public class UsuarioIndexVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Perfis { get; set; }
    }

    public class UsuarioAddEditVM
    {
        public UsuarioAddEditVM()
        {
            Generos = UsuarioVMModelExtensions.GetGeneros();
        }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50, ErrorMessage = "Tamanho Excedido!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [EmailAddress(ErrorMessage = "Email Inválido!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = ("As senhas não conferem!"))]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int? Genero { get; set; }
        public IEnumerable<SelectListItem> Generos { get; set; }

        public IEnumerable<SelectListItem> Perfis { get; set; }

        public IEnumerable<int> PerfisId { get; set; }
    }

    public static class UsuarioVMModelExtensions
    {
        public static Usuario ToData(this UsuarioAddEditVM model)
        {
            return new Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha,
                Genero = (Genero)model.Genero
            };
        }

        public static UsuarioAddEditVM ToUsuarioAddEditVM(this Usuario data)
        {
            var aux = "SenhaTemporaria";
            return new UsuarioAddEditVM
            {
                Nome = data.Nome,
                Email = data.Email,
                Senha = aux,
                ConfirmacaoSenha = aux,
                Genero = (int)data.Genero,
                Generos = GetGeneros()
            };
        }

        public static IEnumerable<SelectListItem> GetGeneros()
        {
            return Enum.GetValues(typeof(Genero)).Cast<Genero>().ToList()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
        }

        public static UsuarioIndexVM ToUsuarioIndexVM(this Usuario data)
        {
            return new UsuarioIndexVM
            {
                Id = data.Id,
                Nome = data.Nome,
                Email = data.Email,
                Genero = Enum.GetName(data.Genero),
                DataCadastro = data.DataCadastro,
                Perfis = string.Join(", ", data.Perfis?.Select(x => x.Nome))
            };
        }

    }
}
