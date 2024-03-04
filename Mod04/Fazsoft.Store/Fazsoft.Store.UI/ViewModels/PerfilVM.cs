using Fazsoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.UI.ViewModels
{
    public class PerfilIndexVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Usuarios { get; set; }

    }

    public class PerfilAddEditVM
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "o campo precisa ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }
    }


    public static class PerfilVMModelExtensions
    {
        public static PerfilAddEditVM ToPerfilAddEditVM(this Perfil data)
        {
            return new PerfilAddEditVM() { Nome = data.Nome };
        }

        public static Perfil ToData(this PerfilAddEditVM model)
        {
            return new Perfil() { Nome = model.Nome };
        }

        public static PerfilIndexVM ToPerfilIndexVM(this Perfil data)
        {
            return new PerfilIndexVM()
            {
                Id = data.Id,
                Nome = data.Nome,
                DataCadastro = data.DataCadastro,
                Usuarios = string.Join(", ", data.Usuarios?.Select(x => x.Nome))
            };
        }
    }
}
