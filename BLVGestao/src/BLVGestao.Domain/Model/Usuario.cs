using System.Collections.Generic;

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

        public int UsuarioId { get; private set; }
        public int GrupoAcessoId { get; set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public virtual GrupoAcesso GrupoAcesso { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
