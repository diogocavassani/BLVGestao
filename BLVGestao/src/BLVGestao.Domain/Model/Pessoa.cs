using BLVGestao.Domain.Enums;
using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public abstract class Pessoa : EntityBase
    {
        public int PessoaId { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
