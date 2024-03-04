using System;

namespace Fazsoft.Store.Domain.Entities
{
    public abstract class Entity
    {

        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; } = 1;
        public Usuario Usuario { get; set; }
    }
}