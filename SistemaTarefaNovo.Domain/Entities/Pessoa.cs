using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTarefaNovo.Domain.Entities
{
    [Table("pessoas")]
    public class Pessoa
    {
        [Key]
        public int idusuario { get; set; }
        public string? username { get; private set; }
        public string? password { get; private set; }
        public string? nome { get; set; }
        public string? email { get; set; }

        public Pessoa(int idusuario, string? username, string? password, string? nome, string? email)
        {
            this.idusuario = idusuario;
            this.username = username;
            this.password = password;
            this.nome = nome;
            this.email = email;
        }
    }
}
