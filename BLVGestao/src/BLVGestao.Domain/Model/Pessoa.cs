using BLVGestao.Domain.Enums;
using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public abstract class Pessoa
    {
        public int PessoaId { get; set; }
        public bool Ativo { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Telefone> Telefone { get; set; }


        public Pessoa() { Ativo = true; }




    }
}
