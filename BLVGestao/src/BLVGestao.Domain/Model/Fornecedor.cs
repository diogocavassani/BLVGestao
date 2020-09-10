using System.Collections.Generic;
using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Fornecedor : Pessoa
    {
        public Fornecedor(/*int pessoaId,*/ string razaoSocial, string cnpj)
            //: base(pessoaId)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = NomeFantasia;
            Cnpj = cnpj;
            TipoPessoa = TipoPessoaEnum.PessoaFisica;

        }
        public Fornecedor()
        {
            TipoPessoa = TipoPessoaEnum.PessoaFisica;
        }

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }


}
