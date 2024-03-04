using System.ComponentModel.DataAnnotations.Schema;

namespace CadCli.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
