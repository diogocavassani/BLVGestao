using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public class GrupoAcesso : EntityBase
    {
        public GrupoAcesso(int grupoAcessoId, string descricao, string permissao) 
        {
            GrupoAcessoId = grupoAcessoId;
            Descricao = descricao;
            Permissao = permissao;
        }

        public int GrupoAcessoId { get; private set; }
        public string Descricao { get; private set; }
        public string Permissao { get; private set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}