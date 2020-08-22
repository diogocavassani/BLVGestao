using BLVGestao.Domain.Enums;
using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public abstract class Pessoa : EntityBase
    {
        public Pessoa(int pessoaId, TipoPessoaEnum tipoPessoa, bool ativo) 
            : base(ativo)
        {
            PessoaId = pessoaId;
            TipoPessoa = tipoPessoa;

        }
        public int PessoaId { get; private set; }
        public TipoPessoaEnum TipoPessoa { get; private set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
