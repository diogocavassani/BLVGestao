using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLVGestao.Domain.Model
{
    public class Usuario : EntityBase
    {
        public Usuario(int usuarioId, int grupoAcessoId, string login, string senha) 
        {
            UsuarioId = usuarioId;
            GrupoAcessoId = grupoAcessoId;
            Login = login;
            Senha = senha;
        }
        public Usuario()
        {

        }

        public int UsuarioId { get; set; }
        public int GrupoAcessoId { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        public string Login { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        public string Senha { get; set; }
        public virtual GrupoAcesso GrupoAcesso { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
