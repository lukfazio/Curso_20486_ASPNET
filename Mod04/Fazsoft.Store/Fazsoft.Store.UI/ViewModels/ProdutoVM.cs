using Fazsoft.Store.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.UI.ViewModels
{
    public class ProdutoIndexVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public DateTime DataCadastro { get; set; }

    }

    public class ProdutoAddEditVM
    {        

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int? CategoriaId { get; set; }

        public IEnumerable<SelectListItem> Categorias { get; set; }
        //public IEnumerable<ProdutoAddCategoriasVM> Categorias { get; set; }


    }

    public static class ProdutoVMExtensions
    {
         public static ProdutoIndexVM ToProdutoIndexVM(this Produto data)
        {
            return new ProdutoIndexVM
            {
                Id = data.Id,
                Nome = data.Nome,
                Preco = data.Preco,
                Categoria = data.Categoria?.Nome,
                DataCadastro = data.DataCadastro
            };
        }

        public static ProdutoAddEditVM ToProdutoAddEditVM(this Produto data)
        {
            return new ProdutoAddEditVM
            {                
                Nome = data.Nome,
                CategoriaId = data.CategoriaId,
                Preco = data.Preco
            };
        }

        public static Produto ToData(this ProdutoAddEditVM model)
        {
            return new Produto
            {               
                Nome = model.Nome,
                Preco = (decimal)model.Preco,
                CategoriaId = (int)model.CategoriaId
            };
        }

    }

    //public class ProdutoAddCategoriasVM
    //{
    //    public int Id { get; set; }
    //    public string Nome { get; set; }
    //}
}
