using Fazsoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.UI.ViewModels
{
    public class CategoriaIndexVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? QtddProdutos { get; set; }
    }

    public class CategoriaAddEditVM
    {
        [Required(ErrorMessage ="Campo Obrigatório!")]
        [StringLength(50, ErrorMessage ="Limite excedido!")]
        public string Nome { get; set; }
    }

    public static class CategoriaVMModelExtensions
    {
        public static CategoriaAddEditVM ToCategoriaAddEditVM(this Categoria data)
        {
            return new CategoriaAddEditVM
            {
                Nome = data.Nome
            };
        }

        public static CategoriaIndexVM ToCategoriaIndexVM(this Categoria data)
        {
            return new CategoriaIndexVM
            {
                Id = data.Id,
                Nome = data.Nome,
                DataCadastro = data.DataCadastro,
                QtddProdutos = data.Produtos?.Count()
            };
        }

        public static Categoria ToData(this CategoriaAddEditVM model)
        {
            return new Categoria
            {
                Nome = model.Nome
            };
        }
    }
}
