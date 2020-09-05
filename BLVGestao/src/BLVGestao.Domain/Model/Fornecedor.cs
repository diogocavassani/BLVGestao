using System.Collections.Generic;
using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Fornecedor : Pessoa
    {
        public Fornecedor(int pessoaId, string razaoSocial, string cnpj)
            : base(pessoaId)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = NomeFantasia;
            Cnpj = cnpj;
            TipoPessoa = TipoPessoaEnum.PessoaFisica;

        }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }

        public ICollection<Produto> Produtos { get; set; }
    }


}
