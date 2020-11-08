using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string RazaoSocial { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }


}
