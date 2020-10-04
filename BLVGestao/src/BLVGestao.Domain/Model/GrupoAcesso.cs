using BLVGestao.Domain.Enums;
using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public class GrupoAcesso : EntityBase
    {

        public int GrupoAcessoId { get; set; }
        public string Descricao { get; set; }
        public PermissaoEnum Permissao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}