using BLVGestao.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLVGestao.Domain.Model
{
    public class GrupoAcesso : EntityBase
    {

        public int GrupoAcessoId { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string Descricao { get; set; }
        public PermissaoEnum Permissao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}