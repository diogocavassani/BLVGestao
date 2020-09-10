using System;
using System.Collections.Generic;
using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Cliente : Pessoa
    {
        public Cliente(/*int pessoaId,*/ string nome, DateTime dataNascimento, string cpf, string rg)
            //: base(pessoaId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Rg = rg;
            TipoPessoa = TipoPessoaEnum.PessoaFisica;
        }

        public Cliente()
        {
            TipoPessoa = TipoPessoaEnum.PessoaFisica;
        }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public ContaReceber ContaReceber { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
