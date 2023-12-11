using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefaNovo.Aplication.DTOs
{
    public class PessoaDTO
    {
        public PessoaDTO(int idusuario, string? username, string? password, string? nome, string? email)
        {
            this.idusuario = idusuario;
            this.username = username;
            this.password = password;
            this.nome = nome;
            this.email = email;
        }

        public int idusuario { get; set; }
        public string? username { get;  set; }
        public string? password { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }


    }
}
