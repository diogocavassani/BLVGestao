using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public class GrupoAcesso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Permissao { get; set; }
        public bool Ativo { get; set; } = true;
        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}